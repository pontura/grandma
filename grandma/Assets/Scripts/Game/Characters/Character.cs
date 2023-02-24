using System.Collections;
using System.Collections.Generic;
using Tumba.Stats;
using UnityEngine;
using Tumba.Game.UI;

namespace Tumba.Game.Characters
{
    public class Character : MonoBehaviour
    {
        public Color color;
        public int id;
        private EnergyBar energyBar;
        private RebornBar rebornBar;
        float speed = 10;
        protected Vector2 dir;
        protected float delayToShoot = 0.1f;
        public StatsManager statsManager;

        public states state;
        public enum states
        {
            ALIVE,
            DEAD
        }
        bool beingHealingByHero;

        public virtual void InitStats(StatsData s)
        {
            print(gameObject.name);
            rebornBar.SetActive(false);
            rebornBar.Init(this.gameObject, color);
            
            energyBar.Init(color);
            statsManager = new StatsManager();
            statsManager.Init(s);
            speed = s.speed / 100;
            delayToShoot = s.hitTime / 1000;
        }
        public void SetEnergyBar(UI.EnergyBar e)
        {
            this.energyBar = e;
        }
        public void SetRebornBar(UI.RebornBar e)
        {
            this.rebornBar = e;
        }
        public void SetDelayToShoot(float _delayToShoot)
        {
            this.delayToShoot = _delayToShoot;
        }
        public void SetSpeed(float _speed)
        {
            this.speed = _speed;
        }
        public void LookTo(Vector2 _dir)
        {
            if(_dir != Vector2.zero)
                this.dir = _dir;
        }
        public void MoveForward()
        {
            Vector2 pos = transform.position;
            pos.x += dir.x * speed * Time.deltaTime;
            pos.y += dir.y * speed * Time.deltaTime;
            transform.position = pos;
        }
        public void ReceiveDamage(float value)
        {
            if (state == states.ALIVE)
            {
                statsManager.ReceiveDamage(value);
                float lifeValue = statsManager.GetPercentLife();
                energyBar.SetValue(lifeValue);
                if (lifeValue <= 0) Die();
            }
        }
        public void RebornByHero(bool isOn)
        {
            beingHealingByHero = isOn;
        }
        void Die()
        {
            state = states.DEAD;
            rebornBar.SetActive(true);
            ReviveLoop();
        }
        void ReviveLoop()
        {
            if (state != states.DEAD) return;
            bool isBackToLife = statsManager.RebornRecovery(beingHealingByHero);
            rebornBar.SetValue(statsManager.GetNormalizedHealth());
            if(isBackToLife && state == states.DEAD)
            {
                print("revive");
                state = states.ALIVE;
                rebornBar.SetActive(false);
            }
            else
                Invoke("ReviveLoop", 0.1f);
        }
        public virtual void OnEnemyEnterZone(Enemy enemy, bool isIn)  { }
    }
}
