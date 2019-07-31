using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Peace_of_Tanks
{
    class LevelDesign
    {
        public int[,] masPointsSpawnEnemy = new int[4, 2];
        public int[,] masPointsSpawnPlayers = new int[4, 2];

        public LevelDesign()
        {
            for (int i = 0; i < 4; i++)
            {
                masPointsSpawnEnemy[i, 0] = new int();
                masPointsSpawnEnemy[i, 1] = new int();
            }
            for (int i = 0; i < 2; i++)
            {
                masPointsSpawnPlayers[i, 0] = new int();
                masPointsSpawnPlayers[i, 1] = new int();
            }
        }

        public void Level1(Form MW, List<Box> boxes)
        {
            masPointsSpawnEnemy[0, 0] = 0;
            masPointsSpawnEnemy[0, 1] = 400;
            masPointsSpawnEnemy[1, 0] = 700;
            masPointsSpawnEnemy[1, 1] = 400;
            masPointsSpawnEnemy[2, 0] = 350;
            masPointsSpawnEnemy[2, 1] = 0;
            masPointsSpawnEnemy[3, 0] = 350;
            masPointsSpawnEnemy[3, 1] = 700;

            masPointsSpawnPlayers[0, 0] = 0;
            masPointsSpawnPlayers[0, 1] = 0;
            masPointsSpawnPlayers[1, 0] = 700;
            masPointsSpawnPlayers[1, 1] = 0;
            masPointsSpawnPlayers[2, 0] = 0;
            masPointsSpawnPlayers[2, 1] = 700;
            masPointsSpawnPlayers[3, 0] = 700;
            masPointsSpawnPlayers[3, 1] = 700;

            boxes.Clear();

            int y = 75;
            int x = 100;

            Box box = new Box_Wall(x, y);
            for (x = 100; x <= 700; x += 25)
            {
                if(x < 350 || x > 450)
                {
                    box = new Box_Wall(x, y);
                    boxes.Add(box);
                    box = new Box_Wall(x, y + 25);
                    boxes.Add(box);
                }
            }
            y = 650;
            for (x = 100; x <= 700; x += 25)
            {
                if (x < 350 || x > 450)
                {
                    box = new Box_Wall(x, y);
                    boxes.Add(box);
                    box = new Box_Wall(x, y + 25);
                    boxes.Add(box);
                }
            }
            x = 100;
            int x2 = 675;
            for (y = 125; y < 675; y += 25)
            {
                if (y < 350 || y > 450)
                {
                    box = new Box_Wall(x, y);
                    boxes.Add(box);
                    box = new Box_Wall(x+25, y);
                    boxes.Add(box);
                    box = new Box_Wall(x2, y);
                    boxes.Add(box);
                    box = new Box_Wall(x2 + 25, y);
                    boxes.Add(box);
                }
            }

            for (x = 300; x <= 500; x += 25)
            {
                for(y = 250; y <= 500; y += 25)
                {
                    box = new Box_Water(x, y);
                    boxes.Add(box);
                }
            }

            x = 200;
            for(y = 200; y < 500; y += 25)
            {
                box = new Box_Green(x, y);
                boxes.Add(box);
                box = new Box_Green(x + 25, y);
                boxes.Add(box);
            }

            x = 575;
            for (y = 200; y < 500; y += 25)
            {
                box = new Box_Iron(x, y);
                boxes.Add(box);
                box = new Box_Iron(x + 25, y);
                boxes.Add(box);
            }
        }
    }
}
