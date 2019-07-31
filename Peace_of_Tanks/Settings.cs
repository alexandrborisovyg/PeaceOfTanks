using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace_of_Tanks
{
    class Settings
    {
        public stats stats1;
        public stats stats2;

        public bool twoPlayer;
        public int difficulty;
        public int pointsPlayer1, pointsPlayer2;
        public int lifesPlayer1, lifesPlayer2;

        public int countEnemies;
        public int speedEnemy;
        public int hitPointsEnemy;

        public int level;

        public int pointsForEnemy;
        public int pointsForPlayers;
        public int timeSpawn;

        public Settings(bool twoPlayer, int difficulty, int pointsPlayer1, int pointsPlayer2,
            int lifesPlayer1, int lifesPlayer2, int countEnemies, int speedEnemy,
            int hitPointsEnemy, int level, int pointsForEnemy, int timeSpawn, int pointsForPlayers)
        {
            this.twoPlayer = twoPlayer;
            this.difficulty = difficulty;
            this.pointsPlayer1 = pointsPlayer1;
            this.pointsPlayer2 = pointsPlayer2;
            this.lifesPlayer1 = lifesPlayer1;
            this.lifesPlayer2 = lifesPlayer2;
            this.countEnemies = countEnemies;
            this.speedEnemy = speedEnemy;
            this.hitPointsEnemy = hitPointsEnemy;
            this.level = level;
            this.pointsForEnemy = pointsForEnemy;
            this.timeSpawn = timeSpawn;
            this.pointsForPlayers = pointsForPlayers;

            stats1 = new stats();
            stats2 = new stats();
        }
        public Settings()
        {

        }
    }
}
