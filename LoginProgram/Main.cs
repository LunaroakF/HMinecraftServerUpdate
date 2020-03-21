using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace LCServer
{
    class ReceiveMessage
    {
        static void Printmess(string str)
        {
            string time = "[" + DateTime.Now.ToLocalTime().ToString() + "]：";
            Console.WriteLine(time + str);
        }
        static void Log()
        {
            string input = Console.ReadLine();
            if (input == "stop")//输入stop可以关闭程序
            {
                Environment.Exit(0);
            }
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(Log));
            thread.Start();
            string IP = "192.168.0.101";//服务器的内网IP
            int port = 2560;//后面调用会+1
            while (true)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(IP), port+1);
                socket.Bind(ipp);
                socket.Listen(10);
                byte[] bytes = new byte[1024];
                Console.WriteLine("");
                Printmess("新的监听线程已在端口"+(port+1).ToString()+"开启");
                Socket client = socket.Accept();
                Printmess("连接成功，等待用户数据......");
                try
                {
                    client.Receive(bytes);
                }
                catch
                {
                    socket.Close();
                    System.Threading.Thread.Sleep(3000);
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ipp = new IPEndPoint(IPAddress.Parse(IP), port + 1);
                    socket.Bind(ipp);
                    socket.Listen(10);
                    bytes = new byte[1024];
                    Console.WriteLine("");
                    Printmess("新的监听线程已在端口" + (port + 1).ToString() + "开启");
                    client = socket.Accept();
                    Printmess("连接成功，等待用户数据......");
                    client.Receive(bytes);
                }
                string messages = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                Printmess(messages);
                Check(client, messages);
                socket.Close();


            }
        }
        static void Check(Socket socket, string messages)
        {
            List<string> listLines = new List<string>();
            string UserROAD = "/home/pi/Desktop/APPSERVER/UserPasswords/";//服务器上存放用户密码的地方
            string UserNameROAD = "/home/pi/Desktop/APPSERVER/UserPasswords/UserName/";//服务器上存放用户名的地方

            //生成用户局部变量
            string F1;
            string F2;
            string F3;
            string F1Name;
            string F2Name;
            string F3Name;


            //读密码:
            using (StreamReader reader = new StreamReader(@UserROAD + "F1.ini"))
            {
                F1 = reader.ReadLine();
            }
            using (StreamReader reader = new StreamReader(@UserROAD + "F2.ini"))
            {
                F2 = reader.ReadLine();
            }
            using (StreamReader reader = new StreamReader(@UserROAD + "F3.ini"))
            {
                F3 = reader.ReadLine();
            }

            using (StreamReader reader = new StreamReader(@UserNameROAD + "F1.ini"))
            {
                F1Name = reader.ReadLine();
            }
            using (StreamReader reader = new StreamReader(@UserNameROAD + "F2.ini"))
            {
                F2Name = reader.ReadLine();
            }
            using (StreamReader reader = new StreamReader(@UserNameROAD + "F3.ini"))
            {
                F3Name = reader.ReadLine();
            }




            //改密码:
            if (string.Compare(messages, F1Name+":"+F1 + "ChangePassWords") == 0)
            {
                try
                {
                    System.Threading.Thread.Sleep(500);
                    byte[] NEW = new byte[1024];
                    socket.Receive(NEW);
                    string Newp = Encoding.UTF8.GetString(NEW, 0, NEW.Length);//将数据转换为字符串
                    File.Delete(@UserROAD + "F1.ini");
                    System.IO.File.WriteAllText(@UserROAD + "F1.ini", Newp, Encoding.UTF8);//不存在
                    socket.Send(Encoding.UTF8.GetBytes("Successful"));
                    Printmess("用户密码更改成功");
                }
                catch { Printmess("Error #012758"); }
            }
            else if (string.Compare(messages, F2Name+":"+F2 + "ChangePassWords") == 0)
            {
                try
                {
                    System.Threading.Thread.Sleep(500);
                    byte[] NEW = new byte[1024];
                    socket.Receive(NEW);
                    string Newp = Encoding.UTF8.GetString(NEW, 0, NEW.Length);//将数据转换为字符串
                    File.Delete(@UserROAD + "F2.ini");
                    System.IO.File.WriteAllText(@UserROAD + "F2.ini", Newp, Encoding.UTF8);//不存在
                    socket.Send(Encoding.UTF8.GetBytes("Successful"));
                }
                catch { Printmess("Error #012758"); }
            }
            else if (string.Compare(messages, F3Name+":"+F3 + "ChangePassWords") == 0)
            {
                try
                {
                    System.Threading.Thread.Sleep(500);
                    byte[] NEW = new byte[1024];
                    socket.Receive(NEW);
                    string Newp = Encoding.UTF8.GetString(NEW, 0, NEW.Length);//将数据转换为字符串
                    File.Delete(@UserROAD + "F3.ini");
                    System.IO.File.WriteAllText(@UserROAD + "F3.ini", Newp, Encoding.UTF8);//不存在
                    socket.Send(Encoding.UTF8.GetBytes("Successful"));
                }
                catch { Printmess("Error #012758"); }
            }

            //皮肤上传:
            else if (string.Compare(messages, F1 + "ChangeSkin") == 0)
            {

            }

            //登录验证:
            else if (string.Compare(messages, F1Name+":"+F1) == 0)
            {
                string name = F1Name;
                try
                {
                    socket.Send(Encoding.UTF8.GetBytes(name));
                }
                catch { Printmess("Error #012758"); }
                Printmess("用户："+F1Name+"，登录成功，" + "返回名：" + name);
            }
            else if (string.Compare(messages, F2Name+":"+F2) == 0)
            {
                string name = F2Name;
                try
                {
                    socket.Send(Encoding.UTF8.GetBytes(name));
                }
                catch { Printmess("Error #012758"); }
                Printmess("用户："+F2Name+"，登录成功，" + "返回名：" + name);
            }
            else if (string.Compare(messages, F3Name+":"+F3) == 0)
            {
                string name = F3Name;
                try
                {
                    socket.Send(Encoding.UTF8.GetBytes(name));
                }
                catch { Printmess("Error #012758"); }
                Printmess("用户："+F3Name+"，登录成功，" + "返回名：" + name);
            }

            //都不对:
            else
            {
                try
                {
                    socket.Send(Encoding.UTF8.GetBytes("apLoginErr0r"));
                }
                catch { Printmess("Error #012758"); }
                Printmess("用户登录失败");
            }
        }
        static void DownloadSkin(Socket socket)
        {

        }

    }
}
