namespace HMinecraftServerUpdate
{
    partial class Updater
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updater));
            this.Start = new System.Windows.Forms.Timer(this.components);
            this.Title = new System.Windows.Forms.Label();
            this.ServerIP = new System.Windows.Forms.RichTextBox();
            this.ServerPost = new System.Windows.Forms.RichTextBox();
            this.ChangeIPButton = new System.Windows.Forms.Button();
            this.IPsaved = new System.Windows.Forms.Label();
            this.minecraftRoad = new System.Windows.Forms.RichTextBox();
            this.ChangeminecraftButton = new System.Windows.Forms.Button();
            this.minecraft = new System.Windows.Forms.Label();
            this.UpdateMods = new System.Windows.Forms.Button();
            this.ModDownloadedByte = new System.Windows.Forms.ProgressBar();
            this.ModDownloadLabel = new System.Windows.Forms.Label();
            this.ChangeIPButtonLocation = new System.Windows.Forms.Button();
            this.OnlineCheckWallpaper = new System.Windows.Forms.CheckBox();
            this.FailedChangeWallpaper = new System.Windows.Forms.Label();
            this.ChangingWallpaperTEXT = new System.Windows.Forms.Label();
            this.SkinRoad = new System.Windows.Forms.RichTextBox();
            this.skin = new System.Windows.Forms.Label();
            this.changeskin = new System.Windows.Forms.Button();
            this.SkinUpload = new System.Windows.Forms.Button();
            this.Loginbt = new System.Windows.Forms.Button();
            this.HelloUsername = new System.Windows.Forms.Label();
            this.UserPhoto = new System.Windows.Forms.PictureBox();
            this.Userpasswordsenter = new System.Windows.Forms.TextBox();
            this.Usernameenter = new System.Windows.Forms.TextBox();
            this.Welcome = new System.Windows.Forms.Label();
            this.MainWelcome = new System.Windows.Forms.Label();
            this.GOUT = new System.Windows.Forms.Button();
            this.INLT = new System.Windows.Forms.Button();
            this.更改密码 = new System.Windows.Forms.Button();
            this.新密码 = new System.Windows.Forms.TextBox();
            this.确认密码 = new System.Windows.Forms.TextBox();
            this.moduptime = new System.Windows.Forms.Label();
            this.Updatetext = new System.Windows.Forms.TextBox();
            this.seeup = new System.Windows.Forms.Button();
            this.软件版本 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Enabled = true;
            this.Start.Interval = 1;
            this.Start.Tick += new System.EventHandler(this.Start_Tick);
            // 
            // Title
            // 
            resources.ApplyResources(this.Title, "Title");
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Name = "Title";
            // 
            // ServerIP
            // 
            resources.ApplyResources(this.ServerIP, "ServerIP");
            this.ServerIP.Name = "ServerIP";
            // 
            // ServerPost
            // 
            resources.ApplyResources(this.ServerPost, "ServerPost");
            this.ServerPost.Name = "ServerPost";
            // 
            // ChangeIPButton
            // 
            resources.ApplyResources(this.ChangeIPButton, "ChangeIPButton");
            this.ChangeIPButton.Name = "ChangeIPButton";
            this.ChangeIPButton.UseVisualStyleBackColor = true;
            this.ChangeIPButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // IPsaved
            // 
            resources.ApplyResources(this.IPsaved, "IPsaved");
            this.IPsaved.BackColor = System.Drawing.Color.Transparent;
            this.IPsaved.ForeColor = System.Drawing.Color.Lime;
            this.IPsaved.Name = "IPsaved";
            // 
            // minecraftRoad
            // 
            this.minecraftRoad.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.minecraftRoad, "minecraftRoad");
            this.minecraftRoad.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.minecraftRoad.Name = "minecraftRoad";
            this.minecraftRoad.ReadOnly = true;
            this.minecraftRoad.TextChanged += new System.EventHandler(this.Road_TextChanged);
            // 
            // ChangeminecraftButton
            // 
            resources.ApplyResources(this.ChangeminecraftButton, "ChangeminecraftButton");
            this.ChangeminecraftButton.Name = "ChangeminecraftButton";
            this.ChangeminecraftButton.UseVisualStyleBackColor = true;
            this.ChangeminecraftButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // minecraft
            // 
            resources.ApplyResources(this.minecraft, "minecraft");
            this.minecraft.BackColor = System.Drawing.Color.Transparent;
            this.minecraft.Name = "minecraft";
            // 
            // UpdateMods
            // 
            resources.ApplyResources(this.UpdateMods, "UpdateMods");
            this.UpdateMods.Name = "UpdateMods";
            this.UpdateMods.UseVisualStyleBackColor = true;
            this.UpdateMods.Click += new System.EventHandler(this.button3_Click);
            // 
            // ModDownloadedByte
            // 
            resources.ApplyResources(this.ModDownloadedByte, "ModDownloadedByte");
            this.ModDownloadedByte.Name = "ModDownloadedByte";
            // 
            // ModDownloadLabel
            // 
            resources.ApplyResources(this.ModDownloadLabel, "ModDownloadLabel");
            this.ModDownloadLabel.BackColor = System.Drawing.Color.Transparent;
            this.ModDownloadLabel.Name = "ModDownloadLabel";
            // 
            // ChangeIPButtonLocation
            // 
            resources.ApplyResources(this.ChangeIPButtonLocation, "ChangeIPButtonLocation");
            this.ChangeIPButtonLocation.Name = "ChangeIPButtonLocation";
            this.ChangeIPButtonLocation.UseVisualStyleBackColor = true;
            // 
            // OnlineCheckWallpaper
            // 
            resources.ApplyResources(this.OnlineCheckWallpaper, "OnlineCheckWallpaper");
            this.OnlineCheckWallpaper.BackColor = System.Drawing.Color.Transparent;
            this.OnlineCheckWallpaper.Checked = true;
            this.OnlineCheckWallpaper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnlineCheckWallpaper.Name = "OnlineCheckWallpaper";
            this.OnlineCheckWallpaper.UseVisualStyleBackColor = false;
            this.OnlineCheckWallpaper.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FailedChangeWallpaper
            // 
            resources.ApplyResources(this.FailedChangeWallpaper, "FailedChangeWallpaper");
            this.FailedChangeWallpaper.BackColor = System.Drawing.Color.Transparent;
            this.FailedChangeWallpaper.ForeColor = System.Drawing.Color.Red;
            this.FailedChangeWallpaper.Name = "FailedChangeWallpaper";
            // 
            // ChangingWallpaperTEXT
            // 
            resources.ApplyResources(this.ChangingWallpaperTEXT, "ChangingWallpaperTEXT");
            this.ChangingWallpaperTEXT.BackColor = System.Drawing.Color.Transparent;
            this.ChangingWallpaperTEXT.ForeColor = System.Drawing.Color.Lime;
            this.ChangingWallpaperTEXT.Name = "ChangingWallpaperTEXT";
            // 
            // SkinRoad
            // 
            this.SkinRoad.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.SkinRoad, "SkinRoad");
            this.SkinRoad.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.SkinRoad.Name = "SkinRoad";
            this.SkinRoad.ReadOnly = true;
            this.SkinRoad.Tag = "";
            // 
            // skin
            // 
            resources.ApplyResources(this.skin, "skin");
            this.skin.BackColor = System.Drawing.Color.Transparent;
            this.skin.Name = "skin";
            // 
            // changeskin
            // 
            resources.ApplyResources(this.changeskin, "changeskin");
            this.changeskin.Name = "changeskin";
            this.changeskin.UseVisualStyleBackColor = true;
            this.changeskin.Click += new System.EventHandler(this.changeskin_Click);
            // 
            // SkinUpload
            // 
            resources.ApplyResources(this.SkinUpload, "SkinUpload");
            this.SkinUpload.Name = "SkinUpload";
            this.SkinUpload.UseVisualStyleBackColor = true;
            // 
            // Loginbt
            // 
            resources.ApplyResources(this.Loginbt, "Loginbt");
            this.Loginbt.Name = "Loginbt";
            this.Loginbt.UseVisualStyleBackColor = true;
            this.Loginbt.Click += new System.EventHandler(this.Login_Click);
            // 
            // HelloUsername
            // 
            resources.ApplyResources(this.HelloUsername, "HelloUsername");
            this.HelloUsername.BackColor = System.Drawing.Color.Transparent;
            this.HelloUsername.Name = "HelloUsername";
            // 
            // UserPhoto
            // 
            this.UserPhoto.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.UserPhoto, "UserPhoto");
            this.UserPhoto.Name = "UserPhoto";
            this.UserPhoto.TabStop = false;
            // 
            // Userpasswordsenter
            // 
            resources.ApplyResources(this.Userpasswordsenter, "Userpasswordsenter");
            this.Userpasswordsenter.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Userpasswordsenter.Name = "Userpasswordsenter";
            this.Userpasswordsenter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox2_MouseClick);
            this.Userpasswordsenter.TextChanged += new System.EventHandler(this.Userpasswordsenter_TextChanged);
            // 
            // Usernameenter
            // 
            resources.ApplyResources(this.Usernameenter, "Usernameenter");
            this.Usernameenter.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Usernameenter.Name = "Usernameenter";
            this.Usernameenter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Usernameenter_MouseClick);
            // 
            // Welcome
            // 
            resources.ApplyResources(this.Welcome, "Welcome");
            this.Welcome.BackColor = System.Drawing.Color.Transparent;
            this.Welcome.Name = "Welcome";
            // 
            // MainWelcome
            // 
            this.MainWelcome.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.MainWelcome, "MainWelcome");
            this.MainWelcome.ForeColor = System.Drawing.Color.Cyan;
            this.MainWelcome.Name = "MainWelcome";
            // 
            // GOUT
            // 
            resources.ApplyResources(this.GOUT, "GOUT");
            this.GOUT.Name = "GOUT";
            this.GOUT.UseVisualStyleBackColor = true;
            // 
            // INLT
            // 
            resources.ApplyResources(this.INLT, "INLT");
            this.INLT.Name = "INLT";
            this.INLT.UseVisualStyleBackColor = true;
            // 
            // 更改密码
            // 
            resources.ApplyResources(this.更改密码, "更改密码");
            this.更改密码.Name = "更改密码";
            this.更改密码.UseVisualStyleBackColor = true;
            this.更改密码.Click += new System.EventHandler(this.更改密码_Click);
            // 
            // 新密码
            // 
            resources.ApplyResources(this.新密码, "新密码");
            this.新密码.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.新密码.Name = "新密码";
            this.新密码.MouseClick += new System.Windows.Forms.MouseEventHandler(this.新密码_MouseClick);
            this.新密码.TextChanged += new System.EventHandler(this.新密码_TextChanged);
            // 
            // 确认密码
            // 
            resources.ApplyResources(this.确认密码, "确认密码");
            this.确认密码.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.确认密码.Name = "确认密码";
            this.确认密码.MouseClick += new System.Windows.Forms.MouseEventHandler(this.确认密码_MouseClick);
            this.确认密码.TextChanged += new System.EventHandler(this.确认密码_TextChanged);
            // 
            // moduptime
            // 
            resources.ApplyResources(this.moduptime, "moduptime");
            this.moduptime.BackColor = System.Drawing.Color.Transparent;
            this.moduptime.Name = "moduptime";
            // 
            // Updatetext
            // 
            resources.ApplyResources(this.Updatetext, "Updatetext");
            this.Updatetext.Name = "Updatetext";
            this.Updatetext.ReadOnly = true;
            // 
            // seeup
            // 
            resources.ApplyResources(this.seeup, "seeup");
            this.seeup.Name = "seeup";
            this.seeup.UseVisualStyleBackColor = true;
            this.seeup.Click += new System.EventHandler(this.seeup_Click);
            // 
            // 软件版本
            // 
            resources.ApplyResources(this.软件版本, "软件版本");
            this.软件版本.BackColor = System.Drawing.Color.Transparent;
            this.软件版本.Name = "软件版本";
            // 
            // Updater
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HMinecraftServerUpdate.Properties.Resources.BG;
            this.Controls.Add(this.软件版本);
            this.Controls.Add(this.seeup);
            this.Controls.Add(this.Updatetext);
            this.Controls.Add(this.moduptime);
            this.Controls.Add(this.确认密码);
            this.Controls.Add(this.新密码);
            this.Controls.Add(this.更改密码);
            this.Controls.Add(this.GOUT);
            this.Controls.Add(this.Welcome);
            this.Controls.Add(this.Usernameenter);
            this.Controls.Add(this.Userpasswordsenter);
            this.Controls.Add(this.UserPhoto);
            this.Controls.Add(this.HelloUsername);
            this.Controls.Add(this.Loginbt);
            this.Controls.Add(this.SkinUpload);
            this.Controls.Add(this.changeskin);
            this.Controls.Add(this.skin);
            this.Controls.Add(this.SkinRoad);
            this.Controls.Add(this.ChangingWallpaperTEXT);
            this.Controls.Add(this.FailedChangeWallpaper);
            this.Controls.Add(this.OnlineCheckWallpaper);
            this.Controls.Add(this.ChangeIPButtonLocation);
            this.Controls.Add(this.ModDownloadLabel);
            this.Controls.Add(this.ModDownloadedByte);
            this.Controls.Add(this.UpdateMods);
            this.Controls.Add(this.minecraft);
            this.Controls.Add(this.ChangeminecraftButton);
            this.Controls.Add(this.minecraftRoad);
            this.Controls.Add(this.IPsaved);
            this.Controls.Add(this.ChangeIPButton);
            this.Controls.Add(this.ServerPost);
            this.Controls.Add(this.ServerIP);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.INLT);
            this.Controls.Add(this.MainWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Updater";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Start;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.RichTextBox ServerIP;
        private System.Windows.Forms.RichTextBox ServerPost;
        private System.Windows.Forms.Button ChangeIPButton;
        private System.Windows.Forms.Label IPsaved;
        private System.Windows.Forms.RichTextBox minecraftRoad;
        private System.Windows.Forms.Button ChangeminecraftButton;
        private System.Windows.Forms.Label minecraft;
        private System.Windows.Forms.Button UpdateMods;
        private System.Windows.Forms.ProgressBar ModDownloadedByte;
        private System.Windows.Forms.Label ModDownloadLabel;
        private System.Windows.Forms.Button ChangeIPButtonLocation;
        private System.Windows.Forms.CheckBox OnlineCheckWallpaper;
        private System.Windows.Forms.Label FailedChangeWallpaper;
        private System.Windows.Forms.Label ChangingWallpaperTEXT;
        private System.Windows.Forms.Label skin;
        private System.Windows.Forms.Button changeskin;
        private System.Windows.Forms.Button SkinUpload;
        private System.Windows.Forms.Button Loginbt;
        private System.Windows.Forms.RichTextBox SkinRoad;
        private System.Windows.Forms.Label HelloUsername;
        private System.Windows.Forms.PictureBox UserPhoto;
        private System.Windows.Forms.TextBox Userpasswordsenter;
        private System.Windows.Forms.TextBox Usernameenter;
        private System.Windows.Forms.Label Welcome;
        private System.Windows.Forms.Button GOUT;
        private System.Windows.Forms.Button INLT;
        private System.Windows.Forms.Button 更改密码;
        private System.Windows.Forms.TextBox 新密码;
        private System.Windows.Forms.TextBox 确认密码;
        private System.Windows.Forms.Label MainWelcome;
        private System.Windows.Forms.Label moduptime;
        private System.Windows.Forms.TextBox Updatetext;
        private System.Windows.Forms.Button seeup;
        private System.Windows.Forms.Label 软件版本;
    }
}

