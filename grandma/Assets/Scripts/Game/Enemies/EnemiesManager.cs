using System.Collections;
using System.Collections.Generic;
using Tumba.Game.Levels;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class EnemiesManager : MonoBehaviour
    {
        Hero hero;
        List<Enemy> all;
        [SerializeField] Vector2 offsetPos;
        [SerializeField] Transform container;
        System.Action<GameObject> Pool;

        [SerializeField] float speed;
        [SerializeField] float delaySpeed;
        [SerializeField] float delayRespan;
        [SerializeField] float delayRespanFrom;
        [SerializeField] float delayRespanTo;
        [SerializeField] float minDelay;

        private void Awake()
        {
            Events.InitWave += InitWave;
        }
        private void OnDestroy()
        {
            Events.InitWave -= InitWave;
        }
        public void Init(Hero hero)
        {
            this.hero = hero;
            all = new List<Enemy>();
            Pool = GameManager.Instance.pool.Pool;
        }        
        public void OnUpdate()
        {
            Vector2 hpos = hero.transform.position;
            foreach (Enemy e in all)
            {
                Vector2 pos = e.transform.position;
                Vector2 dir = (hpos - pos).normalized;
                e.Move(dir);
            }
        }
        public void InitWave(WaveData waveData)
        {
            CancelInvoke();
            this.delayRespan = waveData.delayRespanFrom;
            this.delayRespanFrom = waveData.delayRespanFrom;
            this.delayRespanTo = waveData.delayRespanTo;
            this.delaySpeed = waveData.delaySpeed;
            Invoke("Loop", delayRespan);
        }
        void Loop()
        {
            AddEnemy();
            delayRespan -= delaySpeed;
            if (delayRespan < delayRespanTo)
                delayRespan = delayRespanTo;

            Invoke("Loop", delayRespan);
        }
        void AddEnemy()
        {
            Vector2 pos = new Vector2();
            
            if (Random.Range(0, 10) < 5)
            {
                pos.x = offsetPos.x;
                pos.y = Random.Range(-offsetPos.y, offsetPos.y);
                if (Random.Range(0, 10) < 5)
                    pos.x *= -1;
            }
            else
            {
                pos.y = offsetPos.y;
                pos.x = Random.Range(-offsetPos.x, offsetPos.x);
                if (Random.Range(0, 10) < 5)
                    pos.y *= -1;
            }
            pos = pos + (Vector2)(hero.transform.position);
            GameObject go = GameManager.Instance.pool.Get("Enemy");
            Enemy e = go.GetComponent<Enemy>();
            if (e == null) return;
            e.transform.SetParent(container);
            e.Init(this);
            e.Respawn(pos, speed);
            all.Add(e);
        }
        public void Die(Enemy e)
        {
            all.Remove(e);
            Pool(e.gameObject);
        }
    }
}
