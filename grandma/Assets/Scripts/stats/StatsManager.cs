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
        }
        public void ReceiveDamage(float value)
        {
            stats.health -= value;
        }
    }
}
