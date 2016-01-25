using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace QueueWatcher
{
	public partial class Watcher : Form, IKafkaLog
	{

		private BrokerRouter _router = null;
		internal BrokerRouter router
		{
			get
			{
				if(_router == null)
				{
					if(!String.IsNullOrWhiteSpace(servers.Text))
					{
						List<Uri> uris = new List<Uri>();
						foreach(string server in servers.Text.Split(new char[] {' ', '|'}))
						{
							uris.Add(new Uri(server));
						}
						var options = new KafkaOptions(uris.ToArray())
							{
								Log = this
							};
						_router = new BrokerRouter(options);
					}
				}
				return _router;
			}

		}

		private Producer _producer = null;
		internal Producer producer
		{
			get
			{
				if(_producer == null && router != null && !String.IsNullOrWhiteSpace(topic.Text))
				{
					_producer = new Producer(router, 10);
				}
				return _producer;
			}
		}
		public Watcher()
		{
			InitializeComponent();
			int workers, completionPortThreads;
			ThreadPool.GetAvailableThreads(out workers, out completionPortThreads);
			if(workers == 0)
			{
				ThreadPool.GetMaxThreads(out workers, out completionPortThreads);
				ThreadPool.SetMaxThreads(workers + 5, completionPortThreads + 5);
			}
		}

		private Thread sendThread = null;
		private void send_Click(object sender, EventArgs e)
		{
			List<KafkaNet.Protocol.Message> messages = new List<KafkaNet.Protocol.Message>();
			messages.Add(new KafkaNet.Protocol.Message(message.Text));
			var task = producer.SendMessageAsync(topic.Text, messages);
		}

		private delegate void AddEntryDelegate(string message);
		public void AddEntry(string message)
		{
			if (this.messages.InvokeRequired)
			{
				this.Invoke(new AddEntryDelegate(this.AddEntry), new object[] { message });
				return;
			}
			ListViewItem item = new ListViewItem(new string[] {
				message
			});
			messages.Items.Add(item);
			messages.Items[messages.Items.Count - 1].EnsureVisible();
			while (messages.Items.Count > 1000) messages.Items.RemoveAt(0);
		}
		private Task followTask = null;
		private CancellationTokenSource cancelFollow = null;
		
		private void follow_Click(object sender, EventArgs e)
		{
			if (cancelFollow != null)
			{
				cancelFollow.Cancel();
				cancelFollow = null;
			}
			cancelFollow = new CancellationTokenSource();
			followTask = Task.Run(() =>
			{
				var consumer = new Consumer(new ConsumerOptions(topic.Text, router));
				foreach (var message in consumer.Consume(cancelFollow.Token))
				{
					AddEntry(Encoding.UTF8.GetString(message.Value));
				}
			});
		}
		private delegate void LogEntryDelegate(string message, string severity);
		public void LogEntry(string message, string severity)
		{
			if (this.messages.InvokeRequired)
			{
				this.Invoke(new LogEntryDelegate(this.LogEntry), new object[] { message, severity });
				return;
			}
			ListViewItem item = new ListViewItem(new string[] {
				severity,
				message
			});
			log.Items.Add(item);
			log.Items[log.Items.Count - 1].EnsureVisible();
			while (log.Items.Count > 1000) log.Items.RemoveAt(0);
		}

		public void DebugFormat(string format, params object[] args)
		{
			LogEntry(String.Format(format, args), "Debug");
		}

		public void InfoFormat(string format, params object[] args)
		{
			LogEntry(String.Format(format, args), "Info");
		}

		public void WarnFormat(string format, params object[] args)
		{
			LogEntry(String.Format(format, args), "Warn");
		}

		public void ErrorFormat(string format, params object[] args)
		{
			LogEntry(String.Format(format, args), "Error");
		}

		public void FatalFormat(string format, params object[] args)
		{
			LogEntry(String.Format(format, args), "Fatal");
		}

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(messages.SelectedItems.Count == 1)
            {
                Clipboard.Clear();
                Clipboard.SetText(messages.SelectedItems[0].Text);
            }
        }
	}
}
