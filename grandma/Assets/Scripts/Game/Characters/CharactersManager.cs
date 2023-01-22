using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class CharactersManager : MonoBehaviour
    {
        [SerializeField] VariableJoystick variableJoystick;
        [SerializeField] Hero hero;
        public List<CharacterHelper> helpers;
        Vector2 dir = Vector2.zero;

        public void Update()
        {
            float _x = variableJoystick.Horizontal;
            float _y = variableJoystick.Vertical;
            
            if (_x != 0 && _y != 0)
            {
                dir = new Vector2(_x, _y);
                hero.SetDirection(dir);
            }

            foreach (CharacterHelper h in helpers)
                h.OnUpdate(hero.transform.position, dir);
        }
    }
}
