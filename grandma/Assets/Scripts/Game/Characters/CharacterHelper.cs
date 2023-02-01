using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class CharacterHelper : Character
    {
        public virtual void Init(Hero hero) { OnInit();  }

        public virtual void OnInit() { }
        public virtual void OnUpdate(Vector2 heroPos, Vector2 heroDir) { }
    }
}
