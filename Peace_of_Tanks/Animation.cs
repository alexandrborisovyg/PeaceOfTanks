using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Peace_of_Tanks
{
    public class AnimateEventArgs : EventArgs
    {
        public int x, y;
        public int type; // 0 - анимация разрушения ящика, 1 - анимания уничтожения танка
        public int delay;

        public AnimateEventArgs() : base()
        { }
    }

    public delegate void AnimateEvent();

    public class Animation
    {
        public static Bitmap boom1;
        public static Bitmap boom2;
        public static Bitmap boom3;

        public static Bitmap megaBoom1;
        public static Bitmap megaBoom2;

        public AnimateEventArgs message;
        public Bitmap picture;

        public Animation()
        {
            message = new AnimateEventArgs();
        }

        public void Delay()
        {
            if (message.type == 0)
            {
                if (message.delay == 10)
                {
                    picture = boom1;
                }
                else if (message.delay == 6)
                {
                    picture = boom2;
                }
                else if (message.delay == 3)
                {
                    picture = boom3;
                }
                message.delay--;
            }
            else if(message.type == 1)
            {
                if (message.delay == 10)
                {
                    picture = megaBoom1;
                }
                else if (message.delay == 5)
                {
                    picture = megaBoom2;
                }
                message.delay--;
            }
        }

        public void Draw(Graphics grMemory)
        {
            if(message.type == 0)
                grMemory.DrawImage(picture, message.x - 5, message.y - 5, 40, 40);
            else if(message.type == 1)
                grMemory.DrawImage(picture, message.x - 10, message.y - 10, 80, 80);
        }
    }
}
