using System.Collections;
using System.Collections.Generic;
using Tumba.Stats;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class CharactersManager : MonoBehaviour
    {
        [SerializeField] Transform container;
        [SerializeField] Hero _hero;
        [SerializeField] CharacterHelper circular;
        [SerializeField] CharacterHelper shooter;
        [SerializeField] CharacterHelper explorer;
        [SerializeField] UI.CharactersUI charactersUI;

        public enum types
        {
            circular,
            shooter,
            explorer
        }

        [SerializeField] VariableJoystick variableJoystick;
        public Hero hero;
        public List<CharacterHelper> helpers;
        Vector2 dir = Vector2.zero;

        [SerializeField] float heroSpeed;
        [SerializeField] float helperSpeed;

        List<StatsData> allStats;
        public void InitStats(List<StatsData> allStats)
        {
            this.allStats = allStats;
            hero = Instantiate(_hero, container);
            hero.SetEnergyBar(charactersUI.AddEnergyBar());
            hero.SetRebornBar(charactersUI.AddReborn());

            hero.InitStats(allStats[0]);
            AddHelper(types.circular, 1);
            AddHelper(types.explorer, 2);
            AddHelper(types.shooter, 3);

        }
        void AddHelper(types type, int id)
        {
            CharacterHelper ch = null;
            switch(type)
            {
                case types.circular: ch = circular; break;
                case types.explorer: ch = explorer; break;
                case types.shooter: ch = shooter; break;
            }
            CharacterHelper c = Instantiate(ch, container);
           // Events.AddHelper(c.color);
            c.SetEnergyBar( charactersUI.AddEnergyBar() );
            c.SetRebornBar( charactersUI.AddReborn() );
            c.Init(hero);
            c.name = type.ToString();
            helpers.Add(c);
            c.InitStats(allStats[id]);
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
