using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Stats
{
    [Serializable]
    public class StatsManager
    {
        public StatsData stats;
        public void Init(StatsData s)
        {
            this.stats = s;
            s.Init();
        }
        public void Revive()
        {
            stats.health = stats.life;
        }
        public void ReceiveDamage(float value)
        {
            stats.health -= value;
        }
        public float GetPercentLife()
        {
            Debug.Log (stats.health + " / " + stats.life);
            return stats.health / stats.life;
        }
    }
}
