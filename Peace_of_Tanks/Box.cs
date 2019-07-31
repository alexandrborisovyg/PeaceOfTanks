using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Peace_of_Tanks
{
    public class Box
    {
        public int hitPoint;
        public int x, y;
        public Bitmap pictureBox;

        public Box(int x , int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Draw(Graphics grMemory)
        {
            grMemory.DrawImage(pictureBox, x, y, 25, 25);
        }
    }

    class Box_Wall : Box
    {
        public Box_Wall (int x, int y) : base(x, y)
        {
            hitPoint = 1;
            pictureBox = Peace_of_Tanks.Properties.Resources.wall;
        }
    }

    class Box_Water : Box
    {
        public Box_Water(int x, int y) : base(x, y)
        {
            hitPoint = -1;
            pictureBox = Peace_of_Tanks.Properties.Resources.water;
        }
    }

    class Box_Green : Box
    {
        public Box_Green(int x, int y) : base(x, y)
        {
            hitPoint = -1;
            pictureBox = Peace_of_Tanks.Properties.Resources.green;
        }
    }

    class Box_Iron : Box
    {
        public Box_Iron(int x, int y) : base(x, y)
        {
            hitPoint = -1;
            pictureBox = Peace_of_Tanks.Properties.Resources.iron;
        }
    }
}
