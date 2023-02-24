using System.Collections;
using System.Collections.Generic;
using Tumba.Game.Characters;
using Tumba.Game.UI;
using UnityEngine;

namespace Tumba.Game.LevelUpgrades
{
    public class LevelUpgrades : UIScreen
    {
        [SerializeField] Transform container;
        [SerializeField] LevelUpgradeButton button;
        List<LevelUpgradeButton> buttons;

        public override void OnInit()
        {
            buttons = new List<LevelUpgradeButton>();
            Utils.RemoveAllChildsIn(container);
            Time.timeScale = 0; 
            AddContent();
        }
        public override void OnClose()
        { 
            Time.timeScale = 1;
        }
        void AddContent()
        {
            int id = 0;
            //Add hero;
            Characters.CharactersManager chManager =  GameManager.Instance.charactersManager;
            AddButton(id, chManager.hero.id, chManager.hero.statsManager.stats);
            id++;

            //Adds herlpers
            List<CharacterHelper> helpers = GameManager.Instance.charactersManager.helpers;
            foreach(CharacterHelper c in helpers)
            {
                AddButton(id, c.id, c.statsManager.stats);
                id++;
            }
        }
        void AddButton(int id, int characterID, Stats.StatsData data)
        {
            LevelUpgradeButton b = Instantiate(button, container);
            b.Init(characterID, OnClicked);
            b.SetData(characterID, data);
            buttons.Add(b);
        }
        void OnClicked(int id)
        {
            buttons[id].statsData.levelUpgrades++;
            Close();
            GameUI.Instance.OnInitLevel();
        }
    }
}
