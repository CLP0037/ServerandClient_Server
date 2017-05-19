namespace ServerandClient_Server
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.listBoxOnlineList = new System.Windows.Forms.ListBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_call = new System.Windows.Forms.Button();
            this.btn_time = new System.Windows.Forms.Button();
            this.btn_menu = new System.Windows.Forms.Button();
            this.btn_file = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_excute = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(39, 359);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(852, 125);
            this.textBox3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "客户端信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "通讯详细信息";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "启动服务";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 511);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "服务器:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(90, 508);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(796, 36);
            this.textBox4.TabIndex = 8;
            this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(800, 554);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 33);
            this.button2.TabIndex = 9;
            this.button2.Text = "发送信息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(90, 23);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(150, 21);
            this.textBox_IP.TabIndex = 10;
            this.textBox_IP.Text = "127.0.0.1";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(90, 49);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(150, 21);
            this.textBox_Port.TabIndex = 11;
            this.textBox_Port.Text = "10850";
            // 
            // listBoxOnlineList
            // 
            this.listBoxOnlineList.FormattingEnabled = true;
            this.listBoxOnlineList.ItemHeight = 12;
            this.listBoxOnlineList.Location = new System.Drawing.Point(39, 217);
            this.listBoxOnlineList.Name = "listBoxOnlineList";
            this.listBoxOnlineList.ScrollAlwaysVisible = true;
            this.listBoxOnlineList.Size = new System.Drawing.Size(852, 112);
            this.listBoxOnlineList.TabIndex = 12;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 109);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(627, 70);
            this.textBox1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "FlagInfo";
            // 
            // btn_call
            // 
            this.btn_call.Location = new System.Drawing.Point(700, 16);
            this.btn_call.Name = "btn_call";
            this.btn_call.Size = new System.Drawing.Size(86, 33);
            this.btn_call.TabIndex = 15;
            this.btn_call.Text = "总召";
            this.btn_call.UseVisualStyleBackColor = true;
            this.btn_call.Click += new System.EventHandler(this.btn_call_Click);
            // 
            // btn_time
            // 
            this.btn_time.Location = new System.Drawing.Point(700, 64);
            this.btn_time.Name = "btn_time";
            this.btn_time.Size = new System.Drawing.Size(86, 33);
            this.btn_time.TabIndex = 16;
            this.btn_time.Text = "对时";
            this.btn_time.UseVisualStyleBackColor = true;
            this.btn_time.Click += new System.EventHandler(this.btn_time_Click);
            // 
            // btn_menu
            // 
            this.btn_menu.Location = new System.Drawing.Point(700, 156);
            this.btn_menu.Name = "btn_menu";
            this.btn_menu.Size = new System.Drawing.Size(86, 33);
            this.btn_menu.TabIndex = 17;
            this.btn_menu.Text = "召目录";
            this.btn_menu.UseVisualStyleBackColor = true;
            this.btn_menu.Click += new System.EventHandler(this.btn_menu_Click);
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(808, 156);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(86, 33);
            this.btn_file.TabIndex = 18;
            this.btn_file.Text = "召文件";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(700, 109);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(86, 33);
            this.btn_select.TabIndex = 19;
            this.btn_select.Text = "遥控选择";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_excute
            // 
            this.btn_excute.Location = new System.Drawing.Point(808, 109);
            this.btn_excute.Name = "btn_excute";
            this.btn_excute.Size = new System.Drawing.Size(86, 33);
            this.btn_excute.TabIndex = 20;
            this.btn_excute.Text = "遥控执行";
            this.btn_excute.UseVisualStyleBackColor = true;
            this.btn_excute.Click += new System.EventHandler(this.btn_excute_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(913, 109);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(86, 33);
            this.btn_cancel.TabIndex = 21;
            this.btn_cancel.Text = "遥控取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 603);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_excute);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.btn_file);
            this.Controls.Add(this.btn_menu);
            this.Controls.Add(this.btn_time);
            this.Controls.Add(this.btn_call);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBoxOnlineList);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.ListBox listBoxOnlineList;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_call;
        private System.Windows.Forms.Button btn_time;
        private System.Windows.Forms.Button btn_menu;
        private System.Windows.Forms.Button btn_file;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_excute;
        private System.Windows.Forms.Button btn_cancel;
    }
}

