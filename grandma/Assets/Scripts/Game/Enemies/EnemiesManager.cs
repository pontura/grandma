using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class EnemiesManager : MonoBehaviour
    {
        [SerializeField] Hero hero;
        List<Enemy> all;
        [SerializeField] Vector2 offsetPos;
        [SerializeField] Transform container;
        System.Action<GameObject> Pool;

        [SerializeField] float speed;
        [SerializeField] float delayToRespawn = 1;
        [SerializeField] float minDelay = 0.1f;

        public void Init()
        {
            all = new List<Enemy>();
            Pool = GameManager.Instance.pool.Pool;
            Loop();
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
        void Loop()
        {
            AddEnemy();
            Invoke("Loop", delayToRespawn);
            delayToRespawn -= 0.03f;
            if (delayToRespawn < minDelay)
                delayToRespawn = minDelay;
                
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
