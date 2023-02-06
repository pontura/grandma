using System;

namespace Tumba.Stats
{
    [Serializable]
    public class StatsData
    {
        public float power;
        public float speed;
        public float hitTime;
        public float health;

        public float life;

        public void Init()
        {
            life = health;
        }
    }
}