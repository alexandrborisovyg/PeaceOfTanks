using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Peace_of_Tanks
{
    public class TankEventArgs : EventArgs
    {
        public bool isUp, isDown, isLeft, isRight, isSpace;
        public int pauseSpace = 0;
        public TankEventArgs() : base() { }

        public void clear()
        {
            isUp = isDown = isLeft = isRight = isSpace = false;
        }
    }

    public class EnemyEventArgs : EventArgs
    {
        public int pauseSpace = 50;
        public int pauseTurn = 100;
        public int goToPlayer;
        public static int player1X, player1Y, player2X, player2Y;
        public static int players; // 0 - no, 1 - 1 player, 2 - 2 player, 3 - both

        public EnemyEventArgs() : base() { }
    }

    public delegate void EnemyEvent(Form MainWindow, List<Box> boxes, List<Bullet> bullets, List<BaseTank> tanks);
    public delegate void TankEvent(Form MainWindow, KeyEventArgs e, TankEventArgs tank, List<Box> boxes, List<BaseTank> tanks);

    public class BaseTank
    {
        protected Bitmap pictureTank, pictureTank1, pictureTank2;
        protected bool changePicture;
        public Bitmap pictureBullet;
        public int hitpoints = 1;
        public int x, y;
        public int direction; //0 - left, 1 - right, 2 - up, 3 - down

        public BaseTank(Bitmap pictureTank1, Bitmap pictureTank2, Bitmap pictureBullet, int x, int y, int direction)
        {
            pictureTank1.MakeTransparent(Color.Black);
            pictureTank2.MakeTransparent(Color.Black);
            pictureBullet.MakeTransparent(Color.Black);
            this.pictureBullet = pictureBullet;
            this.pictureTank1 = pictureTank1;
            this.pictureTank2 = pictureTank2;
            pictureTank = pictureTank1;
            changePicture = false;
            this.x = x;
            this.y = y;
            this.direction = direction;
        }

        public void RotatePicture(Bitmap pictureTank, int direct, bool isUp, bool isDown, bool isLeft, bool isRight)
        {
            if (isLeft && direct == 2) pictureTank.RotateFlip(RotateFlipType.Rotate90FlipX);
            if (isLeft && direct == 1) pictureTank.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (isLeft && direct == 3) pictureTank.RotateFlip(RotateFlipType.Rotate90FlipNone);

            if (isUp && direct == 3) pictureTank.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (isUp && direct == 0) pictureTank.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (isUp && direct == 1) pictureTank.RotateFlip(RotateFlipType.Rotate90FlipY);

            if (isRight && direct == 3) pictureTank.RotateFlip(RotateFlipType.Rotate90FlipX);
            if (isRight && direct == 0) pictureTank.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (isRight && direct == 2) pictureTank.RotateFlip(RotateFlipType.Rotate90FlipNone);

            if (isDown && direct == 0) pictureTank.RotateFlip(RotateFlipType.Rotate90FlipY);
            if (isDown && direct == 1) pictureTank.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (isDown && direct == 2) pictureTank.RotateFlip(RotateFlipType.Rotate180FlipNone);
        }

        protected void changePictureFun()
        {
            if (changePicture)
            {
                pictureTank = pictureTank2;
                changePicture = false;
            }
            else
            {
                changePicture = true;
                pictureTank = pictureTank1;
            }
        }

        public void Draw(Graphics grMemory)
        {
            grMemory.DrawImage(pictureTank, x, y, 50, 50);
        }
    }

    class PlayerTank : BaseTank
    {
        public TankEventArgs message;
        public PlayerTank(Bitmap pictureTank1, Bitmap pictureTank2, Bitmap pictureBullet, int x, int y, int direction) : base(pictureTank1, pictureTank2, pictureBullet, x, y, direction)
        {
            message = new TankEventArgs();
        }

        public void Move(Form MainWindow, KeyEventArgs e, TankEventArgs message, List<Box> boxes, List<BaseTank> tanks)
        {
            int difference = 1, speed = 1;
            if (message.isLeft)
            {
                RotatePicture(pictureTank1, direction, false, false, true, false);
                RotatePicture(pictureTank2, direction, false, false, true, false);
                direction = 0;
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (Collisions.check_touch(x - difference, y, boxes[i], MainWindow))
                    {
                        return;
                    }
                }

                int I = 0;
                for (int i = 0; i < tanks.Count; i++)         //находит номер танка в массиве
                    if (tanks[i].x == x && tanks[i].y == y)
                    { I = i; break; }

                for(int i = 0; i < tanks.Count; i++) //проверка столкновения с другими танками
                {
                    if (I == i)
                        continue;

                    if (Collisions.check_touch(x - difference, y, tanks[i].x, tanks[i].y))
                        return;
                }

                x -= speed;

                changePictureFun();
            }
            else if (message.isUp)
            {
                RotatePicture(pictureTank1, direction, true, false, false, false);
                RotatePicture(pictureTank2, direction, true, false, false, false);
                direction = 2;
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (Collisions.check_touch(x, y - difference, boxes[i], MainWindow))
                    {
                        return;
                    }
                }

                int I = 0;
                for (int i = 0; i < tanks.Count; i++)
                    if (tanks[i].x == x && tanks[i].y == y)
                    { I = i; break; }

                for (int i = 0; i < tanks.Count; i++)
                {
                    if (I == i)
                        continue;

                    if (Collisions.check_touch(x, y - difference, tanks[i].x, tanks[i].y))
                        return;
                }

                y -= speed;

                changePictureFun();
            }
            else if (message.isRight)
            {
                RotatePicture(pictureTank1, direction, false, false, false, true);
                RotatePicture(pictureTank2, direction, false, false, false, true);
                direction = 1;
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (Collisions.check_touch(x + difference, y, boxes[i], MainWindow))
                    {
                        return;
                    }
                }

                int I = 0;
                for (int i = 0; i < tanks.Count; i++)
                    if (tanks[i].x == x && tanks[i].y == y)
                    { I = i; break; }

                for (int i = 0; i < tanks.Count; i++)
                {
                    if (I == i)
                        continue;

                    if (Collisions.check_touch(x + difference, y , tanks[i].x, tanks[i].y))
                        return;
                }

                x += speed;

                changePictureFun();
            }
            else if (message.isDown)
            {
                RotatePicture(pictureTank1, direction, false, true, false, false);
                RotatePicture(pictureTank2, direction, false, true, false, false);
                direction = 3;
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (Collisions.check_touch(x, y + difference, boxes[i], MainWindow))
                    {
                        return;
                    }
                }

                int I = 0;
                for (int i = 0; i < tanks.Count; i++)
                    if (tanks[i].x == x && tanks[i].y == y)
                    { I = i; break; }

                for (int i = 0; i < tanks.Count; i++)
                {
                    if (I == i)
                        continue;

                    if (Collisions.check_touch(x , y + difference, tanks[i].x, tanks[i].y))
                        return;
                }

                y += speed;

                changePictureFun();
            }
        }
    }

    class EnemyTank : BaseTank
    {
        Random ranNumber = new Random();

        int difference = 1;
        int goToPlayer;

        public EnemyEventArgs message;

        public EnemyTank(Bitmap pictureTank1, Bitmap pictureTank2, Bitmap pictureBullet, int x, int y, int direction) : base(pictureTank1, pictureTank2, pictureBullet, x, y, direction)
        {
            message = new EnemyEventArgs();
            goToPlayer = ranNumber.Next(1, 3);
        }

        int DirectPlayersAttached(bool [] nums) // nums содержит направления куда можно двигаться
        {
            bool[] numsBuf = new bool[4] { false, false, false, false };

            if (EnemyEventArgs.players == 1)
            {
                if (x < EnemyEventArgs.player1X && nums[1] == false)
                    numsBuf[1] = true;
                else if (x > EnemyEventArgs.player1X && nums[0] == false)
                    numsBuf[0] = true;
                if (y > EnemyEventArgs.player1Y && nums[2] == false)
                    numsBuf[2] = true;
                else if (y < EnemyEventArgs.player1Y && nums[3] == false)
                    numsBuf[3] = true;
            }

            else if (EnemyEventArgs.players == 2 )
            {
                if (x < EnemyEventArgs.player2X && nums[1] == false)
                    numsBuf[1] = true;
                else if (x > EnemyEventArgs.player2X && nums[0] == false)
                    numsBuf[0] = true;
                if (y > EnemyEventArgs.player2Y && nums[2] == false)
                    numsBuf[2] = true;
                else if (y < EnemyEventArgs.player2Y && nums[3] == false)
                    numsBuf[3] = true;
            }
            else if (EnemyEventArgs.players == 3)
            {
                if(message.goToPlayer == 1)
                {
                    if (x < EnemyEventArgs.player1X && nums[1] == false)
                        numsBuf[1] = true;
                    else if (x > EnemyEventArgs.player1X && nums[0] == false)
                        numsBuf[0] = true;
                    if (y > EnemyEventArgs.player1Y && nums[2] == false)
                        numsBuf[2] = true;
                    else if (y < EnemyEventArgs.player1Y && nums[3] == false)
                        numsBuf[3] = true;
                }
                else if(message.goToPlayer == 2)
                {
                    if (x < EnemyEventArgs.player2X && nums[1] == false)
                        numsBuf[1] = true;
                    else if (x > EnemyEventArgs.player2X && nums[0] == false)
                        numsBuf[0] = true;
                    if (y > EnemyEventArgs.player2Y && nums[2] == false)
                        numsBuf[2] = true;
                    else if (y < EnemyEventArgs.player2Y && nums[3] == false)
                        numsBuf[3] = true;
                }
            }

            if (!(numsBuf[0] == false && numsBuf[1] == false && numsBuf[2] == false && numsBuf[3] == false))
            {
                int answer = ranNumber.Next(0, 4);

                while (numsBuf[answer] != true)
                {
                    if (numsBuf[answer] == true)
                        return answer;
                    else
                        answer = ranNumber.Next(0, 4);
                }
                return answer;
            }

            return 4;
        }

        int MakeChanceDirect(List<Box> boxes, Form MainWindow)
        {
            int answer = ranNumber.Next(0, 4);
            int chanceDirectionPlayer = ranNumber.Next(0, 2);  // вероятность что на этом движении он будет двигаться в направлении игроков

            bool[] nums = new bool[4] { false, false, false, false };

            for (int i = 0; i < boxes.Count; i++)
            {
                if (Collisions.check_touch(x - difference, y, boxes[i], MainWindow))
                {
                    nums[0] = true;
                }
                if (Collisions.check_touch(x + difference, y, boxes[i], MainWindow))
                {
                    nums[1] = true;
                }
                if (Collisions.check_touch(x , y - difference, boxes[i], MainWindow))
                {
                    nums[2] = true;
                }
                if (Collisions.check_touch(x , y + difference, boxes[i], MainWindow))
                {
                    nums[3] = true;
                }
            }

            if (nums[0] == true && nums[1] == true && nums[2] == true && nums[3] == true)
                return 4;
            else if (message.pauseTurn == 0)
            {
                message.pauseTurn = 100;
                int stop = 20;

                if(chanceDirectionPlayer == 0 && EnemyEventArgs.players != 0)
                    answer = DirectPlayersAttached(nums);
                else
                    answer = ranNumber.Next(0, 4);

                if (answer == 4)
                    return 4;


                while (nums[answer] != false)
                {
                    if (chanceDirectionPlayer == 0)
                        answer = DirectPlayersAttached(nums);
                    else
                        answer = ranNumber.Next(0, 4);

                    if (answer == 4)
                        return 4;

                    stop--;
                    if (stop == 0)
                        break;
                }
                return answer;
            }
            else
            {
                message.pauseTurn--;

                answer = ranNumber.Next(0, 4);

                if (nums[direction] == false)
                    return direction;
                else
                {
                    int stop = 20;

                    answer = DirectPlayersAttached(nums);
                    if (answer == 4)
                        return 4;

                    while (nums[answer] != false)
                    {
                        answer = DirectPlayersAttached(nums);

                        stop--;
                        if (stop == 0)
                            break;
                    }
                    return answer;
                }
            }
        }

        public void Move(Form MainWindow, List<Box> boxes, List<Bullet> bullets, List<BaseTank> tanks)
        {
            int difference = 1, speed = 1;
            int turn = MakeChanceDirect(boxes, MainWindow);
            if (turn == 0)
            {
                RotatePicture(pictureTank1, direction, false, false, true, false);
                RotatePicture(pictureTank2, direction, false, false, true, false);
                direction = 0;

                int I = 0;
                for (int i = 0; i < tanks.Count; i++)
                    if (tanks[i].x == x && tanks[i].y == y)
                    { I = i; break; }

                for (int i = 0; i < tanks.Count; i++)
                {
                    if (I == i)
                        continue;

                    if (Collisions.check_touch(x - difference, y, tanks[i].x, tanks[i].y))
                        return;
                }

                x -= speed;

                changePictureFun();
            }
            else if (turn == 2)
            {
                RotatePicture(pictureTank1, direction, true, false, false, false);
                RotatePicture(pictureTank2, direction, true, false, false, false);
                direction = 2;

                RotatePicture(pictureTank1, direction, true, false, false, false);
                RotatePicture(pictureTank2, direction, true, false, false, false);
                direction = 2;
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (Collisions.check_touch(x, y - difference, boxes[i], MainWindow))
                    {
                        return;
                    }
                }

                int I = 0;
                for (int i = 0; i < tanks.Count; i++)
                    if (tanks[i].x == x && tanks[i].y == y)
                    { I = i; break; }

                for (int i = 0; i < tanks.Count; i++)
                {
                    if (I == i)
                        continue;

                    if (Collisions.check_touch(x, y - difference, tanks[i].x, tanks[i].y))
                        return;
                }

                y -= speed;

                changePictureFun();
            }
            else if (turn == 1)
            {
                RotatePicture(pictureTank1, direction, false, false, false, true);
                RotatePicture(pictureTank2, direction, false, false, false, true);
                direction = 1;

                int I = 0;
                for (int i = 0; i < tanks.Count; i++)
                    if (tanks[i].x == x && tanks[i].y == y)
                    { I = i; break; }

                for (int i = 0; i < tanks.Count; i++)
                {
                    if (I == i)
                        continue;

                    if (Collisions.check_touch(x + difference, y, tanks[i].x, tanks[i].y))
                        return;
                }

                x += speed;

                changePictureFun();
            }
            else if (turn == 3)
            {
                RotatePicture(pictureTank1, direction, false, true, false, false);
                RotatePicture(pictureTank2, direction, false, true, false, false);
                direction = 3;

                int I = 0;
                for (int i = 0; i < tanks.Count; i++)
                    if (tanks[i].x == x && tanks[i].y == y)
                    { I = i; break; }

                for (int i = 0; i < tanks.Count; i++)
                {
                    if (I == i)
                        continue;

                    if (Collisions.check_touch(x, y + difference, tanks[i].x, tanks[i].y))
                        return;
                }

                y += speed;

                changePictureFun();
            }
            else if (turn == 4)
            {
                changePictureFun();
            }
            if (message.pauseSpace < 0)
            {
                Bullet bullet = new Bullet(Peace_of_Tanks.Properties.Resources.bulletEnemy, x, y, direction, 0);
                message.pauseSpace = 50;
                bullets.Add(bullet);
            }
        }
    }
}
