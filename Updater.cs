using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading;
using System.Net.Sockets;

namespace HMinecraftServerUpdate
{

    public partial class Updater : Form
    {
        bool check = true;
        string post;
        string IP;
        string Address;
        string 运行目录 = System.IO.Directory.GetCurrentDirectory();
        bool changebool = true;
        string changeboolstr;
        string cachecolor = "Black";
        string color = "Black";


        public Updater()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//窗口启动执行
        {
        }
        private void Start_Tick(object sender, EventArgs e)//启动时钟
        {
            Start.Enabled = false;


            if (File.Exists(@运行目录 + "/upbg/")) //检测是否存在程序数据目录
            {
            
            }
            else
            {
                Directory.CreateDirectory(@运行目录 + "/upbg");//当前路径下创建一个
            }


            if (File.Exists(@运行目录 + "/upbg/DownloaderIP.ini"))//检测IP属性文件是否存在
            {
                ChangeIP();
            }
            else
            {
                System.IO.File.WriteAllText(@运行目录 + "/upbg/DownloaderIP.ini", "ServerIP", Encoding.UTF8);//不存在
                IP = "ServerIP";
            }


            if (File.Exists(@运行目录 + "/upbg/DownloaderPost.ini"))
            {
                ChangePost();
            }
            else
            {
                System.IO.File.WriteAllText(@运行目录 + "/upbg/DownloaderPost.ini", "2560", Encoding.UTF8);//不存在
                post = "2560";
            }

            if (File.Exists(@运行目录 + "/upbg/OnlineDownloadWallpaper.ini"))
            {
                List<string> listLines = new List<string>();
                using (StreamReader reader = new StreamReader(运行目录 + "/upbg/OnlineDownloadWallpaper.ini"))
                {
                    changeboolstr = reader.ReadLine();
                }

                if (changeboolstr == "true")
                {
                    OnlineCheckWallpaper.Checked = true;
                    changebool = true;
                }
                if (changeboolstr == "false")
                {
                    OnlineCheckWallpaper.Checked = false;
                    changebool = false;
                }
            }
            else
            {
                System.IO.File.WriteAllText(@运行目录 + "/upbg/OnlineDownloadWallpaper.ini", "true", Encoding.UTF8);//不存在
                changebool = true;
            }

            if (File.Exists(@运行目录 + "/upbg/UserSetting.ini")) //检测是否存在用户账号目录
            {
                string[] line = File.ReadAllLines(运行目录+ "/upbg/UserSetting.ini");
                string Usernamesetting = line[0];
                string Userpasswords = line[1];
                UserLogin(Usernamesetting ,Userpasswords);
            }

            try
            {
                IPHostEntry host = Dns.GetHostByName(IP);
                IPAddress ip = host.AddressList[0];
                ServerIP.Text = IP;
                ServerPost.Text = post;
                IP = ip.ToString();
                if (IP != "127.0.0.1")
                {
                    Address = "http://" + IP + ":" + post + "/";
                }
                else
                {
                    Address = "http://" + "8.8.8.8" + ":" + post + "/";
                }
            }
            catch
            {
                MessageBox.Show("无法解析服务器", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            if (Directory.Exists(@运行目录 + @"/.minecraft"))
            {
                minecraftRoad.Text = @运行目录 + @"\.minecraft\";
                UpdateMods.Enabled = true;
                minecraftRoad.ForeColor = Color.Black;
            }
            checklabe3();

            try
            {
                changewall();
            }
            catch
            {
                FailedChangeWallpaper.Visible = true;
                ChangingWallpaperTEXT.Visible = false;
            }


            if (changebool)
            {
                FindColor();
                ModUPTime();
            }
            else {
                moduptime.Text = "Mod最后更新：" + "请勾选联网更新背景图片";
                Updatetext.Text =  "请勾选联网更新背景图片";

            }

            if (File.Exists(@运行目录 + "/upbg/FontColor.ini"))
            {
                List<string> listLines = new List<string>();
                using (StreamReader reader = new StreamReader(运行目录 + "/upbg/FontColor.ini"))
                {
                    color = reader.ReadLine();
                }
                changetextcolor();
            }
            else
            {
                System.IO.File.WriteAllText(@运行目录 + "/upbg/FontColor.ini", "Black", Encoding.UTF8);//不存在
                color = "Black";
            }
           
            //FindUpdate();
        }

        public void ModUPTime()
        {
                string urlstr = @Address + "MCServer/ModUPTime.txt";
                Uri url = new Uri(urlstr);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                myHttpWebRequest.Accept = "application/xml";
                myHttpWebRequest.Headers.Add("X-***-Token-Id", "***");
                myHttpWebRequest.Method = "GET";
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                Stream stream = myHttpWebResponse.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                cachecolor = reader.ReadToEnd();            //输出字符串信息

                moduptime.Text = "Mod最后更新：" + cachecolor;
        }

        public void ModThingUP()
        {
            string urlstr = @Address + "MCServer/ModThingUP.txt";
            Uri url = new Uri(urlstr);
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Accept = "application/xml";
            myHttpWebRequest.Headers.Add("X-***-Token-Id", "***");
            myHttpWebRequest.Method = "GET";
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            Stream stream = myHttpWebResponse.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            cachecolor = reader.ReadToEnd();            //输出字符串信息

            Updatetext.Text = Updatetext.Text + cachecolor;
        }


        public void UserLogin(string name,string passwords) 
        {
            try
            {

                System.Threading.Thread.Sleep(1500);

                Socket sendMessage = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建套接字，参数具体定义参考MSDN
                IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(IP), Convert.ToInt32(post)+1);
                sendMessage.Connect(ipp);
                string mgs = name+":"+passwords;
                byte[] message = new byte[1024];
                message = Encoding.UTF8.GetBytes(mgs);
                sendMessage.Send(message);

                byte[] result = new byte[1024];
                sendMessage.Receive(result);
                string serverlogin= Encoding.UTF8.GetString(result).ToString();

                if (string.Compare(serverlogin, "apLoginErr0r") == 0)
                {
                    MessageBox.Show("用户名或密码错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Loginbt.Enabled = true;
                    Loginbt.Text = "登录";
                    Userpasswordsenter.Enabled = true;
                    Usernameenter.Enabled = true;
                }
                else
                {
                    ServerLoginCheck(System.Text.Encoding.UTF8.GetString(result));
                }

                sendMessage.Close(); 
            }
            catch
            {
                MessageBox.Show("无法连接服务器", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loginbt.Text = "登录";
                Loginbt.Enabled = true;
                Userpasswordsenter.Enabled = true;
                Usernameenter.Enabled = true;
            }
        }

        public void ServerLoginCheck(string serverlogin)
        {
            MainWelcome.Text = serverlogin;
            MainWelcome.Visible = true;
            Welcome.Visible = true;
            System.Windows.Forms.Application.DoEvents();

            Loginbt.Visible = false;
            Loginbt.Text = "注销";
            Usernameenter.Visible = false;
            Userpasswordsenter.Visible = false;
            if (color == "Black")
            {
                Welcome.ForeColor = Color.Black;
            }
            else if (color == "White")
            {
                Welcome.ForeColor = Color.White;
            }
            System.Windows.Forms.Application.DoEvents();
            UserPhoto.Visible = true;
            UserPhoto.ImageLocation = @Address + @"MCServer/User/" + MainWelcome.Text  + @".png";
            System.Windows.Forms.Application.DoEvents();


            更改密码.Visible = true;
            Loginbt.Enabled = true;
            Loginbt.Location = GOUT.Location;
            Loginbt.Visible = true;
        }

        public void checklabe3()//更新壁纸
        {
            if (changebool)
            {
                string urlstr = @Address + "MCServer/Wallpaper.jpg";
                try
                {
                        try
                        {
                            File.Delete(@运行目录 + "/upbg/Wallpaper.jpg");
                        }
                        catch { }
                        finally
                        {
                        ChangingWallpaperTEXT.Visible = true;
                        System.Windows.Forms.Application.DoEvents();
                        FindColor();
                        HttpDownloadFile(urlstr, @运行目录 + "/upbg/Wallpaper.jpg");
                            this.BackgroundImage = Image.FromFile(运行目录 + "/upbg/Wallpaper.jpg");
                        ChangingWallpaperTEXT.Visible = false;
                    }
                    
                }
                catch
                {

                   // label3.Visible = true;
                }
            }

        }

        public void changewall()//更改背景图片
        {
            if (File.Exists(@运行目录 + "/upbg/Wallpaper.jpg"))
            {
                this.BackgroundImage = Image.FromFile(运行目录 + "/upbg/Wallpaper.jpg");
                ChangingWallpaperTEXT.Visible = false;
            }
            else
            {
                Directory.CreateDirectory(@运行目录 +"/upbg");
                string urlstr = @Address + "MCServer/Wallpaper.jpg";
                if (changebool)
                {
                    ChangingWallpaperTEXT.Visible = true;
                    System.Windows.Forms.Application.DoEvents();
                    FindColor();
                    HttpDownloadFile(urlstr, @运行目录 + "/upbg/Wallpaper.jpg");
                    this.BackgroundImage = Image.FromFile(运行目录 + "/upbg/Wallpaper.jpg");
                    ChangingWallpaperTEXT.Visible = false;
                }
            }

        }

        private void FindColor()//联网下载界面字体颜色
        {
            string urlstr = @Address + "MCServer/Color.txt";
            Uri url = new Uri(urlstr);
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Accept = "application/xml";
            myHttpWebRequest.Headers.Add("X-***-Token-Id", "***");
            myHttpWebRequest.Method = "GET";
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            Stream stream = myHttpWebResponse.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            cachecolor = reader.ReadToEnd();            //输出字符串信息

            System.IO.File.WriteAllText(@运行目录 + "/upbg/FontColor.ini", cachecolor, Encoding.UTF8);
        }

        public void CheckPg()//检测进程是否存在
        {
            if (System.Diagnostics.Process.GetProcessesByName("要获取的程序在进程中的名称").ToList().Count > 0)
            {
                //存在
            }
            else
            {
                //不存在
            }
        }

        public void ChangeIP()//设置变量IP为文件的IP
        {
            List<string> listLines = new List<string>();
            using (StreamReader reader = new StreamReader(运行目录 +"/upbg/DownloaderIP.ini"))
            {
                IP = reader.ReadLine();
            }
        }

        public void ChangePost()//设置变量post为文件的端口
        {
            List<string> listLines = new List<string>();
            using (StreamReader reader = new StreamReader(运行目录 + "/upbg/DownloaderPost.ini"))
            {
                post = reader.ReadLine();
            }

        }

        private void button1_Click(object sender, EventArgs e)//右下角地址更改按了以后
        {
            if (ChangeIPButton.Text == "保存")
            {
                System.IO.File.WriteAllText(@运行目录 + "/upbg/DownloaderIP.ini", ServerIP.Text, Encoding.UTF8);//不存在
                IP = ServerIP.Text;
                System.IO.File.WriteAllText(@运行目录 + "/upbg/DownloaderPost.ini", ServerPost.Text, Encoding.UTF8);//不存在
                post = ServerPost.Text;
                Address = "http://" + IP + ":" + post + "/";
                IPsaved.Visible = false;
                IPsaved.Visible = true;
                try
                {
                    IPHostEntry host = Dns.GetHostByName(IP);
                    IPAddress ip = host.AddressList[0];
                    ServerIP.Text = IP;
                    ServerPost.Text = post;
                    IP = ip.ToString();
                    if (IP != "127.0.0.1")
                    {
                        Address = "http://" + IP + ":" + post + "/";
                    }
                    else
                    {
                        Address = "http://" + "8.8.8.8" + ":" + post + "/";
                    }
                }
                catch
                {
                    MessageBox.Show("无法解析服务器", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("若错误地更改此配置可能会导致更新器无法正常使用，是否继续?", "更改配置", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
                if (result == DialogResult.Yes)
                {
                    ChangeIPButton.Location = ChangeIPButtonLocation.Location;
                    ServerIP.Visible = true;
                    ServerPost.Visible = true;
                    ChangeIPButton.Text = "保存";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//.minecraft文件夹位置更改
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择.minecraft文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show("文件夹路径不能为空", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                minecraftRoad.Text = dialog.SelectedPath;// +"\\";
                minecraftRoad.ForeColor = Color.Black;
                UpdateMods.Enabled = true;
                //do something
            }
        }
               
        private void Road_TextChanged(object sender, EventArgs e)//.minecraft文件夹路径有变动后位置调最后
        {
            this.minecraftRoad.SelectionStart = this.minecraftRoad.Text.Length;
            this.minecraftRoad.SelectionLength = 0;
            this.minecraftRoad.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)//按下Mod更新后确认然后下载
        {
            DialogResult result = MessageBox.Show("Mod更新将会删除该mods路径下的所有文件再重新下载"+ Environment.NewLine +"但会备份Voxel地图数据" + Environment.NewLine + "是否继续?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                UpdateMods.Enabled = false;
                ModDownloadLabel.Visible = true;
                ModDownloadedByte.Visible = true;
                System.Windows.Forms.Application.DoEvents();
                minecraftRoad.ReadOnly = true;
                System.Windows.Forms.Application.DoEvents();


                    ChangeminecraftButton.Enabled = false;
                    Control.CheckForIllegalCrossThreadCalls = false;
                    Thread thread = new Thread(new ThreadStart(TrytoDownloadMods));
                    thread.Start();

            }
        }

        public void TrytoDownloadMods()//尝试下载mod
        {
            try { 
            DownloadThings(Address + "MCServer/Mods.zip", minecraftRoad.Text + "/mods.zip", ModDownloadedByte, ModDownloadLabel);
            }
            catch
            {
                MessageBox.Show("无法连接服务器", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DownloadThings(string URL, string filename, System.Windows.Forms.ProgressBar prog, System.Windows.Forms.Label mainlabel)
        {
            float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (prog != null)
                {
                    prog.Maximum = (int)totalBytes;
                }
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[409600];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    if (prog != null)
                    {
                        prog.Value = (int)totalDownloadedByte;
                        System.Windows.Forms.Application.DoEvents();
                    }
                    osize = st.Read(by, 0, (int)by.Length);
                    System.Windows.Forms.Application.DoEvents(); 

                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    //mainlabel.Text =percent.ToString() + "%";
                    mainlabel.Text = Convert.ToInt32(percent).ToString() + "%";
                    System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
            bool havemap;
            bool backup=true;

            ModDownloadLabel.Text = "清理备份目录......";
            System.Windows.Forms.Application.DoEvents();
            try
            { Directory.Delete(@运行目录 + "/upbg/VoxelMods/", true); }
            catch
            { }
            ModDownloadLabel.Text = "备份小地图数据......";
            System.Windows.Forms.Application.DoEvents();
            try
            {
                CopyDirectory(minecraftRoad.Text + "/mods"+ "/VoxelMods", @运行目录 + "/upbg/VoxelMods/");
                ModDownloadLabel.Text = "小地图备份完毕";
                System.Windows.Forms.Application.DoEvents();
                havemap = true;
            }
            catch
            {
                ModDownloadLabel.Text = "无法找到小地图VoxelMods文件夹";
                System.Windows.Forms.Application.DoEvents();
                ModDownloadLabel.ForeColor = Color.Red;
                System.Threading.Thread.Sleep(500);
                changetextcolor();
                havemap = false;
            }
            System.Threading.Thread.Sleep(500);
            ModDownloadLabel.Text = "删除mods文件夹......";
            System.Windows.Forms.Application.DoEvents();
            try
            { Directory.Delete(minecraftRoad.Text + "/mods", true); }
            catch
            {
                ModDownloadLabel.Text = "无mods文件夹";
                System.Windows.Forms.Application.DoEvents();
            }
            finally
            {
                ModDownloadLabel.Text = "解压中......";
                System.Windows.Forms.Application.DoEvents();
                Unzip(minecraftRoad.Text,"/mods.zip",minecraftRoad.Text);
                ModDownloadLabel.Text = "删除mods.zip......";
                System.Windows.Forms.Application.DoEvents();
                File.Delete(minecraftRoad.Text + "/mods.zip");
                if (havemap)
                {
                    System.Threading.Thread.Sleep(500);
                    ModDownloadLabel.Text = "恢复小地图数据......";
                    System.Windows.Forms.Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                    try
                    {
                        CopyDirectory(@运行目录 + "/upbg/VoxelMods/", minecraftRoad.Text + "/mods" + "/VoxelMods/");
                    }
                    catch {
                        ModDownloadLabel.Text = "地图恢复失败";
                        backup = false;
                        ModDownloadLabel.ForeColor = Color.Red;
                        System.Threading.Thread.Sleep(500);
                        changetextcolor();
                    }
                }
                if (backup)
                {
                    ModDownloadLabel.Text = "删除备份文件......";
                    System.Windows.Forms.Application.DoEvents();
                    try
                    { Directory.Delete(@运行目录 + "/upbg/VoxelMods/", true); }
                    catch
                    {
                        ModDownloadLabel.Text = "备份文件删除失败";
                        System.Windows.Forms.Application.DoEvents();
                        ModDownloadLabel.ForeColor = Color.Red;
                        System.Threading.Thread.Sleep(500);
                        changetextcolor();
                    }
                }
                minecraftRoad.ReadOnly = false ;
                ChangeminecraftButton.Enabled = true;
                ModDownloadLabel.Text = "完成";
            }
        }
        //有进度条的下载



        public static void CopyDirectory(string sourceDirPath, string SaveDirPath)
        {
            try
            {
                //如果指定的存储路径不存在，则创建该存储路径
                if (!Directory.Exists(SaveDirPath))
                {
                    //创建
                    Directory.CreateDirectory(SaveDirPath);
                }
                //获取源路径文件的名称
                string[] files = Directory.GetFiles(sourceDirPath);
                //遍历子文件夹的所有文件
                foreach (string file in files)
                {
                    string pFilePath = SaveDirPath + "\\" + Path.GetFileName(file);
                    if (File.Exists(pFilePath))
                        continue;
                    File.Copy(file, pFilePath, true);
                }
                string[] dirs = Directory.GetDirectories(sourceDirPath);
                //递归，遍历文件夹
                foreach (string dir in dirs)
                {
                    CopyDirectory(dir, SaveDirPath + "\\" + Path.GetFileName(dir));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }






        public void Unzip(string unzipRoad,string unzipname,string toplace)//解压文件
        {
            ZipFile.ExtractToDirectory(@unzipRoad + unzipname , toplace);
        }

        public static string HttpDownloadFile(string url, string path)//服务器下载文件
        {
            

                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();

                //创建本地文件写入流
                Stream stream = new FileStream(path, FileMode.Create);

                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                stream.Close();
                responseStream.Close();
                return path;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//联网更新框状态更改
        {

            if (OnlineCheckWallpaper.Checked)
            {
                System.IO.File.WriteAllText(@运行目录 + "/upbg/OnlineDownloadWallpaper.ini", "true", Encoding.UTF8);//不存在
                changebool = true;
            }
            else {
                System.IO.File.WriteAllText(@运行目录 + "/upbg/OnlineDownloadWallpaper.ini", "false", Encoding.UTF8);//不存在
                changebool = false;
            }

        }

        public void changetextcolor()//改变字体颜色
        {
            if (color == "White")
            {
                Title.ForeColor = Color.White;
                minecraft.ForeColor = Color.White;
                ModDownloadLabel.ForeColor = Color.White;
                OnlineCheckWallpaper.ForeColor = Color.White;
                skin.ForeColor = Color.White;
                HelloUsername.ForeColor = Color.White;
                moduptime.ForeColor = Color.White;
                软件版本.ForeColor = Color.White;
            }
            if(color == "Black")
            { 
                Title.ForeColor = Color.Black ;
                  minecraft.ForeColor = Color.Black;
                ModDownloadLabel.ForeColor = Color.Black;
                OnlineCheckWallpaper.ForeColor = Color.Black;
                skin.ForeColor = Color.Black;
                HelloUsername.ForeColor = Color.Black;
                moduptime.ForeColor = Color.Black;
                软件版本.ForeColor = Color.Black;
            }

        }

        private void changeskin_Click(object sender, EventArgs e)//选择皮肤文件
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择皮肤文件";
            dialog.Filter = "Minecraft皮肤(*.png)|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SkinRoad.Text = dialog.FileName;
                SkinRoad.ForeColor = Color.Black;
                SkinUpload.Enabled = true;
            }
        }

        private void richTextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Userpasswordsenter.Text=string.Empty;
            Userpasswordsenter.ForeColor = Color.Black;
            Userpasswordsenter.PasswordChar = '*';
        }

        private void Usernameenter_MouseClick(object sender, MouseEventArgs e)
        {
            Usernameenter.Text = string.Empty;
            Usernameenter.ForeColor = Color.Black;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (Loginbt.Text == "注销")
            {
                Userpasswordsenter.Text = string.Empty;
                Usernameenter.Visible = true;
                Userpasswordsenter.Visible = true;
                Loginbt.Location = INLT.Location;
                Welcome.Visible = false;
                MainWelcome.Visible = false;
                Loginbt.Text = "登录";
                UserPhoto.Image = Properties.Resources.Empty;
                UserPhoto.Visible = false;
                Userpasswordsenter.Enabled = true;
                Usernameenter.Enabled = true;
                更改密码.Text = "更改密码";
                System.Windows.Forms.Application.DoEvents();
                更改密码.Visible = false;
                新密码.Text = "新密码";
                System.Windows.Forms.Application.DoEvents();
                新密码.ForeColor = Color.Gray;
                新密码.Visible = false;
                确认密码.Text = "确认密码";
                System.Windows.Forms.Application.DoEvents();
                确认密码.ForeColor = Color.Gray;
                确认密码.Visible = false;
            }
            else if (Usernameenter.Text != "用户名" && Userpasswordsenter.Text != "密码"&& Usernameenter.Text != string.Empty && Userpasswordsenter.Text !=string.Empty)
            {
                if (Loginbt.Text == "登录")
                {
                    Loginbt.Text = "登录中";
                    Loginbt.Enabled = false;
                    Userpasswordsenter.Enabled = false;
                    Usernameenter.Enabled = false;
                    UserLogin(Usernameenter.Text, Userpasswordsenter.Text);
                    System.Threading.Thread.Sleep(1000);
                }
            }

            else 
            {
                MessageBox.Show("请输入用户名以及密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Userpasswordsenter_TextChanged(object sender, EventArgs e)
        {
            Userpasswordsenter.ForeColor = Color.Black;
            Userpasswordsenter.PasswordChar = '*';
        }

        private void 更改密码_Click(object sender, EventArgs e)
        {
            if (更改密码.Text == "提交")
            {
                if (确认密码.Text == string.Empty)
                {
                    MessageBox.Show("请输入新密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (新密码.Text == 确认密码.Text)
                {
                    确认密码.Enabled = false;
                    新密码.Enabled = false;
                    更改密码.Enabled = false;
                    更改密码.Text = "更改中..";
                    System.Windows.Forms.Application.DoEvents();
                    Changenewpassword(Usernameenter.Text + ":" + 确认密码.Text,确认密码.Text);
                }
                else
                {
                    MessageBox.Show("两次密码不一致", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (更改密码.Text == "更改密码")
            {
                新密码.PasswordChar = new char ();
                确认密码.PasswordChar = new char();
                System.Windows.Forms.Application.DoEvents();
                新密码.ForeColor = Color.Gray;
                System.Windows.Forms.Application.DoEvents();
                确认密码.ForeColor = Color.Gray;
                新密码.Visible = true;
                确认密码.Visible = true;
                更改密码.Text = "提交";
            }
        }

        private void Changenewpassword(string passwords,string finalypswd)
        {
            string key = Usernameenter.Text + ":" + Userpasswordsenter.Text + "ChangePassWords";
            System.Threading.Thread.Sleep(1500);
            Socket sendMessage = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建套接字，参数具体定义参考MSDN
            IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(IP), Convert.ToInt32(post) + 1);
            sendMessage.Connect(ipp);
            byte[] message = new byte[1024];
            message = Encoding.UTF8.GetBytes(key);
            sendMessage.Send(message);
            message = new byte[1024];
            System.Threading.Thread.Sleep(500);
            message = Encoding.UTF8.GetBytes(finalypswd);
            sendMessage.Send(message);
            byte[] result = new byte[1024];
            sendMessage.Receive(result);
            string serverlogin = Encoding.UTF8.GetString(result).ToString();
            if (string.Compare(serverlogin, "Successful") == 0)
            {
                MessageBox.Show("密码更改成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Userpasswordsenter.Text = 确认密码.Text;
                确认密码.Text = string.Empty;
                新密码.Text = string.Empty;
                确认密码.Enabled = true;
                新密码.Enabled = true;
                更改密码.Enabled = true;
                新密码.PasswordChar = new char();
                确认密码.PasswordChar = new char();
                System.Windows.Forms.Application.DoEvents();
                确认密码.Visible = false;
                新密码.Visible = false;

                更改密码.Text = "更改密码";
            }
            else 
            {
                MessageBox.Show("未知错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 新密码_TextChanged(object sender, EventArgs e)
        {
            新密码.ForeColor = Color.Black;
            新密码.PasswordChar = '*';
        }

        private void 新密码_MouseClick(object sender, MouseEventArgs e)
        {
            新密码.Text = string.Empty;
            新密码 .ForeColor = Color.Black;
            新密码.PasswordChar = '*';
        }

        private void 确认密码_TextChanged(object sender, EventArgs e)
        {
            确认密码.ForeColor = Color.Black;
            确认密码.PasswordChar = '*';
        }

        private void 确认密码_MouseClick(object sender, MouseEventArgs e)
        {
            确认密码.Text = string.Empty;
            确认密码.ForeColor = Color.Black;
            确认密码.PasswordChar = '*';
        }

        private void seeup_Click(object sender, EventArgs e)
        {
            if (seeup.Text == "查看更新")
            {
                Updatetext.Text = "Mod变化:" + Environment.NewLine;
                Updatetext.Visible = true;

                if (changebool)
                {
                    ModUPTime();
                    ModThingUP();
                }
                else
                {
                    Updatetext.Text = Updatetext.Text + "请勾选联网更新背景图片";
                }

                seeup.Text = "收起";
            }
            else if (seeup.Text == "收起")
            {
                Updatetext.Visible = false;
                seeup.Text = "查看更新";
            }

        }
    }
}
