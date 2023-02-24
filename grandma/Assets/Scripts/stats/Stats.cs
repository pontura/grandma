using System;

namespace Tumba.Stats
{
    [Serializable]
    public class StatsData
    {
        public int levelUpgrades; //upgrades inside the game

        public float power;
        public float speed;
        public float hitTime;
        public float health;
        public float recoveryTime = 10f;

        public float life;

        public void Init()
        {
            life = health;
        }
    }
}