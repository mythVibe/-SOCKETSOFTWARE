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

namespace Client
{
    public partial class Form1 : Form
    {
        public static Socket ClientSocket;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            IPAddress IP = IPAddress.Parse(textBox_Addr.Text);
            int Port = int.Parse(textBox_Port.Text);

            IPEndPoint iPEndPoint = new IPEndPoint(IP, Port);

            try
            {
                ClientSocket.Connect(iPEndPoint);
                richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "已连接" + "\n";

                Thread th = new Thread(Recieve);
                th.IsBackground = true;
                th.Start(ClientSocket);
            }
            catch
            { 
                
            }

        }

        void Recieve(object sk)
        {
            Socket socket = sk as Socket;
            while(true)
            {
                byte[] recieve = new byte[1024];
                int len = socket.Receive(recieve);
                if (len > 0)
                {
                    richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "接收：" + Encoding.ASCII.GetString(recieve);
                    richTextBox_Recieve.Text += "\r\n";
                }
            }  
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            byte[] send = new byte[1024];
            send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);
            ClientSocket.Send(send);
            richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ")+ "发送：" + richTextBox_Send.Text + "\n";
        }
    }
}
