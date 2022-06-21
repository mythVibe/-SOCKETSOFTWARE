using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public static Socket ServerSocket;
        public static Socket socket;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress IP = IPAddress.Parse(textBox_Addr.Text);
            int Port = int.Parse(textBox_Port.Text);
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            richTextBox_Recieve.Text += "正在连接...\n";

            IPAddress IP = IPAddress.Parse(textBox_Addr.Text);
            int Port = int.Parse(textBox_Port.Text);

            //IPAddress ip = IPAddress.Any;
            IPEndPoint iPEndPoint = new IPEndPoint(IP, Port);

            try
            {
                //2.使用Bind()进行绑定
                ServerSocket.Bind(iPEndPoint);

                ServerSocket.Listen(10);

                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start(ServerSocket);
            }
            catch
            {
                Console.WriteLine("111");
            }
            
        }

        void Listen(object sk)
        {
            Socket socketLis = sk as Socket;

            while (true)
            {
                try
                {
                    Socket socketSed = socketLis.Accept();
                    richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "连接成功\n";

                    Thread th = new Thread(Recieve);
                    th.IsBackground = true;
                    th.Start(socketSed);
                }
                catch
                {
                    MessageBox.Show("出问题了");
                }
            }
        }

        void Recieve(object sk)
        {
            socket = sk as Socket;

            while (true)
            {
                byte[] recieve = new byte[1024];
                int len = socket.Receive(recieve);
                richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "发送：";
                if (len > 0)
                {
                    richTextBox_Recieve.Text += Encoding.ASCII.GetString(recieve);
                    richTextBox_Recieve.Text += "\r\n";
                }
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            byte[] send = new byte[1024];
            send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);
            socket.Send(send);
            richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "发送：" + richTextBox_Send.Text + "\n";
        }
    }
}
