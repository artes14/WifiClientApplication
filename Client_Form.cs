using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Authenticators;
using RestSharp.Extensions;
using System.Net.Http;

namespace WifiDirectApplication
{
    public partial class Client_Form : Form
    {
        public Client_Form()
        {
            InitializeComponent();
        }
        public void Client_Load(object sender, EventArgs e)
        {
            txt_ip.Focus();
            log("클라이언트 로드됨!!");
        }
        private Socket socket;  // 소켓
        private Thread receiveThread;
        private void log(string msg)
        {
            this.Invoke(new Action(delegate ()
            {
                listBox1.Items.Add(string.Format("[{0}]{1}", DateTime.Now.ToString(), msg));

            }));
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            IPAddress ipaddress = IPAddress.Parse(txt_ip.Text);
            IPEndPoint endPoint = new IPEndPoint(ipaddress, int.Parse(txt_port.Text));
            socket = new Socket(

                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );

            // 연결하기
            log("accessing server");
            socket.Connect(endPoint);
            log("connected to server");


            // Receive 스레드 처리(서버 <--> 클라이언트)
            receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }
        private void Receive()
        {

            while (true)
            {
                /*
                Byte[] _data = new byte[256];
                socket.Receive(_data);
                int iLength = BitConverter.ToInt32(_data, 0);

                Byte[] _data2 = new byte[iLength];
                socket.Receive(_data2);

                this.pictureBox1.Image = byteArrayToImage(_data2);
                */
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void ShowMsg(string msg)
        {
            this.Invoke(new Action(delegate ()
            {
                // richTextBox에서 개행이 정상적으로 작용되지 않으면
                // 아래처럼 따로따로
                txt_log.AppendText(msg);
                txt_log.AppendText("\r\n");

                // 입력된 텍스트에 맞게 스크롤을 내려준다.
                this.Activate();
                txt_log.Focus();

                // 캐럿(커서)를 텍스트박스의 끝으로 내려준다.
                txt_log.SelectionStart = txt_log.Text.Length;
                txt_log.ScrollToCaret();   // 스크럴을 캐럿(커서)위치에 맞춰준다.

            }));
        }

        private void txt_tosend_KeyDown(object sender, KeyEventArgs e)
        {
            // 메시지 전송하기(공백이 아니고, Enter 눌렀을때)
            if (txt_tosend.Text.Trim() != "" && e.KeyCode == Keys.Enter)
            {

                string request = "POST / HTTP/1.1\r\nHost:" + txt_ip.Text + "/post?" + txt_tosend.Text + "\r\n";
                Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
                Byte[] bytesReceived = new Byte[256];
                socket.Send(bytesSent, bytesSent.Length, 0);
                log("message sent");
                ShowMsg("client --> " + txt_tosend.Text);
                txt_tosend.Text = ""; // 초기화
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uri = "http://192.168.0.150/fuploadTest";
            string fileName = label1.Text;
            string uploadfName = Path.GetFileName(fileName);
            var client = new WebClient();
            try
            {
                client.Headers.Add("filename", System.IO.Path.GetFileName(fileName));
                var data = System.IO.File.ReadAllBytes(fileName);
                client.UploadFile(uri, fileName); // 스레드 막음
                //client.UploadDataAsync(new System.Uri(uri), data);  //스레드 막지않음
                log("upload done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btn_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    label1.Text = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uri = "http://192.168.0.150/download";
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(uri+ "?download="+textBox1.Text, @"d:\myfile.jpg");
            }
                pictureBox1.Image = Image.FromFile(@"d:\myfile.jpg");

        }
    }
}
