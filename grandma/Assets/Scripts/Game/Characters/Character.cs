using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class Character : MonoBehaviour
    {
        public float speed = 10;
        Vector2 dir;

        public void LookTo(Vector2 dir)
        {
            this.dir = dir;
        }
        public void MoveForward()
        {
            Vector2 pos = transform.position;
            pos.x += dir.x * speed * Time.deltaTime;
            pos.y += dir.y * speed * Time.deltaTime;
            transform.position = pos;
        }
        
    }
}
