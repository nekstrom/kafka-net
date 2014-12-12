namespace QueueWatcher
{
	partial class Watcher
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.messages = new System.Windows.Forms.ListView();
			this.messageHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.servers = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.topic = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.message = new System.Windows.Forms.TextBox();
			this.send = new System.Windows.Forms.Button();
			this.follow = new System.Windows.Forms.Button();
			this.log = new System.Windows.Forms.ListView();
			this.logMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.severity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// messages
			// 
			this.messages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.messageHeader});
			this.messages.Location = new System.Drawing.Point(13, 314);
			this.messages.Name = "messages";
			this.messages.Size = new System.Drawing.Size(680, 549);
			this.messages.TabIndex = 0;
			this.messages.UseCompatibleStateImageBehavior = false;
			this.messages.View = System.Windows.Forms.View.Details;
			// 
			// messageHeader
			// 
			this.messageHeader.Text = "Message";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Servers";
			// 
			// servers
			// 
			this.servers.Location = new System.Drawing.Point(62, 10);
			this.servers.Name = "servers";
			this.servers.Size = new System.Drawing.Size(631, 20);
			this.servers.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Topic";
			// 
			// topic
			// 
			this.topic.Location = new System.Drawing.Point(53, 40);
			this.topic.Name = "topic";
			this.topic.Size = new System.Drawing.Size(100, 20);
			this.topic.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Message";
			// 
			// message
			// 
			this.message.Location = new System.Drawing.Point(73, 89);
			this.message.Name = "message";
			this.message.Size = new System.Drawing.Size(620, 20);
			this.message.TabIndex = 6;
			// 
			// send
			// 
			this.send.Location = new System.Drawing.Point(19, 119);
			this.send.Name = "send";
			this.send.Size = new System.Drawing.Size(112, 23);
			this.send.TabIndex = 7;
			this.send.Text = "Send Message";
			this.send.UseVisualStyleBackColor = true;
			this.send.Click += new System.EventHandler(this.send_Click);
			// 
			// follow
			// 
			this.follow.Location = new System.Drawing.Point(197, 38);
			this.follow.Name = "follow";
			this.follow.Size = new System.Drawing.Size(75, 23);
			this.follow.TabIndex = 8;
			this.follow.Text = "Consume";
			this.follow.UseVisualStyleBackColor = true;
			this.follow.Click += new System.EventHandler(this.follow_Click);
			// 
			// log
			// 
			this.log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.severity,
            this.logMessage});
			this.log.Location = new System.Drawing.Point(12, 148);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(680, 160);
			this.log.TabIndex = 9;
			this.log.UseCompatibleStateImageBehavior = false;
			this.log.View = System.Windows.Forms.View.Details;
			// 
			// logMessage
			// 
			this.logMessage.Text = "Log Message";
			// 
			// severity
			// 
			this.severity.Text = "Severity";
			// 
			// Watcher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(705, 875);
			this.Controls.Add(this.log);
			this.Controls.Add(this.follow);
			this.Controls.Add(this.send);
			this.Controls.Add(this.message);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.topic);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.servers);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.messages);
			this.Name = "Watcher";
			this.Text = "Watcher";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView messages;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox servers;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox topic;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox message;
		private System.Windows.Forms.Button send;
		private System.Windows.Forms.ColumnHeader messageHeader;
		private System.Windows.Forms.Button follow;
		private System.Windows.Forms.ListView log;
		private System.Windows.Forms.ColumnHeader logMessage;
		private System.Windows.Forms.ColumnHeader severity;
	}
}

