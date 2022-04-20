
namespace WifiDirectApplication
{
    partial class Client_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client_Form));
            this.btn_connect = new System.Windows.Forms.Button();
            this.lbl_toconnect = new System.Windows.Forms.Label();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.lbl_port = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.lbl_connect = new System.Windows.Forms.Label();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.txt_tosend = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(12, 78);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // lbl_toconnect
            // 
            this.lbl_toconnect.AutoSize = true;
            this.lbl_toconnect.Location = new System.Drawing.Point(13, 13);
            this.lbl_toconnect.Name = "lbl_toconnect";
            this.lbl_toconnect.Size = new System.Drawing.Size(107, 12);
            this.lbl_toconnect.TabIndex = 1;
            this.lbl_toconnect.Text = "server to connect ";
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Location = new System.Drawing.Point(13, 54);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(28, 12);
            this.lbl_ip.TabIndex = 2;
            this.lbl_ip.Text = "IP : ";
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(284, 54);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(46, 12);
            this.lbl_port.TabIndex = 2;
            this.lbl_port.Text = "PORT :";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(47, 51);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(213, 21);
            this.txt_ip.TabIndex = 3;
            this.txt_ip.Text = "192.168.0.150";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(336, 51);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(213, 21);
            this.txt_port.TabIndex = 3;
            this.txt_port.Text = "80";
            // 
            // lbl_connect
            // 
            this.lbl_connect.AutoSize = true;
            this.lbl_connect.Location = new System.Drawing.Point(93, 83);
            this.lbl_connect.Name = "lbl_connect";
            this.lbl_connect.Size = new System.Drawing.Size(106, 12);
            this.lbl_connect.TabIndex = 4;
            this.lbl_connect.Text = "unable to connect";
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(12, 108);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(537, 118);
            this.txt_log.TabIndex = 5;
            // 
            // txt_tosend
            // 
            this.txt_tosend.Location = new System.Drawing.Point(12, 232);
            this.txt_tosend.Multiline = true;
            this.txt_tosend.Name = "txt_tosend";
            this.txt_tosend.Size = new System.Drawing.Size(537, 35);
            this.txt_tosend.TabIndex = 5;
            this.txt_tosend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_tosend_KeyDown);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 274);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(776, 232);
            this.listBox1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(555, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "post to server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(602, 13);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 9;
            this.btn_browse.Text = "browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "D:\\a.png";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(735, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "get from server";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(759, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(218, 21);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "test/1.jpg";
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 515);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txt_tosend);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.lbl_connect);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.lbl_port);
            this.Controls.Add(this.lbl_ip);
            this.Controls.Add(this.lbl_toconnect);
            this.Controls.Add(this.btn_connect);
            this.Name = "Client_Form";
            this.Text = "  ";
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label lbl_toconnect;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label lbl_connect;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.TextBox txt_tosend;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
    }
}