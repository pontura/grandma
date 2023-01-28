using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class Hero : Character
    {
        public void SetDirection(Vector2 dir)
        {
            LookTo(dir);
            if(dir != Vector2.zero)
                MoveForward();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "enemy")
            {
                Enemy e = collision.GetComponent<Enemy>();
                e.Die();
            }
            if (collision.tag == "soul")
            {
                Grabbable g = collision.GetComponent<Grabbable>();
                g.OnGrab(transform);
            }
        }
    }
}
