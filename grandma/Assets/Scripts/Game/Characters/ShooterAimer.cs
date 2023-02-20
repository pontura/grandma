using System.Collections;
using System.Collections.Generic;
using Tumba.Stats;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class ShooterAimer : CharacterHelper
    {
        [SerializeField] float smooth = 100;
        public string weaponName;
        float offset = 1.5f;
        float timer;

        public override void OnInit()
        {
        }
        public override void OnUpdate(Vector2 heroPos, Vector2 heroDir)
        {
            if (state == states.DEAD)
                UpdateDead();
            else
                UpdateAlive(heroPos, heroDir);
        }
        void UpdateAlive(Vector2 heroPos, Vector2 heroDir)
        {
            LookTo(heroDir);
            Vector2 dest = heroPos + (heroDir.normalized * offset);
            transform.position = Vector2.Lerp(transform.position, dest, smooth * Time.deltaTime);
            timer += Time.deltaTime;
            if (timer > delayToShoot)
            {
                timer = 0;
                Shoot();
            }
        }
        void UpdateDead() { }
        void Shoot()
        {
            GameManager.Instance.weaponsManager.Shoot(weaponName, transform.position, dir);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "enemy")
            {
                Enemy e = collision.GetComponent<Enemy>();
                e.Die();
                ReceiveDamage(e.damage);
            }
        }
    }
}
