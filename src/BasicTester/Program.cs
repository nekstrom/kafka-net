using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Common;
using KafkaNet.Protocol;
namespace BasicTester
{

	/// <summary>
	/// This class simply logs all information out to the Trace log provided by windows.  
	/// The reason Trace is being used as the default it to remove extenal references from
	/// the base kafka-net package.  A proper logging framework like log4net is recommended.
	/// </summary>
	public class ConsoleLog : IKafkaLog
	{
		public void DebugFormat(string format, params object[] args)
		{
			Console.WriteLine(format, args);
		}

		public void InfoFormat(string format, params object[] args)
		{
			Console.WriteLine(format, args);
		}

		public void WarnFormat(string format, params object[] args)
		{
			Console.WriteLine(format, args);
		}

		public void ErrorFormat(string format, params object[] args)
		{
			Console.WriteLine(format, args);
		}

		public void FatalFormat(string format, params object[] args)
		{
			Console.WriteLine(format, args);
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			var options = new KafkaOptions(new Uri("http://10.254.90.44:9092"), new Uri("http://10.254.90.44:9093"), new Uri("http://10.254.90.44:9094"))
			{
				Log = new ConsoleLog()
			};
			var router = new BrokerRouter(options);
			var client = new Producer(router);

			Task.Run(() =>
			{
				var consumer = new Consumer(new ConsumerOptions("elk", router));
				foreach (var data in consumer.Consume())
				{
					// ... process each message
				}
			});

			while (true)
			{
				client.SendMessageAsync("elk", new[] {
					new Message("message")
				});
				Thread.Sleep(1);
			}

			client.Dispose();
			router.Dispose();
		}
	}
}
