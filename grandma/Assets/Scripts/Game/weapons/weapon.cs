using System.Collections;
using System.Collections.Generic;
using Tumba.Game.Characters;
using UnityEngine;

namespace Tumba.Game.Weapons
{
    public class Weapon : MonoBehaviour
    {
        float speed = 15;
        Vector2 dir = Vector2.zero;
        float timer;

        public void Init(Vector2 _dir)
        {            
            timer = 0;
            dir = _dir.normalized;
            StartCoroutine(Loop());

            float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        IEnumerator Loop()
        {           
            while (timer < 1)
            {
                float d = Time.deltaTime;
                Vector2 pos = transform.position;
                pos += dir * speed * d;
                transform.position = pos;
                timer += d;
                yield return new WaitForEndOfFrame();
            }
            GameManager.Instance.pool.Pool(this.gameObject);
            yield return null;
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
