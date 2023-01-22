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
        
    }
}
