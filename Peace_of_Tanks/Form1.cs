using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Text;

namespace Peace_of_Tanks
{
    public partial class MainWindow : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();

        public static event TankEvent MovePlayer1, MovePlayer2;  // делегат движение игроков
        public static event AnimateEvent DelayEvent;             // делегат задержка анимации (отрисовка с паузами между рисунками)
        public static event EnemyEvent MoveEnemy;                // делегат движение врагов

        int menu = 0;  // выбранный пункт меню
        int modeMenu = 0; // текущее меню
        bool secondPlayer = false, firstPlayer = true; // отображение первого и второго игрока
        int gameoverX = 355, gameoverY = 10, pauseGameOver = 100; // координаты плашка GameOver

        Statistics stats = new Statistics();

        PrivateFontCollection font;

        PlayerTank player1, player2;
        Settings setting = new Settings();
        LevelDesign level = new LevelDesign();

        List<BaseTank> tanks = new List<BaseTank>();
        List<EnemyTank> enemies = new List<EnemyTank>();
        List<Bullet> bullets = new List<Bullet>();
        List<Box> boxes = new List<Box>();
        List<Animation> animations = new List<Animation>();

        Graphics grMain, grMemory;
        Bitmap backgroundMain, backgroundMemory;

        Bitmap heart;
        Bitmap gameover;

        int timeSpawn;

        //движение и меню (клавиши)

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (modeMenu == 0)
            {
                if (e.KeyCode == Keys.Up && menu != 0)
                {
                    PicTank.Location = new Point(270, PicTank.Location.Y - 40);
                    menu--;
                }
                if (e.KeyCode == Keys.Down && menu != 4)
                {
                    PicTank.Location = new Point(270, PicTank.Location.Y + 40);
                    menu++;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (menu == 0)
                        setting.twoPlayer = false;
                    else if (menu == 1)
                        setting.twoPlayer = true;

                    if (menu == 2)
                        modeMenu = 5;
                    else if (menu == 3)
                        modeMenu = 6;
                    else if (menu == 4)
                        modeMenu = 7;
                    else modeMenu = 1;

                    MenuWorking();
                }
            }
            else
            if (modeMenu == 1)
            {
                if (e.KeyCode == Keys.Up && menu != 0)
                {
                    PicTank.Location = new Point(270, PicTank.Location.Y - 40);
                    menu--;
                }
                if (e.KeyCode == Keys.Down && menu != 2)
                {
                    PicTank.Location = new Point(270, PicTank.Location.Y + 40);
                    menu++;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (menu == 0)
                    {
                        setting.difficulty = 0;
                        setting.countEnemies = 15;
                        setting.hitPointsEnemy = 1;
                        setting.level = 1;
                        setting.lifesPlayer1 = 3;
                        setting.lifesPlayer2 = 3;
                        setting.pointsPlayer1 = 0;
                        setting.pointsPlayer2 = 0;
                        setting.speedEnemy = 2;
                        setting.pointsForEnemy = 80;
                        setting.timeSpawn = 300;
                        setting.pointsForPlayers = 500;
                    }
                    else if (menu == 1)
                    {
                        setting.difficulty = 1;
                        setting.countEnemies = 25;
                        setting.hitPointsEnemy = 1;
                        setting.level = 1;
                        setting.lifesPlayer1 = 2;
                        setting.lifesPlayer2 = 2;
                        setting.pointsPlayer1 = 0;
                        setting.pointsPlayer2 = 0;
                        setting.speedEnemy = 4;
                        setting.pointsForEnemy = 90;
                        setting.timeSpawn = 100;
                        setting.pointsForPlayers = 750;
                    }
                    else if (menu == 2)
                    {
                        setting.difficulty = 2;
                        setting.countEnemies = 50;
                        setting.hitPointsEnemy = 2;
                        setting.level = 1;
                        setting.lifesPlayer1 = 1;
                        setting.lifesPlayer2 = 1;
                        setting.pointsPlayer1 = 0;
                        setting.pointsPlayer2 = 0;
                        setting.speedEnemy = 5;
                        setting.pointsForEnemy = 100;
                        setting.timeSpawn = 50;
                        setting.pointsForPlayers = 1000;
                    }

                    modeMenu = 2;
                    MenuWorking();
                }
            }
            else if (modeMenu == 4)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EnterName1.Enabled = EnterName1.Visible = buttonName1.Visible = EnterName2.Enabled = EnterName2.Visible = buttonName2.Visible = false;
                    modeMenu = 0;
                    grMemory.DrawImage(BackgroundImage, 0, 0);
                    grMain.DrawImage(BackgroundImage, 0, 0);
                    PictureStat1.Visible = PictureStat2.Visible = false;
                    MenuWorking();
                }
            }
            else if (modeMenu == 5)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    labelStat1.Visible = labelStat2.Visible = labelStat3.Visible = labelStat4.Visible = labelStat5.Visible = labelStat6.Visible = false;
                    labelStat7.Visible = labelStat8.Visible = labelStat9.Visible = labelStat9.Visible = labelStat10.Visible = false;

                    modeMenu = 0;
                    grMemory.DrawImage(BackgroundImage, 0, 0);
                    grMain.DrawImage(BackgroundImage, 0, 0);
                    
                    MenuWorking();
                }
            }
            else if (modeMenu == 6)
            {
                RichRules.Visible = false;

                modeMenu = 0;
                grMemory.DrawImage(BackgroundImage, 0, 0);
                grMain.DrawImage(BackgroundImage, 0, 0);
                    
                MenuWorking();
            }
            else if (modeMenu == 7)
            {
                RichAbout.Visible = false;

                modeMenu = 0;
                grMemory.DrawImage(BackgroundImage, 0, 0);
                grMain.DrawImage(BackgroundImage, 0, 0);

                MenuWorking();
            }
            else
            {
                if (firstPlayer)
                {
                    if (e.KeyCode == Keys.Up)
                        player1.message.isUp = true;
                    else if (e.KeyCode == Keys.Down)
                        player1.message.isDown = true;
                    else if (e.KeyCode == Keys.Left)
                        player1.message.isLeft = true;
                    else if (e.KeyCode == Keys.Right)
                        player1.message.isRight = true;

                    else if (e.KeyCode == Keys.NumPad0 && player1.message.pauseSpace == 0)
                    {
                        player1.message.isSpace = true;
                        player1.message.pauseSpace = 10;
                        Bullet bullet = new Bullet(player1.pictureBullet, player1.x, player1.y, player1.direction, 1);
                        bullets.Add(bullet);
                    }
                }

                if (secondPlayer)
                {
                    if (e.KeyCode == Keys.W)
                        player2.message.isUp = true;
                    else if (e.KeyCode == Keys.S)
                        player2.message.isDown = true;
                    else if (e.KeyCode == Keys.A)
                        player2.message.isLeft = true;
                    else if (e.KeyCode == Keys.D)
                        player2.message.isRight = true;

                    else if (e.KeyCode == Keys.Space && player2.message.pauseSpace == 0)
                    {
                        player2.message.isSpace = true;
                        player2.message.pauseSpace = 10;
                        Bullet bullet = new Bullet(player2.pictureBullet, player2.x, player2.y, player2.direction, 2);
                        bullets.Add(bullet);
                    }
                }
            }
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (modeMenu == 3)
            {
                if (firstPlayer)
                {
                    if (e.KeyCode == Keys.Up)
                        player1.message.isUp = false;
                    else if (e.KeyCode == Keys.Down)
                        player1.message.isDown = false;
                    else if (e.KeyCode == Keys.Left)
                        player1.message.isLeft = false;
                    else if (e.KeyCode == Keys.Right)
                        player1.message.isRight = false;

                    else if (e.KeyCode == Keys.NumPad0)
                        player1.message.isSpace = false;
                }

                if (secondPlayer)
                {
                    if (e.KeyCode == Keys.W)
                        player2.message.isUp = false;
                    else if (e.KeyCode == Keys.S)
                        player2.message.isDown = false;
                    else if (e.KeyCode == Keys.A)
                        player2.message.isLeft = false;
                    else if (e.KeyCode == Keys.D)
                        player2.message.isRight = false;

                    else if (e.KeyCode == Keys.Space)
                        player2.message.isSpace = false;
                }
            }
        }

        private void fontsProjects()
        {
            font = new PrivateFontCollection();
            font.AddFontFile("font/FontBit.ttf");
        }

        private void fonts()
        {
            //Задаем шрифт текста, отображаемого элементом управления.
            EnterName1.Font = new Font(font.Families[0], 16);
            EnterName2.Font = new Font(font.Families[0], 16);
            buttonName1.Font = new Font(font.Families[0], 16);
            buttonName2.Font = new Font(font.Families[0], 16);

            RichAbout.Font = new Font(font.Families[0], 20);
            RichRules.Font = new Font(font.Families[0], 16);

            labelStat1.Font = new Font(font.Families[0], 18);
            labelStat2.Font = new Font(font.Families[0], 18);
            labelStat3.Font = new Font(font.Families[0], 18);
            labelStat4.Font = new Font(font.Families[0], 18);
            labelStat5.Font = new Font(font.Families[0], 18);
            labelStat6.Font = new Font(font.Families[0], 18);
            labelStat7.Font = new Font(font.Families[0], 18);
            labelStat8.Font = new Font(font.Families[0], 18);
            labelStat9.Font = new Font(font.Families[0], 18);
            labelStat10.Font = new Font(font.Families[0], 18);
        }

        //меню вверхнее

        private void MainWindow_Load(object sender, EventArgs e)
        {
            heart = new Bitmap(Peace_of_Tanks.Properties.Resources.heart);
            gameover = new Bitmap(Peace_of_Tanks.Properties.Resources.gameover, 100, 50);
            BackgroundImage = Peace_of_Tanks.Properties.Resources.blackSquare;

            RichAbout.Text = "      СОЗДАТЕЛЬ      \n" + "\n" +
                             "   АЛЕКСАНДР БОРИСОВ   \n" + "\n" +
                             "     ГРУППА 2-41      \n" + "\n" +
                             "      2018 ПОКС        ";

            RichRules.Text = "Задача игрока или игроков\n" + "\n" +
                             "заключается в том, чтобы набрать\n" + "\n" +
                             "максимальное количество очков.\n" + "\n" +
                             "Очки получаются за уничтожение\n" + "\n" +
                             "ботов и другого игрока.\n" + "\n" +
                             "Игра завершится, если у игроков\n" + "\n" +
                             "кончатся жизни или они \n" + "\n" +
                             "уничтожат всех соперников.\n" + "\n" +
                             "Управление 1 игрока: стрелки - \n" + "\n" +
                             "движение, 'Num0' - выстрел.\n" + "\n" +
                             "Управление 2 игрока: WASD - \n" + "\n" +
                             "движение, 'Space' - выстрел.\n" + "\n";

            //меню 0
            PicButton1Player.Image = Peace_of_Tanks.Properties.Resources._1player;
            PicButton2Player.Image = Peace_of_Tanks.Properties.Resources._2player;
            PicturePlayer1_.Image = Peace_of_Tanks.Properties.Resources._1player;
            picturePlayer2_.Image = Peace_of_Tanks.Properties.Resources.player2_short;
            picturePlayer2_.SizeMode = PictureBoxSizeMode.StretchImage;
            PicRules.Image = Peace_of_Tanks.Properties.Resources.rules;
            PicRules.SizeMode = PictureBoxSizeMode.StretchImage;
            PicAbout.Image = Peace_of_Tanks.Properties.Resources.about;
            PicAbout.SizeMode = PictureBoxSizeMode.StretchImage;
            PicButtonStat.Image = Peace_of_Tanks.Properties.Resources.statistic;
            PicButtonStat.SizeMode = PictureBoxSizeMode.StretchImage;
            PicTank.Image = Peace_of_Tanks.Properties.Resources.PicTank;
            PicTank.SizeMode = PictureBoxSizeMode.StretchImage;
            //меню 1
            PicButtonEasy.Image = Peace_of_Tanks.Properties.Resources.easy;
            PicButtonEasy.SizeMode = PictureBoxSizeMode.StretchImage;
            PicButtonHard.Image = Peace_of_Tanks.Properties.Resources.hard;
            PicButtonHard.SizeMode = PictureBoxSizeMode.StretchImage;
            PicButtonReal.Image = Peace_of_Tanks.Properties.Resources.real;
            PicButtonReal.SizeMode = PictureBoxSizeMode.StretchImage;
            //меню 2
            PicLevel.Image = Peace_of_Tanks.Properties.Resources._1level;
            PicLevel.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void MenuWorking()
        {
            if (modeMenu == 0)
            {
                PicButton1Player.Visible = PicButton2Player.Visible = PicButtonStat.Visible = PicRules.Visible = PicAbout.Visible = true;
                PicButton1Player.Show();
                PicButton2Player.Show();
                PicButtonStat.Show();
                PicTank.Show();
                PicTank.Location = new Point(270, 325);
                menu = 0;
            }
            else if (modeMenu == 1)
            {
                PicButton1Player.Visible = PicButton2Player.Visible = PicButtonStat.Visible = PicRules.Visible = PicAbout.Visible = false;
                PicTank.Location = new Point(270, 325);
                menu = 0;
                PicButtonEasy.Visible = PicButtonHard.Visible = PicButtonReal.Visible = true;
            }
            else if(modeMenu == 2)
            {
                PicButtonEasy.Visible = PicButtonHard.Visible = PicButtonReal.Visible =  PicTank.Visible = PicRules.Visible = PicAbout.Visible = false;
                PicTank.Location = new Point(270, 325);
                menu = 0;
                PicLevel.Visible = true;
                TimerPause.Enabled = true;
            }
            else if(modeMenu == 3)
            {
                isReadyTo1Level();
                timer1.Interval = 25;
                timer1.Enabled = true;
            }
            else if (modeMenu == 4)
            {
                timer1.Enabled = false;
                picturePlayer2_.Visible = false;
                PicturePlayer1_.Visible = false;
                grMemory.DrawImage(BackgroundImage, 0, 0);
                grMain.DrawImage(BackgroundImage, 0, 0);
                timer1.Enabled = false;
                StatisticMenu();

                grMain.DrawImage(backgroundMemory, 0, 0);
            }
            else if (modeMenu == 5)
            {
                grMemory.DrawImage(BackgroundImage, 0, 0);
                grMain.DrawImage(BackgroundImage, 0, 0);

                PicButton1Player.Visible = PicButton2Player.Visible = PicButtonStat.Visible = PicTank.Visible = PicRules.Visible = PicAbout.Visible = false;

                ShowStatistic();

                grMain.DrawImage(backgroundMemory, 0, 0);
            }
            else if (modeMenu == 6)
            {
                grMemory.DrawImage(BackgroundImage, 0, 0);
                grMain.DrawImage(BackgroundImage, 0, 0);

                PicButton1Player.Visible = PicButton2Player.Visible = PicButtonStat.Visible = PicTank.Visible = PicRules.Visible = PicAbout.Visible = false;

                RichRules.Visible = true;
                RichRules.ReadOnly = true;

                grMain.DrawImage(backgroundMemory, 0, 0);
            }
            else if (modeMenu == 7)
            {
                grMemory.DrawImage(BackgroundImage, 0, 0);
                grMain.DrawImage(BackgroundImage, 0, 0);

                PicButton1Player.Visible = PicButton2Player.Visible = PicButtonStat.Visible = PicTank.Visible = PicRules.Visible = PicAbout.Visible = false;

                RichAbout.Visible = true;
                RichAbout.ReadOnly = true;

                grMain.DrawImage(backgroundMemory, 0, 0);
            }
        }

        private void TimerPause_Tick(object sender, EventArgs e)
        {
            TimerPause.Enabled = false;
            PicLevel.Visible = false;
            modeMenu = 3;
            MenuWorking();
        }

        private void buttonName1_Click(object sender, EventArgs e)
        {
            setting.stats1.name = EnterName1.Text;
            EnterName1.Enabled = false;
            stats.Add_new_record(setting.stats1);
        }

        private void buttonName2_Click(object sender, EventArgs e)
        {
            setting.stats2.name = EnterName2.Text;
            EnterName2.Enabled = false;
            stats.Add_new_record(setting.stats2);
        }

        //закрытие формы (сохранение)
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (FileStream fs = new FileStream("stats.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, stats);
            }
        }

        private void WriteNameLabelStat(int i, string name)
        {
            if (i == 0) labelStat1.Text = name;
            if (i == 1) labelStat2.Text = name;
            if (i == 2) labelStat3.Text = name;
            if (i == 3) labelStat4.Text = name;
            if (i == 4) labelStat5.Text = name;
            if (i == 5) labelStat6.Text = name;
            if (i == 6) labelStat7.Text = name;
            if (i == 7) labelStat8.Text = name;
            if (i == 8) labelStat9.Text = name;
            if (i == 9) labelStat10.Text = name;
        }

        private void ShowStatistic()
        {
            int countDegree = 0;
            int numBuf;
            int[] masNum = new int[10];
            int bufPoints;

            int y = 200, x = 320;

            labelStat1.Visible = labelStat2.Visible = labelStat3.Visible = labelStat4.Visible = labelStat5.Visible = labelStat6.Visible = true;
            labelStat7.Visible = labelStat8.Visible = labelStat9.Visible = labelStat9.Visible = labelStat10.Visible = true;

            for (int i = 0; i < 10; i++)
            {
                countDegree = 0;
                x = 320;

                WriteNameLabelStat(i, stats.statistic[i].name);

                bufPoints = stats.statistic[i].points;

                if (bufPoints == 0)
                    Numbers.Draw(grMemory, Numbers.ReturnNumPic(0), x += 30 , y);
                else
                    while (bufPoints != 0)
                    {
                        numBuf = bufPoints % 10;
                        masNum[countDegree] = numBuf;
                        bufPoints /= 10;
                        countDegree++;
                    }

                for (int j = countDegree - 1; j >= 0; j--)
                {
                    Numbers.Draw(grMemory, Numbers.ReturnNumPic(masNum[j]), x += 30, y);
                    x += 15;
                }

                y += 40;
            }
        }

        private void StatisticMenu()
        {
            PictureStat1.Visible =  true;
            PictureStat1.Image = Peace_of_Tanks.Properties.Resources._1player;

            if (stats.CheckRecord(setting.stats1))
                EnterName1.Enabled = EnterName1.Visible = buttonName1.Visible  = true;
            if (stats.CheckRecord(setting.stats2))
                EnterName2.Enabled = EnterName2.Visible = buttonName2.Visible= true;

            int countDegree = 0;
            int numBuf;
            int[] masNum = new int[10];
            int bufPoints = setting.pointsPlayer1;

            int x = 300, y = 180;

            if (bufPoints == 0)
                Numbers.Draw(grMemory, Numbers.ReturnNumPic(0), x, 180);
            else
                while (bufPoints != 0)
                {
                    numBuf = bufPoints % 10;
                    masNum[countDegree] = numBuf;
                    bufPoints /= 10;
                    countDegree++;
                }

            for (int i = countDegree - 1; i >= 0; i--)
            {
                Numbers.Draw(grMemory, Numbers.ReturnNumPic(masNum[i]), x, 180);
                x += 30;
            }

            if (setting.twoPlayer)
            {
                PictureStat2.Visible = true;
                PictureStat2.Image = Peace_of_Tanks.Properties.Resources.player2_short;

                countDegree = 0;
                bufPoints = setting.pointsPlayer2;

                x = 300;

                if (bufPoints == 0)
                    Numbers.Draw(grMemory, Numbers.ReturnNumPic(0), x, 240);
                else
                    while (bufPoints != 0)
                    {
                        numBuf = bufPoints % 10;
                        masNum[countDegree] = numBuf;
                        bufPoints /= 10;
                        countDegree++;
                    }

                for (int i = countDegree - 1; i >= 0; i--)
                {
                    Numbers.Draw(grMemory, Numbers.ReturnNumPic(masNum[i]), x, 240);
                    x += 30;
                }
            }
        }

        private void isReadyTo1Level()
        {
            if (setting.level == 1)
            {
                gameoverX = 355; gameoverY = 10; pauseGameOver = 100;

                firstPlayer = true;
                tanks.Add(player1);
                tanks.Add(player2);

                player1.hitpoints = 1;

                level.Level1(this, boxes);

                timeSpawn = setting.timeSpawn;
                EnemyTank enemy = new EnemyTank(Peace_of_Tanks.Properties.Resources.enemy11, Peace_of_Tanks.Properties.Resources.enemy12,
                    Peace_of_Tanks.Properties.Resources.bulletEnemy, level.masPointsSpawnEnemy[0, 0], level.masPointsSpawnEnemy[0, 1], 2);
                enemies.Add(enemy);
                tanks.Add(enemy);
                MoveEnemy += enemy.Move;
                enemy = new EnemyTank(Peace_of_Tanks.Properties.Resources.enemy11, Peace_of_Tanks.Properties.Resources.enemy12,
                    Peace_of_Tanks.Properties.Resources.bulletEnemy, level.masPointsSpawnEnemy[1, 0], level.masPointsSpawnEnemy[1, 1], 2);
                enemies.Add(enemy);
                tanks.Add(enemy);
                MoveEnemy += enemy.Move;
                enemy = new EnemyTank(Peace_of_Tanks.Properties.Resources.enemy11, Peace_of_Tanks.Properties.Resources.enemy12,
                    Peace_of_Tanks.Properties.Resources.bulletEnemy, level.masPointsSpawnEnemy[2, 0], level.masPointsSpawnEnemy[2, 1], 2);
                tanks.Add(enemy);
                enemies.Add(enemy);
                MoveEnemy += enemy.Move;

                player1.x = level.masPointsSpawnPlayers[0, 0];
                player1.y = level.masPointsSpawnPlayers[0, 1];
                MovePlayer1 += player1.Move;

                PicturePlayer1_.Visible = true;

                if (setting.twoPlayer)
                {
                    player2.hitpoints = 1;
                    player2.x = level.masPointsSpawnPlayers[2, 0];
                    player2.y = level.masPointsSpawnPlayers[2, 1];
                    MovePlayer2 += player2.Move;
                    picturePlayer2_.Visible = true;
                    secondPlayer = true;
                }
            }
        }
        //таймер (все логика)

        private void timer1_Tick(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////отрисовка нижней панель

            int x = 150, y = 760;
            for (int i = 0; i < setting.lifesPlayer1; i++)
            {
                grMemory.DrawImage(heart, x, y, 25, 25);
                x += 30;
            }
            if(setting.twoPlayer)
            {
                x = 530;
                for (int i = 0; i < setting.lifesPlayer2; i++)
                {
                    grMemory.DrawImage(heart, x, y, 25, 25);
                    x += 30;
                }
            }

            int countDegree = 0;
            int numBuf;
            int[] masNum = new int[10];
            int bufPoints = setting.pointsPlayer1;

            x = 255;

            if (bufPoints == 0)
                Numbers.Draw(grMemory, Numbers.ReturnNumPic(0), x, 760);
            else
                while(bufPoints != 0)
                {
                    numBuf = bufPoints % 10;
                    masNum[countDegree] = numBuf;
                    bufPoints /= 10;
                    countDegree++;
                }

            for (int i = countDegree - 1; i >= 0; i--)
            {
                Numbers.Draw(grMemory, Numbers.ReturnNumPic(masNum[i]), x, 760);
                x += 30;
            }

            if(setting.twoPlayer)
            {
                countDegree = 0;
                bufPoints = setting.pointsPlayer2;

                x = 633;

                if (bufPoints == 0)
                    Numbers.Draw(grMemory, Numbers.ReturnNumPic(0), x, 760);
                else
                    while (bufPoints != 0)
                    {
                        numBuf = bufPoints % 10;
                        masNum[countDegree] = numBuf;
                        bufPoints /= 10;
                        countDegree++;
                    }

                for (int i = countDegree - 1; i >= 0; i--)
                {
                    Numbers.Draw(grMemory, Numbers.ReturnNumPic(masNum[i]), x, 760);
                    x += 30;
                }
            }

            /////////////////////////////////////////////////////спавн ботов
            if (timeSpawn == 0 && setting.countEnemies >= 0)
            {
                Random random = new Random();
                bool[] mas = new bool[4] { false, false, false, false };
                int num = random.Next(0, 4);

                for (int i = 0; i < tanks.Count; i++)
                    for (int j = 0; j < 3; j++)
                        if (Collisions.check_touch(level.masPointsSpawnEnemy[j, 0], level.masPointsSpawnEnemy[j, 1], tanks[i].x, tanks[i].y))
                            mas[j] = true;

                num = random.Next(0, 4);
                if (mas[0] == true && mas[1] == true && mas[2] == true)
                {
                    timeSpawn = setting.timeSpawn;
                }
                else
                {
                    while (mas[num] == true)
                    {
                        num = random.Next(0, 4);
                    }

                    EnemyTank enemy = new EnemyTank(Peace_of_Tanks.Properties.Resources.enemy11, Peace_of_Tanks.Properties.Resources.enemy12,
                        Peace_of_Tanks.Properties.Resources.bulletEnemy, level.masPointsSpawnEnemy[num, 0], level.masPointsSpawnEnemy[num, 1], 2);
                    enemies.Add(enemy);
                    tanks.Add(enemy);
                    MoveEnemy += enemy.Move;

                    timeSpawn = setting.timeSpawn;
                }
            }
            else
                timeSpawn--;

            //////////////////////////////////////////////проверка столкновений
            for (int i = 0; i < bullets.Count; i++) //проверка столкновения пуль и ящиков
            {
                bool bulletDeath = false;
                for (int j = 0; j < boxes.Count; j++)
                {
                    if (!bulletDeath && Collisions.check_touch(this, bullets[i], boxes[j]) == 2)
                    {
                        boxes[j].hitPoint--;
                        if (boxes[j].hitPoint == 0)
                        {
                            Animation anim = new Animation();

                            anim.message.x = boxes[j].x;
                            anim.message.y = boxes[j].y;
                            anim.message.type = 0;
                            anim.message.delay = 10;
                            DelayEvent += anim.Delay;

                            animations.Add(anim);

                            boxes.RemoveAt(j);
                        }
                        bullets.RemoveAt(i);

                        bulletDeath = true;

                        break;
                    }
                    else if (!bulletDeath && Collisions.check_touch(this, bullets[i], boxes[j]) == 1)
                    {
                        bullets.RemoveAt(i);
                        bulletDeath = true;

                        break;
                    }
                }

                //столкновение пуль с ботами
                for(int j = 0; j < enemies.Count; j++)
                {
                    if(!bulletDeath && Collisions.check_touch(bullets[i], enemies[j]) )
                    {
                        if (bullets[i].who == 1)
                            setting.pointsPlayer1 += setting.pointsForEnemy;
                        else if (bullets[i].who == 2)
                            setting.pointsPlayer2 += setting.pointsForEnemy;

                        if (bullets[i].who != 0)
                        {
                            enemies[j].hitpoints--;
                            bullets.RemoveAt(i);
                            setting.countEnemies--;
                            bulletDeath = true;

                            break;
                        }
                    }
                }

                //столкновение пуль с 1 игроком
                if (!bulletDeath && firstPlayer && Collisions.check_touch(bullets[i], player1))
                {
                    if(bullets[i].who == 2)
                        setting.pointsPlayer2 += setting.pointsForPlayers;

                    player1.hitpoints--;
                    bullets.RemoveAt(i);
                    bulletDeath = true;
                }

                //столкновение пуль со 2 игроком
                if (!bulletDeath && secondPlayer && Collisions.check_touch(bullets[i], player2))
                {
                    if (bullets[i].who == 1)
                        setting.pointsPlayer1 += setting.pointsForPlayers;

                    player2.hitpoints--;
                    bullets.RemoveAt(i);
                    bulletDeath = true;
                }

                //движение пули
                if (!bulletDeath)
                    bullets[i].Move();
                else
                {
                    i--;
                }
            }

            //задержка отрисовки анимации  (делегат)
            if(DelayEvent != null)
                DelayEvent(); 

            //движение ботов
            if (MoveEnemy != null)
            {
                for (int i = 0; i < setting.speedEnemy; i++)
                    MoveEnemy(this, boxes, bullets, tanks);
            };

            /////////////////////////////////////// отрисовка

            for (int i = 0; i < boxes.Count; i++) //отрисовка ящиков
            {
                if (!(boxes[i] is Box_Green))
                    boxes[i].Draw(grMemory);
            }
            for (int i = 0; i < bullets.Count; i++) //отрисовка пуль
            {
                bullets[i].Draw(grMemory);
            }
            for (int i = 0; i < enemies.Count; i++) //отрисовка ботов
            {
                enemies[i].Draw(grMemory);
            }

            if (firstPlayer) player1.Draw(grMemory);                    // отрисовка танков игроков
            if (secondPlayer) player2.Draw(grMemory);                   

            for (int i = 0; i < boxes.Count; i++) // отрисовка лесных ящиков, позже отрисовки танков, чтобы танк мог прятаться в лесу
            {
                if (boxes[i] is Box_Green)
                    boxes[i].Draw(grMemory);
            }

            for(int i = 0; i < animations.Count; i++) // отрисовка анимации
                animations[i].Draw(grMemory);

            ////////////////////////////////////////////////////////////////////////проверка конца игры

            if ((setting.lifesPlayer1 == 0 && !setting.twoPlayer) || ((setting.lifesPlayer2 == 0  && setting.lifesPlayer1 == 0) && setting.twoPlayer)
                || setting.countEnemies <= 0)
            {
                if (setting.countEnemies <= 0)
                {
                    pauseGameOver -= 1;
                }
                else
                if (gameoverY <= 350)
                {
                    grMemory.DrawImage(gameover, gameoverX, gameoverY += 8);
                }
                else
                {
                    grMemory.DrawImage(gameover, gameoverX, gameoverY);
                    pauseGameOver -= 1;
                }

                if (pauseGameOver == 0)   /////////////// сохранение статистики
                {
                    stats bufStat = new stats();
                    bufStat.difficulty = setting.difficulty;
                    bufStat.hearts = setting.lifesPlayer1;
                    if (setting.twoPlayer)
                        bufStat.mode = 2;
                    else bufStat.mode = 1;
                    bufStat.points = setting.pointsPlayer1;

                    setting.stats1 = bufStat;

                    bufStat = new stats();
                    bufStat.hearts = setting.lifesPlayer2;
                    bufStat.points = setting.pointsPlayer2;

                    setting.stats2 = bufStat;

                    for (int i = 0; i < enemies.Count; i++)
                        MoveEnemy -= enemies[i].Move;
                    enemies.Clear();
                    boxes.Clear();
                    tanks.Clear();
                    bullets.Clear();

                    PicturePlayer1_.Visible = picturePlayer2_.Visible = false;

                    MovePlayer1 -= player1.Move;
                    MovePlayer2 -= player2.Move;

                    modeMenu = 4;
                    MenuWorking();

                    return;
                }
            }

            grMain.DrawImage(backgroundMemory, 0, 0);
            grMemory.DrawImage(backgroundMain, 0, 0);

            ////////////////////////////////////////////////////////////// логика

            if (player1.message.pauseSpace > 0) player1.message.pauseSpace--;                    // пауза между выстрелами у игроков
            if (secondPlayer && player2.message.pauseSpace > 0) player2.message.pauseSpace--;     //

            for (int i = 0; i < enemies.Count; i++) //пауза между выстрелами у ботов
                enemies[i].message.pauseSpace--;

            for (int i = 0; i < 5; i++)                                                         // движение танков(внутри проверка на соприкосновения танков)
            {
                if (firstPlayer) MovePlayer1(this, null, player1.message, boxes, tanks);
                if (secondPlayer) MovePlayer2(this, null, player2.message, boxes, tanks);
            }

            {
                if (firstPlayer)                                               //сообщение кто есть в игре (тольк 1 или 2 игрок, оба, или никого)
                {
                    EnemyEventArgs.player1X = player1.x;
                    EnemyEventArgs.player1Y = player1.y;
                    EnemyEventArgs.players = 1;
                }
                if (secondPlayer)
                {
                    EnemyEventArgs.player2X = player2.x;
                    EnemyEventArgs.player2Y = player2.y;
                    EnemyEventArgs.players = 2;
                }
                if (firstPlayer && secondPlayer)
                {
                    EnemyEventArgs.player1X = player1.x;
                    EnemyEventArgs.player1Y = player1.y;
                    EnemyEventArgs.player2X = player2.x;
                    EnemyEventArgs.player2Y = player2.y;
                    EnemyEventArgs.players = 3;
                }
                else if (firstPlayer == false && secondPlayer == false)
                    EnemyEventArgs.players = 0;
            }

            for (int i = 0; i < enemies.Count; i++)                           //уничтожение врагов при хп = 0
            {
                if(enemies[i].hitpoints == 0)
                {
                    Animation anim = new Animation();

                    anim.message.x = enemies[i].x;
                    anim.message.y = enemies[i].y;
                    anim.message.type = 1;
                    anim.message.delay = 10;
                    DelayEvent += anim.Delay;

                    animations.Add(anim);

                    MoveEnemy -= enemies[i].Move;
                    tanks.RemoveAt(i + 2);
                    enemies.RemoveAt(i);
                    i--;
                }
            }

            if (secondPlayer && player2.hitpoints == 0)  // уничтожение второго игрока
            {
                setting.lifesPlayer2--;
                                
                Animation anim = new Animation();

                anim.message.x = player2.x;
                anim.message.y = player2.y;
                anim.message.type = 1;
                anim.message.delay = 10;
                DelayEvent += anim.Delay;

                animations.Add(anim);

                Random RanNum = new Random();
                int num = RanNum.Next(0, 4);
                if (setting.lifesPlayer2 > 0)
                {
                    player2.x = level.masPointsSpawnPlayers[num, 0];
                    player2.y = level.masPointsSpawnPlayers[num, 1];
                    player2.hitpoints = 1;
                }
                else
                {
                    player2.x = player2.y = -50;
                    secondPlayer = false;
                }
                    
            }
            if (firstPlayer && player1.hitpoints == 0) // уничтожение первого игрока
            {
                setting.lifesPlayer1--;
                
                Animation anim = new Animation();

                anim.message.x = player1.x;
                anim.message.y = player1.y;
                anim.message.type = 1;
                anim.message.delay = 10;
                DelayEvent += anim.Delay;

                animations.Add(anim);

                Random RanNum = new Random();
                int num = RanNum.Next(0, 4);
                if (setting.lifesPlayer1 > 0)
                {
                    player1.x = level.masPointsSpawnPlayers[num, 0];
                    player1.y = level.masPointsSpawnPlayers[num, 1];
                    player1.hitpoints = 1;
                }
                else
                {
                    player1.x = player1.y = -50;
                    firstPlayer = false;
                }
            }

            for(int i = 0; i < animations.Count; i++)   // уничтожение анимации, если она завершилась (отписка, делегат)
            {
                if (animations[i].message.delay <= 0)
                {
                    DelayEvent -= animations[i].Delay;
                    animations.RemoveAt(i);
                }
            }          
        }

        //начальная инициализация
        public MainWindow()
        {
            InitializeComponent();

            backgroundMain = new Bitmap(Peace_of_Tanks.Properties.Resources.blackSquare);
            backgroundMemory = new Bitmap(Peace_of_Tanks.Properties.Resources.blackSquare);

            grMain = CreateGraphics();
            grMemory = Graphics.FromImage(backgroundMemory);

            Animation.boom1 = Peace_of_Tanks.Properties.Resources.boom1;
            Animation.boom2 = Peace_of_Tanks.Properties.Resources.boom2;
            Animation.boom3 = Peace_of_Tanks.Properties.Resources.boom3;
            Animation.megaBoom1 = Peace_of_Tanks.Properties.Resources.megaBoom1;
            Animation.megaBoom2 = Peace_of_Tanks.Properties.Resources.megaBoom2;

            player1 = new PlayerTank(Peace_of_Tanks.Properties.Resources.player1_1, Peace_of_Tanks.Properties.Resources.player1_2, Peace_of_Tanks.Properties.Resources.bullet1, -100, -100, 2);
            player2 = new PlayerTank(Peace_of_Tanks.Properties.Resources.player2_1, Peace_of_Tanks.Properties.Resources.player2_2, Peace_of_Tanks.Properties.Resources.bullet1, -50, -50, 2);

            if(File.Exists("stats.dat"))
            {
                using (FileStream fs = new FileStream("stats.dat", FileMode.OpenOrCreate))
                {
                    stats = (Statistics)formatter.Deserialize(fs);
                }
            }

            timer1.Interval = 25;

            fontsProjects();
            fonts();
        }
    }
}
