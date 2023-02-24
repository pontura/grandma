using System.Collections;
using System.Collections.Generic;
using Tumba.Game.Characters;
using UnityEngine;

namespace Tumba.Game
{
    public class EnemiesExplorer : MonoBehaviour
    {
        Character character;
        public void Init(Character character)
        {
            this.character = character;            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "enemy")
            {
                Enemy e = collision.GetComponent<Enemy>();
                character.OnEnemyEnterZone(e, true);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "enemy")
            {
                Enemy e = collision.GetComponent<Enemy>();
                character.OnEnemyEnterZone(e, false);
            }
        }
    }
}
