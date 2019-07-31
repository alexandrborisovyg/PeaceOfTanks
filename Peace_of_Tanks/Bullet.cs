using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Peace_of_Tanks
{
    public class Bullet
    {
        Bitmap pictureBullet;
        public int x, y;
        public int who;
        int direction; //0 - left, 1 - right, 2 - up, 3 - down

        public Bullet(Bitmap picture, int x, int y, int direction, int who)
        {
            Bitmap bullet = Peace_of_Tanks.Properties.Resources.bullet1;
            bullet.MakeTransparent(Color.Black);
            pictureBullet = bullet;
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.who = who;
            ChangePosition();
            RotatePicture(direction);
        }

        void ChangePosition()
        {
            if(direction == 0)
            {
                x -= 20;
                y += 20;
            }
            if(direction == 1)
            {
                x += 60;
                y += 20;
            }
            if(direction == 2)
            {
                x += 20;
                y -= 20;
            }
            if(direction == 3)
            {
                x += 20;
                y += 60;
            }
        }

        protected void RotatePicture(int direct)
        {
            if (direct == 0) pictureBullet.RotateFlip(RotateFlipType.Rotate90FlipX);
            if (direct == 3) pictureBullet.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (direct == 1) pictureBullet.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        public void Move()
        {
            if (direction == 0)
            {
                x -= 10;
            }
            if (direction == 2)
            {
                y -= 10;
            }
            if (direction == 1)
            {
                x += 10;
            }
            if (direction == 3)
            {
                y += 10;
            }
        }

        public void Draw(Graphics grMemory)
        {
            grMemory.DrawImage(pictureBullet, x, y, 10, 10);
        }
    }
}
