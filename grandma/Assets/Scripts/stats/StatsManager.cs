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
        public bool RebornRecovery(bool beingHealingByHero)
        {
            float healingValue = stats.recoveryTime / 10;
            if (beingHealingByHero) healingValue *= 10;

            stats.health += healingValue;
            if (stats.health >= stats.life)
            {
                Reborn();
                return true;
            }
            return false;
        }
        public float GetNormalizedHealth()
        {
            return stats.health / stats.life;
        }
        void Reborn()
        {
            stats.health = stats.life;
        }
        public void ReceiveDamage(float value)
        {
            stats.health -= value;
        }
        public float GetPercentLife()
        {
           // Debug.Log (stats.health + " / " + stats.life);
            return stats.health / stats.life;
        }
    }
}
