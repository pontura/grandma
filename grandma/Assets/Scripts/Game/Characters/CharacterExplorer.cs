using System.Collections;
using System.Collections.Generic;
using Tumba.Game.Utils;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class CharacterExplorer : CharacterHelper
    {
        float forwardValue = 3;
        public string weaponName;
        GameObject target;
        [SerializeField] EnemiesExplorer enemiesExplorer;

        public override void Init(Hero hero)
        {
            enemiesExplorer.Init(this);
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
            if (target != null)
            {
                LookTo(target.transform.position);
                Vector2 dest = target.transform.position - transform.position;
                transform.Translate(dest.normalized * forwardValue * Time.deltaTime);
            }
            else
                enemiesExplorer.transform.position = heroPos;

        }
        public void UpdateDead()
        {

        }
        public override void OnEnemyEnterZone(Enemy enemy, bool isIn)
        {
            if (isIn && target == null)
                target = enemy.gameObject;
            else if (target == enemy.gameObject)
                target = null;
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
