using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Peace_of_Tanks
{
    class Numbers
    {
        public static Bitmap ReturnNumPic(int num)
        {
            if (num == 0)
                return Peace_of_Tanks.Properties.Resources.num0;
            if (num == 1)
                return Peace_of_Tanks.Properties.Resources.num1;
            if (num == 2)
                return Peace_of_Tanks.Properties.Resources.num2;
            if (num == 3)
                return Peace_of_Tanks.Properties.Resources.num3;
            if (num == 4)
                return Peace_of_Tanks.Properties.Resources.num4;
            if (num == 5)
                return Peace_of_Tanks.Properties.Resources.num5;
            if (num == 6)
                return Peace_of_Tanks.Properties.Resources.num6;
            if (num == 7)
                return Peace_of_Tanks.Properties.Resources.num7;
            if (num == 8)
                return Peace_of_Tanks.Properties.Resources.num8;
            if (num == 9)
                return Peace_of_Tanks.Properties.Resources.num9;
            else return Peace_of_Tanks.Properties.Resources.num0;
        }

        public static void Draw(Graphics grMemory, Bitmap num, int x, int y)
        {
            grMemory.DrawImage(num, x, y, 25, 25);
        }
    }
}
