using System.Collections;
using System.Collections.Generic;
using Tumba.Stats;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class Character : MonoBehaviour
    {
        float speed = 10;
        protected Vector2 dir;
        protected float delayToShoot = 0.1f;
        public StatsManager statsManager;

        public virtual void InitStats(StatsData s)
        {
            statsManager = new StatsManager();
            statsManager.Init(s);
            speed = s.speed / 100;
            delayToShoot = s.hitTime / 10000;
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
        
    }
}
