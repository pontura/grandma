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

        [SerializeField] float heroSpeed;
        [SerializeField] float helperSpeed;

        public void Init()
        {
            foreach (CharacterHelper h in helpers)
                h.Init(hero);
        }
        //void SetParams()
        //{
        //    Invoke("SetParams", 1);
        //}
        public void OnUpdate()
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
