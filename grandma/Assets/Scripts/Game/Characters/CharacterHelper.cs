using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class CharacterHelper : Character
    {
        public virtual void Init(Hero hero) { }
        public virtual void OnUpdate(Vector2 heroPos, Vector2 heroDir) { }
    }
}
