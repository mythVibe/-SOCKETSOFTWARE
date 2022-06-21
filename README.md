# -SOCKETSOFTWARE
C#开发的socket软件工具


# 一、Socket套接字

## Socket的定义

**套接字(Socket)**，是对网络中**不同主机上的应用进程**之间进行双向通信的**端点的抽象**。一个套接字就是网络上进程通信的一端，提供了应用层进程利用网络协议交换数据的机制。从所处的**地位**来讲，套接字**上联应用进程，下联网络协议栈**，是应用程序通过网络协议进行通信的接口，是应用程序与网络协议栈进行**交互的接口**，Socket所处的位置大概是下面这样的。
![在这里插入图片描述](https://img-blog.csdnimg.cn/95658607a00441d0a119e6e6a99a85bf.png?x-oss-process=image/watermark,type_d3F5LXplbmhlaQ,shadow_50,text_Q1NETiBA5Z2a5by655qE5aS05Y-R,size_20,color_FFFFFF,t_70,g_se,x_16#pic_center)
![五层架构使用的协议](https://img-blog.csdnimg.cn/7350f689a0ad44fab067fc52115f9e7c.png?)
我们可以将Socket联想成是由两个Socket对象搭建的成的一根**通信管道**，管道的两端是这两个Socket对象，而这根管道的连接的是两台主机的**应用进程**。假设A、B两台主机上的应用进程要互相发送数据，那么我们就可以用Socket打造一条连接A、B主机进程的管道，A主机进程使用Socket对象把数据往管道里面一丢，然后B主机进程就可以使用Socket对象把数据给拿出来，反之当B主机进程要给A主机进程发送数据的时候也是通过操作Socket对象就可以简单实现数据的发送和接收。
![在这里插入图片描述](https://img-blog.csdnimg.cn/50c34367d73049099ee72ebe070b9fb9.png?x-oss-process=image/watermark,type_d3F5LXplbmhlaQ,shadow_50,text_Q1NETiBA5Z2a5by655qE5aS05Y-R,size_20,color_FFFFFF,t_70,g_se,x_16)
学过计算机网络的同学都知道数据在因特网上传输并不像上面说的那么简单，根据经典的五层协议体系结构（如下图），一个报文从一个进程传输到另一个进程需要经过**自上到下层层协议的封装**，然后转换成比特流通过物理层，途径多个路由，最后才能到到达目的主机【这里要用到的IP来标定网络上特定的主机】，然后再在目的主机上经过层层解析最终根据端口号把报文传输到目的进程，而使用Socket就不需要我们自己层层封装信息，也不用管信息是如何在网络上传输的，我们只需要**绑定IP地址和应用进程号**，使用Socket对象就可以实现进程之间数据的发送和接收，大大缩减了我们的工作，非常的nice。
【[这里推荐一个计算机网络课程，图文并茂讲计算机网络巨通俗易懂](https://www.bilibili.com/video/BV1c4411d7jb?share_source=copy_web)】
https://www.bilibili.com/video/BV1c4411d7jb?share_source=copy_web
![计算机网络体系](https://img-blog.csdnimg.cn/8a526aa224234a76ae63a9c974cee9d0.png?)

# 二、Socket编程

> 通过上面的简单介绍，我们能大致了解Socket的作用是完成两个应用程序之间的数据传输，我们只要知道要通信的两台主机的**IP地址**和进程的**端口号**，然后可以用Socket让这两个进程进行通信，接下来我们就进入正题，使用C#进行Socket编程，完成本地两个进程的通信

## 1.**效果展示**

![在这里插入图片描述](https://img-blog.csdnimg.cn/1c907224b10e4e489460b5a9136d9623.gif#pic_center)

## 2.Socket通信基本流程图

![在这里插入图片描述](https://img-blog.csdnimg.cn/16d0ace560584ca19007a9d3d1865869.png?x-oss-process=image/watermark,type_d3F5LXplbmhlaQ,shadow_50,text_Q1NETiBA5Z2a5by655qE5aS05Y-R,size_20,color_FFFFFF,t_70,g_se,x_16#pic_center)
根据上面的流程图可以知道使用socket实现通信大致需要完成以下几个步骤：
**服务器端：**
第一步：建立一个用于通信的Socket对象
第二步：使用bind绑定IP地址和端口号
第三步：使用listen监听客户端
第四步：使用accept中断程序直到连接上客户端
第五步：接收来自客户端的请求
第六步：返回客户端需要的数据
第七步：如果接收到客户端已关闭连接信息就关闭服务器端

**客户端：**
第一步：建立一个用于通信的Socket对象
第二步：根据指定的IP和端口connet服务器
第三步：连接成功后向服务器端发送数据请求
第四步：接收服务器返回的请求数据
第五步：如果还需要请求数据继续发送请求
第六步：如果不需要请求数据就关闭客户端并给服务器发送关闭连接信息

## 3.Socket编程常用类和方法

### *相关类*

  **(1) IPAddress：包含了一个IP地址**[提供 Internet 协议 (IP) 地址]

 ```c#
//这里的IP是long类型的,这里使用Parse()可以将string类型数据转成IPAddress所需要的数据类型
IPAddress IP = IPAddress.Parse();
 ```

  **(2) IPEndPoint：包含了一对IP地址和端口号**

```c#
/*public IPEndPoint(IPAddress address, int port);*/
IPEndPoint endPoint = new IPEndPoint(ip,port);	//处理IP地址和端口的封装类
```

**(3)Encoding.ASCII:编码转换**

 ```c#
Encoding.ASCII.GetBytes()	//将字符串转成字节
Encoding.ASCII.GetString()	//将字节转成字符串
 ```

**（4）获取当前时间**

```csharp
DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ")
```


### Socket编程函数【作用+示例】：

#### **(1)Socket()**

- **创建Socket对象，构造函数需要输入三个参数，创建客户端和服务器端Socket对象示例如下**

```c#
Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
```

> Socket构造函数参数
>
> - **AddressFamily**指定Socket用来解析地址的寻址方案
> - **SocketType**定义要打开的Socket的类型
> - **ProtocolType**:向Windows Sockets API通知所请求的协议

#### **(2)Bind()**

- **绑定一个本地的IP和端口号，参数是一个绑定了IP和端口号的IPEndPoint对象**

```c#
ServerSocket.Bind(new IPEndPoint(ip,port));
或者
IPEndPoint ipEndPoint = new IPEndPoint(ip,port)
ServerSocket.Bind(ipEndPoint);
```

  #### **(3)Listen()**

- **让Socket侦听传入的连接，参数为指定侦听队列的容量，**

`````c#
ServerSocket.Listen(10);
`````

  #### **(4)Connect()**

- **建立与远程主机的连接**

`````c#
ClientSocket.Connect(ipEndPoint);
`````

  #### **(5)Accept（）**

- **接收连接并返回一个新的Socket,Accept会中断程序，直到有客户端连接**

`````c#
Socket socket = ServerSocket.Accept();
`````

  #### **(6)Send（）**

- **输出数据到Socket**

```c#
//Encoding.ASCII.GetBytes()将字符串转成字节
byte[] message = Encoding.ASCII.GetBytes("Connect the Server"); //通信时实际发送的是字节数组，所以要将发送消息转换字节
ClientSocket.Send(message);
socket.Send(message);
```

  #### **(7)Receive()**

- **从Socket中读取数据**

```c#
byte[] receive = new byte[1024];
int length = ClientSocket.Receive(receive); // length 接收字节数组长度
int length = socket.Receive(receive);
```

  #### **(8)Close()**

- **关闭Socket，销毁连接**

```c#
socket.Close()
ClientSocket.Close()
```

|     类型     |              函数              |
| :----------: | :----------------------------: |
| 服务器socket | Bind()<br>Listen()<br>Accept() |
| 客户端socket |           Connect()            |
|  公共socket  | Receive()<br>Send()<br>Close() |


## 4.编程实现步骤

### （1）UI设计

**服务器端：**
![在这里插入图片描述](https://img-blog.csdnimg.cn/abc2219cb4b84beeb4d9e740f9549d7b.png?x-oss-process=image/watermark,type_d3F5LXplbmhlaQ,shadow_50,text_Q1NETiBA5Z2a5by655qE5aS05Y-R,size_20,color_FFFFFF,t_70,g_se,x_16)
**客户端：**
![在这里插入图片描述](https://img-blog.csdnimg.cn/f0db4377024a413384eade3effa5f00f.png?x-oss-process=image/watermark,type_d3F5LXplbmhlaQ,shadow_50,text_Q1NETiBA5Z2a5by655qE5aS05Y-R,size_20,color_FFFFFF,t_70,g_se,x_16)
下面是我给各组件设置的name值，客户端和服务器端除了Button有一个不一样其他组件设置的name值都是一样的

| 组件            | Name                                                         |
| --------------- | ------------------------------------------------------------ |
| **TextBox**     | textBox_Addr <br> textBox_Port                               |
| **RichTextBox** | richTextBox_Receive<br>richTextBox_Send                      |
| **Button**      | button_Accpet<br>button_Connect<br>button_Close<br>button_Send |


###  （2）服务器端：

**实现步骤：**
第一步：创建一个用于监听连接的Socket对象；

```csharp
Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);     //创建用于监听连接的套接字
```

第二步：用指定的端口号和服务器的ip建立一个IPEndPoint对象；

```csharp
IPAddress IP = IPAddress.Parse(textBox_Addr.Text);	//获取输入的IP地址
int Port = int.Parse(textBox_Port.Text);	//获取输入的端口号
//IPAddress ip = IPAddress.Any;
IPEndPoint iPEndPoint = new IPEndPoint(IP, Port);	
```

第三步：用socket对象的Bind()方法绑定IPEndPoint；

```csharp
ServerSocket.Bind(iPEndPoint);
```

第四步：用socket对象的Listen()方法开始监听；

```csharp
ServerSocket.Listen(10);
```

第五步：建立与客户端的连接，用socket对象的Accept()方法创建用于和客户端进行通信的socket对象;（因为accept会中断程序，所以我使用线程来实现客户端的接入）

```csharp
Socket socket = socketAccept.Accept();
```

第六步：接收来自客户端的信息（我是使用线程来实现数据的接收）

```csharp
byte[] recieve = new byte[1024];
int len = socket.Receive(recieve);
richTextBox_Recieve.Text += Encoding.ASCII.GetString(recieve, 0, len);  //将字节数据根据ASCII码转成字符串
```

第七步：向客户端发送信息

```csharp
byte[] send = new byte[1024];
send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);    //将字符串转成字节格式发送
socket.Send(send);  //调用Send()向客户端发送数据
```

第八步：关闭Socket

```csharp
socket.Close();     //关闭用于通信的套接字          
ServerSocket.Close();   //关闭用于连接的套接字
socketAccept.Close();   //关闭与客户端绑定的套接字
th1.Abort();    //关闭线程1
```

**具体实现代码：**
（1）因为有使用线程，为了防止出错，在初始化的时候关闭检测

```csharp
private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;    //执行新线程时跨线程资源访问检查会提示报错，所以这里关闭检测
        }
```

（2）建立连接，首先创建一个ServerSocket将连接需要的参数都设置好并监听连接，然后创建线程Accept客户的连接

```csharp
 		/*****************************************************************/
        #region 连接客户端（绑定按钮事件）
        private void button_Accpet_Click(object sender, EventArgs e)
        {

            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);     //创建用于通信的套接字
            
            richTextBox_Receive.Text += "正在连接...\n";
            button_Accpet.Enabled = false;  //禁止操作接收按钮
           
            //1.绑定IP和Port
            IPAddress IP = IPAddress.Parse(textBox_Addr.Text);
            int Port = int.Parse(textBox_Port.Text);

            //IPAddress ip = IPAddress.Any;
            IPEndPoint iPEndPoint = new IPEndPoint(IP, Port);

            try
            {
                //2.使用Bind()进行绑定
                ServerSocket.Bind(iPEndPoint);
                //3.开启监听
                //Listen(int backlog); backlog:监听数量 
                ServerSocket.Listen(10);

                /*
                 * tip：
                 * Accept会阻碍主线程的运行，一直在等待客户端的请求，
                 * 客户端如果不接入，它就会一直在这里等着，主线程卡死
                 * 所以开启一个新线程接收客户单请求
                 */

                //开启线程Accept进行通信的客户端socket
                th1 = new Thread(Listen);   //线程绑定Listen函数
                th1.IsBackground = true;    //运行线程在后台执行
                th1.Start(ServerSocket);    //Start里面的参数是Listen函数所需要的参数，这里传送的是用于通信的Socket对象
                Console.WriteLine("1");
            }
            catch
            {
                MessageBox.Show("服务器出问题了");
            }
        }
        #endregion
        /*****************************************************************/

		/*****************************************************************/
        #region 建立与客户端的连接
        void Listen(Object sk) 
        {
            socketAccept = sk as Socket;    //创建一个与客户端对接的套接字
            
            try
            {
               while (true) 
               {
                   //GNFlag如果为1就进行中断连接，使用在标志为是为了保证能够顺利关闭服务器端
                   /*
                    * 当客户端关闭一次后，如果没有这个标志位会使得服务器端一直卡在中断的位置
                    * 如果服务器端一直卡在中断的位置就不能顺利关闭服务器端
                    */

                    //4.阻塞到有client连接
                    socket = socketAccept.Accept();

                    CFlag = 0;  //连接成功，将客户端关闭标志设置为0
                    SFlag = 1;  //当连接成功，将连接成功标志设置为1

                    richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + textBox_Addr.Text + "连接成功";
                    richTextBox_Receive.Text += "\r\n";

                    //开启第二个线程接收客户端数据
                    th2 = new Thread(Receive);  //线程绑定Receive函数
                    th2.IsBackground = true;    //运行线程在后台执行
                    th2.Start(socket);    //Start里面的参数是Listen函数所需要的参数，这里传送的是用于通信的Socket对象
               }
            }
            catch 
            {
                //MessageBox.Show("没有连接上客户端");   
            }
        }
        #endregion
        /*****************************************************************/
```

（3）连接上客户端后，使用线程接收客户端数据，参数是Accept到的Socket对象

```csharp
/*****************************************************************/
        #region 接收客户端数据
        void Receive(Object sk)
        {
            socket = sk as Socket;  //创建用于通信的套接字

            while (true)
            {
                try
                {
                    if (CFlag == 0 && SFlag == 1)
                    {
                        //5.接收数据
                        byte[] recieve = new byte[1024];
                        int len = socket.Receive(recieve);

                        //6.打印接收数据
                        if (recieve.Length > 0)
                        {
                            //如果接收到客户端停止的标志
                            if (Encoding.ASCII.GetString(recieve, 0, len) == "*close*")
                            {
                                richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "客户端已退出" + "\n";
                                CFlag = 1;      //将客户端关闭标志设置为1

                                break;      //退出循环
                            }

                            //打印接收数据
                            richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "接收：";
                            richTextBox_Receive.Text += Encoding.ASCII.GetString(recieve, 0, len);  //将字节数据根据ASCII码转成字符串
                            richTextBox_Receive.Text += "\r\n";
                        }
                    }
                    else
                    {
                        break;  //跳出循环
                    } 
                }
                catch
                {
                    MessageBox.Show("收不到信息");
                }  
            }  
        }
        #endregion
        /*****************************************************************/
```

 （4）向客户端发送数据


```csharp
        /*****************************************************************/
        #region 向客户端发送数据
        private void button_Send_Click(object sender, EventArgs e)
        {
            //SFlag标志连接成功，同时当客户端是打开的时候才能发送数据
            if(SFlag == 1 && CFlag == 0)
            {
                byte[] send = new byte[1024];
                send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);    //将字符串转成字节格式发送
                socket.Send(send);  //调用Send()向客户端发送数据

                //打印发送时间和发送的数据
                richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "发送：";
                richTextBox_Receive.Text += richTextBox_Send.Text + "\n";
                richTextBox_Send.Clear();   //清除发送框
            } 
        }
        #endregion
        /*****************************************************************/
```

（5）关闭服务器端

```csharp
/*****************************************************************/
        #region 关闭服务器端
        private void button_Close_Click(object sender, EventArgs e)
        {
            //若连接上了客户端需要关闭线程2和socket，没连接上客户端直接关闭线程1和其他套接字
            if(CFlag == 1)
            {
                th2.Abort();        //关闭线程2
                socket.Close();     //关闭用于通信的套接字
            }
            
            ServerSocket.Close();   //关闭用于连接的套接字
            socketAccept.Close();   //关闭与客户端绑定的套接字
            th1.Abort();    //关闭线程1

            CFlag = 0;  //将客户端标志重新设置为0,在进行连接时表示是打开的状态
            SFlag = 0;  //将连接成功标志程序设置为0，表示退出连接
            button_Accpet.Enabled = true;
            richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ");
            richTextBox_Receive.Text += "服务器已关闭" + "\n";
            MessageBox.Show("服务器已关闭");
        }
        #endregion
        /*****************************************************************/
```

### （3）客户端：

第一步：建立一个Socket对象；

```csharp
Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);     //声明负责通信的套接字
```

第二步：用指定的端口号和服务器的ip建立一个IPEndPoint对象；

```csharp
IPAddress IP = IPAddress.Parse(textBox_Addr.Text);      //获取设置的IP地址
int Port = int.Parse(textBox_Port.Text);       //获取设置的端口号
IPEndPoint iPEndPoint = new IPEndPoint(IP,Port);    //指定的端口号和服务器的ip建立一个IPEndPoint对象
```

第三步：用socket对像的Connect()方法以上面建立的EndPoint对象做为参数，向服务器发出连接请求；

```csharp
ClientSocket.Connect(iPEndPoint);
```

第四步：如果连接成功，就用socket对象的Send()方法向服务器发送信息；

```csharp
byte[] send = new byte[1024];
send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);  //将文本内容转换成字节发送
ClientSocket.Send(send);    //调用Send()函数发送数据
```

第五步：用socket对象的Receive()方法接受服务器的信息 ;

```csharp
byte[] receive = new byte[1024];
ClientSocket.Receive(receive);  //调用Receive()接收字节数据
```

第六步：通信结束后关闭socket；

```csharp
ClientSocket.Close();   //关闭套接字
```

**具体代码实现**
（1）使用线程，为了防止出错，在初始化的时候关闭检测

```csharp
private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;    //执行新线程时跨线程资源访问检查会提示报错，所以这里关闭检测
        }
```

（2）建立与服务器端的连接

```csharp
/*****************************************************************/
        #region 连接服务器端
        private void button_Connect_Click(object sender, EventArgs e)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);     //声明负责通信的套接字
            
            richTextBox_Recieve.Text += "正在连接...\n";
            
            IPAddress IP = IPAddress.Parse(textBox_Addr.Text);      //获取设置的IP地址
            int Port = int.Parse(textBox_Port.Text);       //获取设置的端口号
            IPEndPoint iPEndPoint = new IPEndPoint(IP,Port);    //指定的端口号和服务器的ip建立一个IPEndPoint对象

            try
            {  
                ClientSocket.Connect(iPEndPoint);       //用socket对象的Connect()方法以上面建立的IPEndPoint对象做为参数，向服务器发出连接请求
                SFlag = 1;  //若连接成功将标志设置为1
                    
                richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + textBox_Addr.Text + "连接成功" + "\n";
                button_Connect.Enabled = false;     //禁止操作连接按钮
                
                //开启一个线程接收数据
                th1 = new Thread(Receive);
                th1.IsBackground = true;
                th1.Start(ClientSocket);    
            }
            catch 
            {
                MessageBox.Show("服务器未打开");
            }    
        }
        #endregion
        /*****************************************************************/
```

（3）若连接成功，创建线程实现接收服务器端的数据

```csharp
/*****************************************************************/
        #region 接收服务器端数据
        void Receive(Object sk)
        {
            Socket socketRec = sk as Socket;

            while (true)
            {
                //5.接收数据
                byte[] receive = new byte[1024];
                ClientSocket.Receive(receive);  //调用Receive()接收字节数据

                //6.打印接收数据
                if (receive.Length > 0)
                {
                    richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "接收：";   //打印接收时间
                    richTextBox_Recieve.Text += Encoding.ASCII.GetString(receive);  //将字节数据根据ASCII码转成字符串
                    richTextBox_Recieve.Text += "\r\n";
                }
            }
        }
        #endregion
        /*****************************************************************/
```

（4）向服务器端发送数据（于send按钮进行事件绑定）

```csharp
/*****************************************************************/
        #region 向服务器端发送数据
        private void button_Send_Click(object sender, EventArgs e)
        {
            //只有连接成功了才能发送数据，接收部分因为是连接成功才开启线程，所以不需要使用标志
            if (SFlag == 1)
            {
                byte[] send = new byte[1024];
                send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);  //将文本内容转换成字节发送
                ClientSocket.Send(send);    //调用Send()函数发送数据

                richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "发送：";   //打印发送数据的时间
                richTextBox_Recieve.Text += richTextBox_Send.Text + "\n";   //打印发送的数据
                richTextBox_Send.Clear();   //清空发送框
            }
        }
        #endregion
        /*****************************************************************/
```

（5）关闭客户端

```csharp
		/*****************************************************************/
        #region 关闭客户端
        private void buttonClose_Click(object sender, EventArgs e)
        {
            //保证是在连接状态下退出
            if (SFlag == 1)
            {
                byte[] send = new byte[1024];
                send = Encoding.ASCII.GetBytes("*close*");  //关闭客户端时给服务器发送一个退出标志
                ClientSocket.Send(send);
                
                th1.Abort();    //关闭线程
                ClientSocket.Close();   //关闭套接字
                
                button_Connect.Enabled = true;  //允许操作按钮
                SFlag = 0;  //客户端退出后将连接成功标志程序设置为0
                richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ");
                richTextBox_Recieve.Text += "客户端已关闭" + "\n";
                MessageBox.Show("已关闭连接");
            }
        }
        #endregion
        /*****************************************************************/
```

# 五、服务器端完整代码

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        //这里声明多个套接字是为了在连接，接收数据，发送数据的函数中不发生混乱，同时方便关闭
        public static Socket ServerSocket;    //声明用于监听的套接字
        public static Socket socketAccept;    //声明绑定了客户端的套接字   
        public static Socket socket;    //声明用于与某一个客户端通信的套接字
        
        public static int SFlag = 0;    //连接成功标志
        public static int CFlag = 0;    //客户端关闭的标志

        Thread th1;     //声明线程1
        Thread th2;     //声明线程2

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;    //执行新线程时跨线程资源访问检查会提示报错，所以这里关闭检测
        }

        /*****************************************************************/
        #region 连接客户端
        private void button_Accpet_Click(object sender, EventArgs e)
        {

            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);     //创建用于通信的套接字
            
            richTextBox_Receive.Text += "正在连接...\n";
            button_Accpet.Enabled = false;  //禁止操作接收按钮
           
            //1.绑定IP和Port
            IPAddress IP = IPAddress.Parse(textBox_Addr.Text);
            int Port = int.Parse(textBox_Port.Text);

            //IPAddress ip = IPAddress.Any;
            IPEndPoint iPEndPoint = new IPEndPoint(IP, Port);

            try
            {
                //2.使用Bind()进行绑定
                ServerSocket.Bind(iPEndPoint);
                //3.开启监听
                //Listen(int backlog); backlog:监听数量 
                ServerSocket.Listen(10);

                /*
                 * tip：
                 * Accept会阻碍主线程的运行，一直在等待客户端的请求，
                 * 客户端如果不接入，它就会一直在这里等着，主线程卡死
                 * 所以开启一个新线程接收客户单请求
                 */

                //开启线程Accept进行通信的客户端socket
                th1 = new Thread(Listen);   //线程绑定Listen函数
                th1.IsBackground = true;    //运行线程在后台执行
                th1.Start(ServerSocket);    //Start里面的参数是Listen函数所需要的参数，这里传送的是用于通信的Socket对象
                Console.WriteLine("1");
            }
            catch
            {
                MessageBox.Show("服务器出问题了");
            }
        }
        #endregion
        /*****************************************************************/

        /*****************************************************************/
        #region 建立与客户端的连接
        void Listen(Object sk) 
        {
            socketAccept = sk as Socket;    //创建一个与客户端对接的套接字
            
            try
            {
               while (true) 
               {
                   //GNFlag如果为1就进行中断连接，使用在标志为是为了保证能够顺利关闭服务器端
                   /*
                    * 当客户端关闭一次后，如果没有这个标志位会使得服务器端一直卡在中断的位置
                    * 如果服务器端一直卡在中断的位置就不能顺利关闭服务器端
                    */

                    //4.阻塞到有client连接
                    socket = socketAccept.Accept();

                    CFlag = 0;  //连接成功，将客户端关闭标志设置为0
                    SFlag = 1;  //当连接成功，将连接成功标志设置为1

                    richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + textBox_Addr.Text + "连接成功";
                    richTextBox_Receive.Text += "\r\n";

                    //开启第二个线程接收客户端数据
                    th2 = new Thread(Receive);  //线程绑定Receive函数
                    th2.IsBackground = true;    //运行线程在后台执行
                    th2.Start(socket);    //Start里面的参数是Listen函数所需要的参数，这里传送的是用于通信的Socket对象
               }
            }
            catch 
            {
                //MessageBox.Show("没有连接上客户端");   
            }
        }
        #endregion
        /*****************************************************************/

        /*****************************************************************/
        #region 接收客户端数据
        void Receive(Object sk)
        {
            socket = sk as Socket;  //创建用于通信的套接字

            while (true)
            {
                try
                {
                    if (CFlag == 0 && SFlag == 1)
                    {
                        //5.接收数据
                        byte[] recieve = new byte[1024];
                        int len = socket.Receive(recieve);

                        //6.打印接收数据
                        if (recieve.Length > 0)
                        {
                            //如果接收到客户端停止的标志
                            if (Encoding.ASCII.GetString(recieve, 0, len) == "*close*")
                            {
                                richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "客户端已退出" + "\n";
                                CFlag = 1;      //将客户端关闭标志设置为1

                                break;      //退出循环
                            }

                            //打印接收数据
                            richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "接收：";
                            richTextBox_Receive.Text += Encoding.ASCII.GetString(recieve, 0, len);  //将字节数据根据ASCII码转成字符串
                            richTextBox_Receive.Text += "\r\n";
                        }
                    }
                    else
                    {
                        break;  //跳出循环
                    } 
                }
                catch
                {
                    MessageBox.Show("收不到信息");
                }  
            }  
        }
        #endregion
        /*****************************************************************/

        /*****************************************************************/
        #region 向客户端发送数据
        private void button_Send_Click(object sender, EventArgs e)
        {
            //SFlag标志连接成功，同时当客户端是打开的时候才能发送数据
            if(SFlag == 1 && CFlag == 0)
            {
                byte[] send = new byte[1024];
                send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);    //将字符串转成字节格式发送
                socket.Send(send);  //调用Send()向客户端发送数据

                //打印发送时间和发送的数据
                richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "发送：";
                richTextBox_Receive.Text += richTextBox_Send.Text + "\n";
                richTextBox_Send.Clear();   //清除发送框
            } 
        }
        #endregion
        /*****************************************************************/

        /*****************************************************************/
        #region 关闭服务器端
        private void button_Close_Click(object sender, EventArgs e)
        {
            //若连接上了客户端需要关闭线程2和socket，没连接上客户端直接关闭线程1和其他套接字
            if(CFlag == 1)
            {
                th2.Abort();        //关闭线程2
                socket.Close();     //关闭用于通信的套接字
            }
            
            ServerSocket.Close();   //关闭用于连接的套接字
            socketAccept.Close();   //关闭与客户端绑定的套接字
            th1.Abort();    //关闭线程1

            CFlag = 0;  //将客户端标志重新设置为0,在进行连接时表示是打开的状态
            SFlag = 0;  //将连接成功标志程序设置为0，表示退出连接
            button_Accpet.Enabled = true;
            richTextBox_Receive.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ");
            richTextBox_Receive.Text += "服务器已关闭" + "\n";
            MessageBox.Show("服务器已关闭");
        }
        #endregion
        /*****************************************************************/

        /*****************************************************************/
        #region 点击enter发送数据
        private void richTextBox_Send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.button_Send_Click(sender, e);//触发button事件  
            }
        }
        #endregion
        /*****************************************************************/
    }
}

```

# 四、客户端完整代码

```csharp
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
        public static Socket ClientSocket;  //声明负责通信的socket
        public static int SFlag = 0;    //连接服务器成功标志
        Thread th1;     //声明一个线程

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            Control.CheckForIllegalCrossThreadCalls = false;    //执行新线程时跨线程资源访问检查会提示报错，所以这里关闭检测
        }

        /*****************************************************************/
        #region 连接服务器端
        private void button_Connect_Click(object sender, EventArgs e)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);     //声明负责通信的套接字
            
            richTextBox_Recieve.Text += "正在连接...\n";
            
            IPAddress IP = IPAddress.Parse(textBox_Addr.Text);      //获取设置的IP地址
            int Port = int.Parse(textBox_Port.Text);       //获取设置的端口号
            IPEndPoint iPEndPoint = new IPEndPoint(IP,Port);    //指定的端口号和服务器的ip建立一个IPEndPoint对象

            try
            {  
                ClientSocket.Connect(iPEndPoint);       //用socket对象的Connect()方法以上面建立的IPEndPoint对象做为参数，向服务器发出连接请求
                SFlag = 1;  //若连接成功将标志设置为1
                    
                richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + textBox_Addr.Text + "连接成功" + "\n";
                button_Connect.Enabled = false;     //禁止操作连接按钮
                
                //开启一个线程接收数据
                th1 = new Thread(Receive);
                th1.IsBackground = true;
                th1.Start(ClientSocket);    
            }
            catch 
            {
                MessageBox.Show("服务器未打开");
            }    
        }
        #endregion
        /*****************************************************************/

        /*****************************************************************/
        #region 接收服务器端数据
        void Receive(Object sk)
        {
            Socket socketRec = sk as Socket;

            while (true)
            {
                //5.接收数据
                byte[] receive = new byte[1024];
                ClientSocket.Receive(receive);  //调用Receive()接收字节数据

                //6.打印接收数据
                if (receive.Length > 0)
                {
                    richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "接收：";   //打印接收时间
                    richTextBox_Recieve.Text += Encoding.ASCII.GetString(receive);  //将字节数据根据ASCII码转成字符串
                    richTextBox_Recieve.Text += "\r\n";
                }
            }
        }
        #endregion
        /*****************************************************************/

        /*****************************************************************/
        #region 向服务器端发送数据
        private void button_Send_Click(object sender, EventArgs e)
        {
            //只有连接成功了才能发送数据，接收部分因为是连接成功才开启线程，所以不需要使用标志
            if (SFlag == 1)
            {
                byte[] send = new byte[1024];
                send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);  //将文本内容转换成字节发送
                ClientSocket.Send(send);    //调用Send()函数发送数据

                richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + "发送：";   //打印发送数据的时间
                richTextBox_Recieve.Text += richTextBox_Send.Text + "\n";   //打印发送的数据
                richTextBox_Send.Clear();   //清空发送框
            }
        }
        #endregion
        /*****************************************************************/

        /*****************************************************************/
        #region 关闭客户端
        private void buttonClose_Click(object sender, EventArgs e)
        {
            //保证是在连接状态下退出
            if (SFlag == 1)
            {
                byte[] send = new byte[1024];
                send = Encoding.ASCII.GetBytes("*close*");  //关闭客户端时给服务器发送一个退出标志
                ClientSocket.Send(send);
                
                th1.Abort();    //关闭线程
                ClientSocket.Close();   //关闭套接字
                button_Connect.Enabled = true;  //允许操作按钮
                SFlag = 0;  //客户端退出后将连接成功标志程序设置为0
                richTextBox_Recieve.Text += DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ");
                richTextBox_Recieve.Text += "客户端已关闭" + "\n";
                MessageBox.Show("已关闭连接");
            }
        }
        #endregion
        /*****************************************************************/

        /*****************************************************************/
        #region 点击enter发送数据
        private void richTextBox_Send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.button_Send_Click(sender, e);//触发button事件  
            }
        }
        #endregion
        /*****************************************************************/
    }
}

```

