using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class CircularRunner : CharacterHelper
    {
        [SerializeField] float smooth = 100;
        [SerializeField] float rotationSpeed = 1;
        [SerializeField] float forwardValue = 80;
        public string weaponName;
        float offset = 1.5f;
        float timer;
        GameObject target;
        float rot;

        public override void Init(Hero hero)
        {
            target = Instantiate( new GameObject() , transform.parent);            
        }
        public override void OnUpdate(Vector2 heroPos, Vector2 heroDir)
        {
            if (state == states.DEAD)
                UpdateDead();
            else
                UpdateAlive(heroPos);
        }
        public void UpdateAlive(Vector2 heroPos)
        {
            rotationSpeed = statsManager.stats.speed;
            target.transform.position = heroPos;
            rot = rotationSpeed * Time.deltaTime;
            target.transform.Rotate(Vector3.forward, rot);
            LookTo(dir);
            Vector2 dest = target.transform.position + (target.transform.right * forwardValue);
            transform.position = Vector2.Lerp(transform.position, dest, smooth * Time.deltaTime);
            timer += Time.deltaTime;
            if (timer > delayToShoot)
            {
                timer = 0;
            }
        }
        public void UpdateDead()
        {

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
