using System.Collections;
using System.Collections.Generic;
using Tumba.Game.Characters;
using UnityEngine;

namespace Tumba.Game.Weapons
{
    public class Weapon : MonoBehaviour
    {
        float speed = 25;
        Vector2 dir = Vector2.zero;
        float timer;

        public void Init(Vector2 _dir)
        {
            timer = 0;
            dir = _dir.normalized;
        }
        private void Update()
        {
            Vector2 pos = transform.position;
            pos += dir * speed * Time.deltaTime;
            transform.position = pos;
            timer += Time.deltaTime;
            if (timer > 1)
                GameManager.Instance.pool.Pool(this.gameObject);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "enemy")
            {
                Enemy e = collision.GetComponent<Enemy>();
                e.Die();
                GameManager.Instance.pool.Pool(this.gameObject);
            }
        }
    }
}
