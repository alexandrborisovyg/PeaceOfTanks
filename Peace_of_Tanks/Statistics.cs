using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace_of_Tanks
{
    [Serializable]
    class Statistics 
    {
        public stats[] statistic;

        public Statistics()
        {
            statistic = new stats[10];
            for (int i = 0; i < 10; i++)
                statistic[i] = new stats();
        }

        public bool Add_new_record(stats result)
        {
            stats[] statBuf = new stats[10];

            for (int i = 0; i < 10; i++)
            {
                if (result.points > statistic[i].points)
                {
                    for (int j = 0; j < 10; j++) statBuf[j] = (stats)statistic[j].Clone();
                        statistic[i] = result;

                    if(i != 9)
                        for (int j = i + 1; j < 10; j++)
                        {
                            statistic[j] = statBuf[j - 1];
                        }
                    return true;
                }
            }
            return false;
        }
        public bool CheckRecord(stats result)
        {
            for (int i = 0; i < 10; i++)
            {
                if (result.points > statistic[i].points)
                {
                    return true;
                }
            }
            return false;
        }
    }

    [Serializable]
    class stats : ICloneable
    {
        public string name;
        public int points;
        public int mode;
        public int difficulty;
        public int hearts;

        public object Clone()
        {
            return new stats { difficulty = this.difficulty,  hearts = this.hearts, mode = this.mode, name = this.name, points = this.points };
        }

        public stats()
        {
            name = "UNKNOWN";
            points = 0;
            mode = 0;
            difficulty = 0;
            hearts = 0;
        }
    }
}
