namespace Peace_of_Tanks
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimerPause = new System.Windows.Forms.Timer(this.components);
            this.EnterName1 = new System.Windows.Forms.TextBox();
            this.EnterName2 = new System.Windows.Forms.TextBox();
            this.buttonName1 = new System.Windows.Forms.Label();
            this.buttonName2 = new System.Windows.Forms.Label();
            this.labelStat1 = new System.Windows.Forms.Label();
            this.labelStat2 = new System.Windows.Forms.Label();
            this.labelStat3 = new System.Windows.Forms.Label();
            this.labelStat4 = new System.Windows.Forms.Label();
            this.labelStat5 = new System.Windows.Forms.Label();
            this.labelStat6 = new System.Windows.Forms.Label();
            this.labelStat7 = new System.Windows.Forms.Label();
            this.labelStat8 = new System.Windows.Forms.Label();
            this.labelStat9 = new System.Windows.Forms.Label();
            this.labelStat10 = new System.Windows.Forms.Label();
            this.PicAbout = new System.Windows.Forms.PictureBox();
            this.PicRules = new System.Windows.Forms.PictureBox();
            this.PictureStat2 = new System.Windows.Forms.PictureBox();
            this.PictureStat1 = new System.Windows.Forms.PictureBox();
            this.PicturePlayer1_ = new System.Windows.Forms.PictureBox();
            this.picturePlayer2_ = new System.Windows.Forms.PictureBox();
            this.PicLevel = new System.Windows.Forms.PictureBox();
            this.PicButtonReal = new System.Windows.Forms.PictureBox();
            this.PicButtonHard = new System.Windows.Forms.PictureBox();
            this.PicButtonEasy = new System.Windows.Forms.PictureBox();
            this.PicTank = new System.Windows.Forms.PictureBox();
            this.PicButtonStat = new System.Windows.Forms.PictureBox();
            this.PicButton2Player = new System.Windows.Forms.PictureBox();
            this.PicButton1Player = new System.Windows.Forms.PictureBox();
            this.RichAbout = new System.Windows.Forms.RichTextBox();
            this.RichRules = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureStat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureStat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicturePlayer1_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer2_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButtonReal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButtonHard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButtonEasy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButtonStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButton2Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButton1Player)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimerPause
            // 
            this.TimerPause.Interval = 1500;
            this.TimerPause.Tick += new System.EventHandler(this.TimerPause_Tick);
            // 
            // EnterName1
            // 
            this.EnterName1.BackColor = System.Drawing.SystemColors.MenuText;
            this.EnterName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterName1.Enabled = false;
            this.EnterName1.ForeColor = System.Drawing.SystemColors.Control;
            this.EnterName1.Location = new System.Drawing.Point(439, 174);
            this.EnterName1.Name = "EnterName1";
            this.EnterName1.Size = new System.Drawing.Size(230, 20);
            this.EnterName1.TabIndex = 13;
            this.EnterName1.Visible = false;
            // 
            // EnterName2
            // 
            this.EnterName2.BackColor = System.Drawing.SystemColors.MenuText;
            this.EnterName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterName2.Enabled = false;
            this.EnterName2.ForeColor = System.Drawing.SystemColors.Control;
            this.EnterName2.Location = new System.Drawing.Point(439, 233);
            this.EnterName2.Name = "EnterName2";
            this.EnterName2.Size = new System.Drawing.Size(230, 20);
            this.EnterName2.TabIndex = 14;
            this.EnterName2.Visible = false;
            // 
            // buttonName1
            // 
            this.buttonName1.AutoSize = true;
            this.buttonName1.BackColor = System.Drawing.SystemColors.MenuText;
            this.buttonName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonName1.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonName1.Location = new System.Drawing.Point(675, 174);
            this.buttonName1.Name = "buttonName1";
            this.buttonName1.Size = new System.Drawing.Size(15, 15);
            this.buttonName1.TabIndex = 15;
            this.buttonName1.Text = "+";
            this.buttonName1.Visible = false;
            this.buttonName1.Click += new System.EventHandler(this.buttonName1_Click);
            // 
            // buttonName2
            // 
            this.buttonName2.AutoSize = true;
            this.buttonName2.BackColor = System.Drawing.SystemColors.MenuText;
            this.buttonName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonName2.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonName2.Location = new System.Drawing.Point(675, 235);
            this.buttonName2.Name = "buttonName2";
            this.buttonName2.Size = new System.Drawing.Size(15, 15);
            this.buttonName2.TabIndex = 16;
            this.buttonName2.Text = "+";
            this.buttonName2.Visible = false;
            this.buttonName2.Click += new System.EventHandler(this.buttonName2_Click);
            // 
            // labelStat1
            // 
            this.labelStat1.AutoSize = true;
            this.labelStat1.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStat1.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStat1.Location = new System.Drawing.Point(100, 200);
            this.labelStat1.Name = "labelStat1";
            this.labelStat1.Size = new System.Drawing.Size(35, 13);
            this.labelStat1.TabIndex = 17;
            this.labelStat1.Text = "label1";
            this.labelStat1.Visible = false;
            // 
            // labelStat2
            // 
            this.labelStat2.AutoSize = true;
            this.labelStat2.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStat2.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStat2.Location = new System.Drawing.Point(100, 240);
            this.labelStat2.Name = "labelStat2";
            this.labelStat2.Size = new System.Drawing.Size(35, 13);
            this.labelStat2.TabIndex = 18;
            this.labelStat2.Text = "label2";
            this.labelStat2.Visible = false;
            // 
            // labelStat3
            // 
            this.labelStat3.AutoSize = true;
            this.labelStat3.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStat3.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStat3.Location = new System.Drawing.Point(100, 280);
            this.labelStat3.Name = "labelStat3";
            this.labelStat3.Size = new System.Drawing.Size(35, 13);
            this.labelStat3.TabIndex = 19;
            this.labelStat3.Text = "label3";
            this.labelStat3.Visible = false;
            // 
            // labelStat4
            // 
            this.labelStat4.AutoSize = true;
            this.labelStat4.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStat4.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStat4.Location = new System.Drawing.Point(100, 320);
            this.labelStat4.Name = "labelStat4";
            this.labelStat4.Size = new System.Drawing.Size(35, 13);
            this.labelStat4.TabIndex = 20;
            this.labelStat4.Text = "label4";
            this.labelStat4.Visible = false;
            // 
            // labelStat5
            // 
            this.labelStat5.AutoSize = true;
            this.labelStat5.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStat5.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStat5.Location = new System.Drawing.Point(100, 360);
            this.labelStat5.Name = "labelStat5";
            this.labelStat5.Size = new System.Drawing.Size(35, 13);
            this.labelStat5.TabIndex = 21;
            this.labelStat5.Text = "label5";
            this.labelStat5.Visible = false;
            // 
            // labelStat6
            // 
            this.labelStat6.AutoSize = true;
            this.labelStat6.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStat6.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStat6.Location = new System.Drawing.Point(100, 400);
            this.labelStat6.Name = "labelStat6";
            this.labelStat6.Size = new System.Drawing.Size(35, 13);
            this.labelStat6.TabIndex = 22;
            this.labelStat6.Text = "label6";
            this.labelStat6.Visible = false;
            // 
            // labelStat7
            // 
            this.labelStat7.AutoSize = true;
            this.labelStat7.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStat7.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStat7.Location = new System.Drawing.Point(100, 440);
            this.labelStat7.Name = "labelStat7";
            this.labelStat7.Size = new System.Drawing.Size(35, 13);
            this.labelStat7.TabIndex = 23;
            this.labelStat7.Text = "label7";
            this.labelStat7.Visible = false;
            // 
            // labelStat8
            // 
            this.labelStat8.AutoSize = true;
            this.labelStat8.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStat8.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStat8.Location = new System.Drawing.Point(100, 480);
            this.labelStat8.Name = "labelStat8";
            this.labelStat8.Size = new System.Drawing.Size(35, 13);
            this.labelStat8.TabIndex = 24;
            this.labelStat8.Text = "label8";
            this.labelStat8.Visible = false;
            // 
            // labelStat9
            // 
            this.labelStat9.AutoSize = true;
            this.labelStat9.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStat9.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStat9.Location = new System.Drawing.Point(100, 520);
            this.labelStat9.Name = "labelStat9";
            this.labelStat9.Size = new System.Drawing.Size(35, 13);
            this.labelStat9.TabIndex = 25;
            this.labelStat9.Text = "label9";
            this.labelStat9.Visible = false;
            // 
            // labelStat10
            // 
            this.labelStat10.AutoSize = true;
            this.labelStat10.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStat10.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStat10.Location = new System.Drawing.Point(100, 560);
            this.labelStat10.Name = "labelStat10";
            this.labelStat10.Size = new System.Drawing.Size(41, 13);
            this.labelStat10.TabIndex = 26;
            this.labelStat10.Text = "label10";
            this.labelStat10.Visible = false;
            // 
            // PicAbout
            // 
            this.PicAbout.Location = new System.Drawing.Point(335, 495);
            this.PicAbout.Name = "PicAbout";
            this.PicAbout.Size = new System.Drawing.Size(158, 16);
            this.PicAbout.TabIndex = 28;
            this.PicAbout.TabStop = false;
            // 
            // PicRules
            // 
            this.PicRules.Location = new System.Drawing.Point(335, 455);
            this.PicRules.Name = "PicRules";
            this.PicRules.Size = new System.Drawing.Size(115, 18);
            this.PicRules.TabIndex = 27;
            this.PicRules.TabStop = false;
            // 
            // PictureStat2
            // 
            this.PictureStat2.Location = new System.Drawing.Point(127, 237);
            this.PictureStat2.Name = "PictureStat2";
            this.PictureStat2.Size = new System.Drawing.Size(120, 30);
            this.PictureStat2.TabIndex = 12;
            this.PictureStat2.TabStop = false;
            this.PictureStat2.Visible = false;
            // 
            // PictureStat1
            // 
            this.PictureStat1.Location = new System.Drawing.Point(127, 174);
            this.PictureStat1.Name = "PictureStat1";
            this.PictureStat1.Size = new System.Drawing.Size(136, 35);
            this.PictureStat1.TabIndex = 11;
            this.PictureStat1.TabStop = false;
            this.PictureStat1.Visible = false;
            // 
            // PicturePlayer1_
            // 
            this.PicturePlayer1_.Location = new System.Drawing.Point(12, 754);
            this.PicturePlayer1_.Name = "PicturePlayer1_";
            this.PicturePlayer1_.Size = new System.Drawing.Size(136, 35);
            this.PicturePlayer1_.TabIndex = 10;
            this.PicturePlayer1_.TabStop = false;
            this.PicturePlayer1_.Visible = false;
            // 
            // picturePlayer2_
            // 
            this.picturePlayer2_.Location = new System.Drawing.Point(400, 755);
            this.picturePlayer2_.Name = "picturePlayer2_";
            this.picturePlayer2_.Size = new System.Drawing.Size(125, 30);
            this.picturePlayer2_.TabIndex = 9;
            this.picturePlayer2_.TabStop = false;
            this.picturePlayer2_.Visible = false;
            // 
            // PicLevel
            // 
            this.PicLevel.Location = new System.Drawing.Point(325, 366);
            this.PicLevel.Name = "PicLevel";
            this.PicLevel.Size = new System.Drawing.Size(120, 15);
            this.PicLevel.TabIndex = 8;
            this.PicLevel.TabStop = false;
            this.PicLevel.Visible = false;
            // 
            // PicButtonReal
            // 
            this.PicButtonReal.Location = new System.Drawing.Point(335, 425);
            this.PicButtonReal.Name = "PicButtonReal";
            this.PicButtonReal.Size = new System.Drawing.Size(155, 15);
            this.PicButtonReal.TabIndex = 7;
            this.PicButtonReal.TabStop = false;
            this.PicButtonReal.Visible = false;
            // 
            // PicButtonHard
            // 
            this.PicButtonHard.Location = new System.Drawing.Point(335, 380);
            this.PicButtonHard.Name = "PicButtonHard";
            this.PicButtonHard.Size = new System.Drawing.Size(95, 15);
            this.PicButtonHard.TabIndex = 6;
            this.PicButtonHard.TabStop = false;
            this.PicButtonHard.Visible = false;
            // 
            // PicButtonEasy
            // 
            this.PicButtonEasy.Location = new System.Drawing.Point(335, 335);
            this.PicButtonEasy.Name = "PicButtonEasy";
            this.PicButtonEasy.Size = new System.Drawing.Size(80, 15);
            this.PicButtonEasy.TabIndex = 5;
            this.PicButtonEasy.TabStop = false;
            this.PicButtonEasy.Visible = false;
            // 
            // PicTank
            // 
            this.PicTank.Location = new System.Drawing.Point(270, 320);
            this.PicTank.Name = "PicTank";
            this.PicTank.Size = new System.Drawing.Size(34, 35);
            this.PicTank.TabIndex = 4;
            this.PicTank.TabStop = false;
            // 
            // PicButtonStat
            // 
            this.PicButtonStat.Location = new System.Drawing.Point(334, 415);
            this.PicButtonStat.Name = "PicButtonStat";
            this.PicButtonStat.Size = new System.Drawing.Size(158, 16);
            this.PicButtonStat.TabIndex = 3;
            this.PicButtonStat.TabStop = false;
            // 
            // PicButton2Player
            // 
            this.PicButton2Player.Location = new System.Drawing.Point(325, 365);
            this.PicButton2Player.Name = "PicButton2Player";
            this.PicButton2Player.Size = new System.Drawing.Size(136, 35);
            this.PicButton2Player.TabIndex = 2;
            this.PicButton2Player.TabStop = false;
            // 
            // PicButton1Player
            // 
            this.PicButton1Player.Location = new System.Drawing.Point(325, 325);
            this.PicButton1Player.Name = "PicButton1Player";
            this.PicButton1Player.Size = new System.Drawing.Size(136, 35);
            this.PicButton1Player.TabIndex = 1;
            this.PicButton1Player.TabStop = false;
            // 
            // RichAbout
            // 
            this.RichAbout.BackColor = System.Drawing.SystemColors.MenuText;
            this.RichAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichAbout.ForeColor = System.Drawing.SystemColors.Window;
            this.RichAbout.Location = new System.Drawing.Point(120, 306);
            this.RichAbout.Name = "RichAbout";
            this.RichAbout.Size = new System.Drawing.Size(652, 301);
            this.RichAbout.TabIndex = 29;
            this.RichAbout.Text = "";
            this.RichAbout.Visible = false;
            // 
            // RichRules
            // 
            this.RichRules.BackColor = System.Drawing.SystemColors.MenuText;
            this.RichRules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichRules.ForeColor = System.Drawing.SystemColors.Window;
            this.RichRules.Location = new System.Drawing.Point(66, 99);
            this.RichRules.Name = "RichRules";
            this.RichRules.Size = new System.Drawing.Size(693, 690);
            this.RichRules.TabIndex = 30;
            this.RichRules.Text = "";
            this.RichRules.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 811);
            this.Controls.Add(this.RichRules);
            this.Controls.Add(this.RichAbout);
            this.Controls.Add(this.PicAbout);
            this.Controls.Add(this.PicRules);
            this.Controls.Add(this.labelStat10);
            this.Controls.Add(this.labelStat9);
            this.Controls.Add(this.labelStat8);
            this.Controls.Add(this.labelStat7);
            this.Controls.Add(this.labelStat6);
            this.Controls.Add(this.labelStat5);
            this.Controls.Add(this.labelStat4);
            this.Controls.Add(this.labelStat3);
            this.Controls.Add(this.labelStat2);
            this.Controls.Add(this.labelStat1);
            this.Controls.Add(this.buttonName2);
            this.Controls.Add(this.buttonName1);
            this.Controls.Add(this.EnterName2);
            this.Controls.Add(this.EnterName1);
            this.Controls.Add(this.PictureStat2);
            this.Controls.Add(this.PictureStat1);
            this.Controls.Add(this.PicturePlayer1_);
            this.Controls.Add(this.picturePlayer2_);
            this.Controls.Add(this.PicLevel);
            this.Controls.Add(this.PicButtonReal);
            this.Controls.Add(this.PicButtonHard);
            this.Controls.Add(this.PicButtonEasy);
            this.Controls.Add(this.PicTank);
            this.Controls.Add(this.PicButtonStat);
            this.Controls.Add(this.PicButton2Player);
            this.Controls.Add(this.PicButton1Player);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Peace of Tanks";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PicAbout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureStat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureStat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicturePlayer1_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer2_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButtonReal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButtonHard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButtonEasy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButtonStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButton2Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicButton1Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox PicButton1Player;
        private System.Windows.Forms.PictureBox PicButton2Player;
        private System.Windows.Forms.PictureBox PicButtonStat;
        private System.Windows.Forms.PictureBox PicTank;
        private System.Windows.Forms.PictureBox PicButtonEasy;
        private System.Windows.Forms.PictureBox PicButtonHard;
        private System.Windows.Forms.PictureBox PicButtonReal;
        private System.Windows.Forms.PictureBox PicLevel;
        private System.Windows.Forms.Timer TimerPause;
        private System.Windows.Forms.PictureBox picturePlayer2_;
        private System.Windows.Forms.PictureBox PicturePlayer1_;
        private System.Windows.Forms.PictureBox PictureStat1;
        private System.Windows.Forms.PictureBox PictureStat2;
        private System.Windows.Forms.TextBox EnterName1;
        private System.Windows.Forms.TextBox EnterName2;
        private System.Windows.Forms.Label buttonName1;
        private System.Windows.Forms.Label buttonName2;
        private System.Windows.Forms.Label labelStat1;
        private System.Windows.Forms.Label labelStat2;
        private System.Windows.Forms.Label labelStat3;
        private System.Windows.Forms.Label labelStat4;
        private System.Windows.Forms.Label labelStat5;
        private System.Windows.Forms.Label labelStat6;
        private System.Windows.Forms.Label labelStat7;
        private System.Windows.Forms.Label labelStat8;
        private System.Windows.Forms.Label labelStat9;
        private System.Windows.Forms.Label labelStat10;
        private System.Windows.Forms.PictureBox PicRules;
        private System.Windows.Forms.PictureBox PicAbout;
        private System.Windows.Forms.RichTextBox RichAbout;
        private System.Windows.Forms.RichTextBox RichRules;
    }
}

