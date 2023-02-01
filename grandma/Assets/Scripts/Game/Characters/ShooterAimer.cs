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
        public override void OnUpdate(Vector2 heroPos, Vector2 dir)
        {
            LookTo(dir);
            Vector2 dest = heroPos + (dir.normalized * offset);
            transform.position = Vector2.Lerp(transform.position, dest, smooth * Time.deltaTime);
            timer += Time.deltaTime;
            if (timer > delayToShoot)
            {
                timer = 0;
                Shoot();
            }
        }
        void Shoot()
        {
            GameManager.Instance.weaponsManager.Shoot(weaponName, transform.position, dir);
        }
    }
}
