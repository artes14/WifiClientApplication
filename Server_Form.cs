using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows;

namespace WifiDirectApplication
{
    public partial class Server_Form : Form
    {
        public Server_Form()
        {
            InitializeComponent();
        }

        private string ip = "127.0.0.10";
        private int port = 11;
        private Thread listenThread;
        private Thread receiveThread;
        private Socket clientSocket;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            Client_Form form = new Client_Form();
            form.Owner = this;
            form.Show();
            form.Activate();
        }


        /*
         * 
         * 데스크톱 앱의 경우 Wi-Fi Direct 기능을 사용하려면 이전에 사용자가 Windows 페어링 환경 사용자 인터페이스와 Wi-FI Direct 
         * 디바이스를 페어링해야 합니다. 이 페어링이 완료되면 Wi-Fi Direct 함수를 사용하여 Wi-Fi Direct 세션을 시작하여 Wi-Fi Direct 
         * 디바이스 간에 연결을 설정할 수 있는 프로필이 저장됩니다.
         * Wi-Fi Direct를 사용하려면 앱이 먼저 WFDOpenHandle 함수를 호출하여 Wi-Fi Direct 서비스에 대한 핸들을 얻어야 합니다. 
         * WFDOpenHandle 함수에서 반환된 WFD(Wi-Fi Direct) 핸들은 Wi-Fi Direct 서비스에 대한 후속 Wi-Fi Direct 함수 호출에 사용됩니다.
         * WFDStartOpenSession 함수는 비동기 작업을 시작하여 특정 Wi-Fi Direct 디바이스에 대한 주문형 연결을 시작합니다. 
         * 대상 Wi-Fi 디바이스는 이전에 Windows 페어링 환경을 통해 페어링되어야 합니다. 비동기 작업이 완료되면 pfnCallback 
         * 매개 변수에 지정된 콜백 함수가 호출됩니다.
         * Wi-Fi Direct 서비스를 사용하여 애플리케이션이 완료되면 애플리케이션은 WFDCloseHandle 함수를 호출하여 
         * Wi-Fi Direct 서비스에 애플리케이션이 서비스를 사용하여 수행되었음을 신호로 보내야 합니다. 
         * 이렇게 하면 Wi-Fi Direct 서비스에서 애플리케이션에서 사용하는 리소스를 해제할 수 있습니다.
         * 
         */

        private void log(string msg)
        {
            this.Invoke(new Action(delegate ()
            {
                listBox1.Items.Add(string.Format("[{0}]{1}", DateTime.Now.ToString(), msg));

            }));
        }
        private bool image_sending=false;

        private void btn_send_Click(object sender, EventArgs e)
        {
            this.image_sending = true;

            //byte[] sendBuffer = Encoding.UTF8.GetBytes(txt_tosend.Text.Trim());
            //clientSocket.Send(sendBuffer);
            Byte[] _data = ImageToByteArray(this.pictureBox1.Image);
            clientSocket.Send(BitConverter.GetBytes(_data.Length));
            clientSocket.Send(_data);
            /* 
             * var im = new Bitmap(pictureBox1.Image);
            byte[] imArr = im.ToByteArray(ImageFormat.Bmp);
            string base64text = Convert.ToBase64String(imArr);
            for (int i = 0; i < base64text.Length / 16 + 1; i++)
            {
                byte[] sendBuffer = Encoding.UTF8.GetBytes(base64text.Substring(i * 16 , 16));
                clientSocket.Send(sendBuffer);
                //tcp.GetStream().Write(sendBuffer, 0, sendBuffer.Length);
                Thread.Sleep(1);
                //ShowMsg("client --> " + Encoding.UTF8.GetString(sendBuffer));
            }
            //socket.Send(sendBuffer);
            */
            log("image sent");
            //ShowMsg("client --> " + base64text);
            txt_tosend.Text = ""; // 초기화
        }
        public byte[] ImageToByteArray(System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }


        private bool start = false;
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                start = true;
                log("Server started!!");
                lbl_server_state.Text = "서버 활성화됨";
                listenThread = new Thread(new ThreadStart(Listen));
                listenThread.IsBackground = true;

                listenThread.Start();
            }
            else
            {
                start = false;
                lbl_server_state.Text = "서버 비활성";
                log("Server halted!!!");
            }
        }
        private void Listen()
        {

            // IP 주소 문자열을 IPAddress 인스턴스로 변환
            IPAddress ipaddress = IPAddress.Parse(ip);

            // 네트워크 끝점(종단점)을 IP주소 및 포트번호로 나타냄
            IPEndPoint endPoint = new IPEndPoint(ipaddress, port);

            // 소켓 생성
            Socket listenSocket = new Socket(
                // Socket 클래스의 인스턴스가 사용할 수 있는 주소지정 체계 지정
                AddressFamily.InterNetwork,
                SocketType.Stream,              // 소켓 유형 지정
                ProtocolType.Tcp                // 프로토콜 지정
                );

            // Socket을 endPoint와 연결(IP주소, 포트번호 할당)
            listenSocket.Bind(endPoint);

            // Socket을 수신 상태로 둔다.(연결 가능한 상태)
            // 클라이언트에 의한 연결 요청이 수신될때까지 기다린다.
            listenSocket.Listen(20);

            log("Accessing client");

            // 연결 요청에 대한 수락
            clientSocket = listenSocket.Accept();

            log("client connected - " + clientSocket.LocalEndPoint.ToString());

            // Receive 스레드 호출
            receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.IsBackground = true;
            receiveThread.Start();      // Receive() 호출
        }

        private void Receive()
        {
            while (true)
            {
                // 연결된 클라이언트가 보낸 데이터 수신
                byte[] receiveBuffer = new byte[512];
                int length = clientSocket.Receive(receiveBuffer,
                    receiveBuffer.Length, SocketFlags.None);

                // 엔터 처리
                //richTextBox1.AppendText(msg);

                // 디코딩
                string msg = Encoding.UTF8.GetString(receiveBuffer);

                //
                Showmsg("client --> " + msg);
                log("message received");
            }
        }

        // 송수신 메시지를 대화창에 출력
        private void Showmsg(string msg)
        {
            this.Invoke(new Action(delegate ()
            {
                // richTextBOX에서 개행이 정상적으로 작용되지 않으면
                // 아래처럼 따로따로
                txt_send.AppendText(msg);
                txt_send.AppendText("\r\n");
                // 입력된 텍스트에 맞게 스크롤을 내려준다.
                this.Activate();
                txt_send.Focus();

                // 캐럿(커서)를 텍스트박스의 끝으로 내려준다.
                txt_send.SelectionStart = txt_send.Text.Length;
                txt_send.ScrollToCaret();   // 스크럴을 캐럿(커서)위치에 맞춰준다.
            }));

        }

        private void txt_tosend_KeyDown(object sender, KeyEventArgs e)
        {
            // 메시지 전송
            if (txt_tosend.Text.Trim() != "" && e.KeyCode == Keys.Enter)
            {
                byte[] sendBuffer = Encoding.UTF8.GetBytes(txt_tosend.Text.Trim());
                clientSocket.Send(sendBuffer);
                log("message sent");
                Showmsg("server --> " + txt_tosend.Text);
                txt_tosend.Text = ""; // 초기화
                txt_tosend.Focus();
            }
        }
    }
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }
    }
}
