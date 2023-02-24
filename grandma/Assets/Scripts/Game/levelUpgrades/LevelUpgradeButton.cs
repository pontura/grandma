using Tumba.Stats;
using Tumba.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Tumba.Game.LevelUpgrades
{
    public class LevelUpgradeButton : ButtonUI
    {
        [SerializeField] Text characterName;
        [SerializeField] Text descField;
        public StatsData statsData;

        public void SetData(int characterID, StatsData statsData)
        {
            this.statsData = statsData;
            characterName.text = characterID.ToString();
            descField.text = statsData.levelUpgrades.ToString();
        }
    }
}
