using System.Collections;
using System.Collections.Generic;
using Tumba.Game.Characters;
using UnityEngine;
namespace Tumba.Game.Characters
{
    public class Enemy : MonoBehaviour
    {
        float speed;
        EnemiesManager enemiesManager;
        public void Init(EnemiesManager _enemiesManager)
        {
            this.enemiesManager = _enemiesManager; 
        }
        public void Respawn(Vector2 pos, float _speed)
        {
            this.speed = _speed / 10;
            transform.position = pos;
        }
        public void Move(Vector2 dir)
        {
            Vector2 pos = transform.position;
            pos.x += dir.x * speed * Time.deltaTime;
            pos.y += dir.y * speed * Time.deltaTime;
            transform.position = pos;
        }
        public void Die()
        {
            GameManager gm = GameManager.Instance;
            GameObject go = gm.pool.Get("Soul");
            go.transform.position = transform.position;
            go.SetActive(true);
            go.transform.SetParent(gm.items);
            print("soul");
           enemiesManager.Die(this);
        }
    }
}
