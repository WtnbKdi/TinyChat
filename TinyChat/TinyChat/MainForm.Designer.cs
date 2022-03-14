namespace TinyChat
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portNumTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectedRoomIDLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.roomInButton = new System.Windows.Forms.Button();
            this.roomListBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.sendMessageTextBox = new System.Windows.Forms.TextBox();
            this.resiveMessageTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.currentRoomMemberNumStatusLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.currentRoomNameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currentRoomMemberListBox = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.createRoomButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.roomNameTextBox = new System.Windows.Forms.TextBox();
            this.reportLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Location = new System.Drawing.Point(66, 18);
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(101, 19);
            this.ipAddressTextBox.TabIndex = 0;
            this.ipAddressTextBox.Text = "10.0.4.101";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IPアドレス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ポート番号";
            // 
            // portNumTextBox
            // 
            this.portNumTextBox.Location = new System.Drawing.Point(235, 18);
            this.portNumTextBox.Name = "portNumTextBox";
            this.portNumTextBox.Size = new System.Drawing.Size(101, 19);
            this.portNumTextBox.TabIndex = 3;
            this.portNumTextBox.Text = "12345";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(511, 16);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(108, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "接続する";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userNameTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.portNumTextBox);
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.ipAddressTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 50);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接続設定";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(404, 18);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(101, 19);
            this.userNameTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "ユーザー名";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectedRoomIDLabel);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.roomInButton);
            this.groupBox2.Controls.Add(this.roomListBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 143);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "部屋一覧";
            // 
            // selectedRoomIDLabel
            // 
            this.selectedRoomIDLabel.AutoSize = true;
            this.selectedRoomIDLabel.Location = new System.Drawing.Point(104, 115);
            this.selectedRoomIDLabel.Name = "selectedRoomIDLabel";
            this.selectedRoomIDLabel.Size = new System.Drawing.Size(17, 12);
            this.selectedRoomIDLabel.TabIndex = 13;
            this.selectedRoomIDLabel.Text = "-1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "選択された部屋ID";
            // 
            // roomInButton
            // 
            this.roomInButton.Location = new System.Drawing.Point(172, 110);
            this.roomInButton.Name = "roomInButton";
            this.roomInButton.Size = new System.Drawing.Size(104, 23);
            this.roomInButton.TabIndex = 5;
            this.roomInButton.Text = "入室する";
            this.roomInButton.UseVisualStyleBackColor = true;
            this.roomInButton.Click += new System.EventHandler(this.roomInButton_Click);
            // 
            // roomListBox
            // 
            this.roomListBox.BackColor = System.Drawing.Color.White;
            this.roomListBox.FormattingEnabled = true;
            this.roomListBox.ItemHeight = 12;
            this.roomListBox.Location = new System.Drawing.Point(11, 28);
            this.roomListBox.Name = "roomListBox";
            this.roomListBox.ScrollAlwaysVisible = true;
            this.roomListBox.Size = new System.Drawing.Size(265, 76);
            this.roomListBox.TabIndex = 0;
            this.roomListBox.Click += new System.EventHandler(this.roomListBox_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sendMessageButton);
            this.groupBox3.Controls.Add(this.sendMessageTextBox);
            this.groupBox3.Controls.Add(this.resiveMessageTextBox);
            this.groupBox3.Location = new System.Drawing.Point(300, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 400);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "チャット";
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(6, 371);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(329, 23);
            this.sendMessageButton.TabIndex = 6;
            this.sendMessageButton.Text = "送信する";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // sendMessageTextBox
            // 
            this.sendMessageTextBox.BackColor = System.Drawing.Color.White;
            this.sendMessageTextBox.Location = new System.Drawing.Point(6, 256);
            this.sendMessageTextBox.Multiline = true;
            this.sendMessageTextBox.Name = "sendMessageTextBox";
            this.sendMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendMessageTextBox.Size = new System.Drawing.Size(329, 113);
            this.sendMessageTextBox.TabIndex = 1;
            // 
            // resiveMessageTextBox
            // 
            this.resiveMessageTextBox.BackColor = System.Drawing.Color.White;
            this.resiveMessageTextBox.Location = new System.Drawing.Point(6, 18);
            this.resiveMessageTextBox.Multiline = true;
            this.resiveMessageTextBox.Name = "resiveMessageTextBox";
            this.resiveMessageTextBox.ReadOnly = true;
            this.resiveMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resiveMessageTextBox.Size = new System.Drawing.Size(329, 232);
            this.resiveMessageTextBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.currentRoomMemberNumStatusLabel);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.currentRoomNameLabel);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.currentRoomMemberListBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 217);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(282, 170);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "部屋情報";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "メンバー";
            // 
            // currentRoomMemberNumStatusLabel
            // 
            this.currentRoomMemberNumStatusLabel.AutoSize = true;
            this.currentRoomMemberNumStatusLabel.Location = new System.Drawing.Point(57, 42);
            this.currentRoomMemberNumStatusLabel.Name = "currentRoomMemberNumStatusLabel";
            this.currentRoomMemberNumStatusLabel.Size = new System.Drawing.Size(29, 12);
            this.currentRoomMemberNumStatusLabel.TabIndex = 10;
            this.currentRoomMemberNumStatusLabel.Text = "none";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "人数";
            // 
            // currentRoomNameLabel
            // 
            this.currentRoomNameLabel.AutoSize = true;
            this.currentRoomNameLabel.Location = new System.Drawing.Point(57, 21);
            this.currentRoomNameLabel.Name = "currentRoomNameLabel";
            this.currentRoomNameLabel.Size = new System.Drawing.Size(29, 12);
            this.currentRoomNameLabel.TabIndex = 8;
            this.currentRoomNameLabel.Text = "none";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "部屋名";
            // 
            // currentRoomMemberListBox
            // 
            this.currentRoomMemberListBox.BackColor = System.Drawing.Color.White;
            this.currentRoomMemberListBox.FormattingEnabled = true;
            this.currentRoomMemberListBox.ItemHeight = 12;
            this.currentRoomMemberListBox.Location = new System.Drawing.Point(11, 84);
            this.currentRoomMemberListBox.Name = "currentRoomMemberListBox";
            this.currentRoomMemberListBox.ScrollAlwaysVisible = true;
            this.currentRoomMemberListBox.Size = new System.Drawing.Size(265, 76);
            this.currentRoomMemberListBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.createRoomButton);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.roomNameTextBox);
            this.groupBox5.Location = new System.Drawing.Point(12, 393);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(282, 75);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "部屋作成";
            // 
            // createRoomButton
            // 
            this.createRoomButton.Location = new System.Drawing.Point(201, 43);
            this.createRoomButton.Name = "createRoomButton";
            this.createRoomButton.Size = new System.Drawing.Size(75, 23);
            this.createRoomButton.TabIndex = 7;
            this.createRoomButton.Text = "作成";
            this.createRoomButton.UseVisualStyleBackColor = true;
            this.createRoomButton.Click += new System.EventHandler(this.createRoomButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "部屋名";
            // 
            // roomNameTextBox
            // 
            this.roomNameTextBox.Location = new System.Drawing.Point(54, 18);
            this.roomNameTextBox.Name = "roomNameTextBox";
            this.roomNameTextBox.Size = new System.Drawing.Size(222, 19);
            this.roomNameTextBox.TabIndex = 0;
            // 
            // reportLabel
            // 
            this.reportLabel.AutoSize = true;
            this.reportLabel.Location = new System.Drawing.Point(43, 481);
            this.reportLabel.Name = "reportLabel";
            this.reportLabel.Size = new System.Drawing.Size(29, 12);
            this.reportLabel.TabIndex = 13;
            this.reportLabel.Text = "none";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 481);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "報告";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 514);
            this.Controls.Add(this.reportLabel);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "TinyChat";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portNumTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button roomInButton;
        private System.Windows.Forms.ListBox roomListBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.TextBox sendMessageTextBox;
        private System.Windows.Forms.TextBox resiveMessageTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label currentRoomMemberNumStatusLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentRoomNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox currentRoomMemberListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label selectedRoomIDLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button createRoomButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox roomNameTextBox;
        private System.Windows.Forms.Label reportLabel;
        private System.Windows.Forms.Label label10;
    }
}

