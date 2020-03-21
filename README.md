# HMinecraftServerUpdate
MinecraftModsUpdater Let your players have Latest Mods
****

## 作用  
使用该程序可以方便让你的MinecrftForge服务器的玩家拥有和服务器一样的mod而不用整合包  
凸显服主的个性,可联网自定义背景图片(见教程部分)  
## 图片(背景可自定义)  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/UI.jpg)  
## 需求  
源码默认是需要使用2560和2561端口(可修改)  
用户端解压zip包功能需要.NET Framework 4.7.2以及更高  
****
## 教程  
*注意软件若没进行下面的设置直接运行的话可能会无响应几秒*
### 服务端  
1.设置用户名密码存放地方    
用户名  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/Usernm.png)  
用户密码  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/Userpswd.png)  
这里使用的是F1 F2 F3.ini的文件，确保用户名文件夹和用户密码文件夹里相同的文件对应该有的密码  
2.设置用户名密码存放位置  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/dataroad.png)  
将LoginProgram文件夹下的Main.cs文件的这两行修改为你存放用户名密码的地方(如上图)  
3.设置监听端口  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/port.png)  
在Main.cs里的Main函数中有两个参数，IP和端口，修改成对应的即可  
4.运行  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/command.png)  
输入stop可以停止运行  
代码中初始可以设置3个用户的信息，若需添加用户，请在Main.cs中做如下操作  
添加F4的信息,然后手动创建文件:  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/1.png)  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/2.png)  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/3.png)  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/4.png)  
5.背景图片  
背景图片我使用的http读文件,在我的端口为2560的网站服务器开一个叫MCServer的文件夹    
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/httpmain.png)  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/http.png)  
里面弄成这个样子  
Color.txt为用户端显示文字的文字颜色，可在Black与White中选择  
Wallpaper.jpg为客户端的背景图片，前提是客户端勾选了自动更新背景图片  
 - 我用的分辨率是2400x1350的，按照这个比例即可  
Mods.zip为Mod的压缩包(压缩的时候直接压mods文件夹即可)  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/Mods.png)  
ModUpTime.txt为Mod最近更新的时间  
ModThingUp.txt为Mod更新了的内容  
User文件夹里面放玩家登录后的头像  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/User.png)  
****
### 用户端  
1.自动检测.minecraft文件夹  
如果软件和.minecraft在同一个目录将会自动填充软件里的.minecraft文件夹路径  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/mc.png)  
2.修改服务器地址  
点击右下角按钮后可以修改以后软件访问的服务器地址与端口  
服主可以在源码中60行左右地方和设计窗口中修改(两个要一起改)  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/IP.png)  
![Image text](https://github.com/LunaroakF/Images/blob/master/HMinecraftServerUpdate/nmIP.png)  
3.修改背景图片  
如果觉得服主联网给的图片不好看，自己可以先关闭联网更新图片选项再修改与软件相同目录的upbg文件夹里的Wallpaper.jpg即可
