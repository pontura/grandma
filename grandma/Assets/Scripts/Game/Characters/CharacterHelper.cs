using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class CharacterHelper : Character
    {
        [SerializeField] float smooth = 100;
        float offset = 1.5f;
        public void OnUpdate(Vector2 heroPos, Vector2 dir)
        {
            LookTo(dir);
            Vector2 dest = heroPos + (dir.normalized * offset);
            transform.position = Vector2.Lerp(transform.position, dest, smooth * Time.deltaTime);
        }
    }
}
