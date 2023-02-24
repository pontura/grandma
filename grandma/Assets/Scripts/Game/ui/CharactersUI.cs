using UnityEngine.UI;
using UnityEngine;
using Tumba.UI;

namespace Tumba.Game.UI
{
    public class CharactersUI : MonoBehaviour
    {
        [SerializeField] EnergyBar energyBar;
        [SerializeField] RebornBar rebornBar;
        [SerializeField] Transform energyBarContainer;
        [SerializeField] Transform rebornBarContainer;

        public EnergyBar AddEnergyBar()
        {
            EnergyBar e = Instantiate(energyBar, energyBarContainer);
            return e;
        }
        public RebornBar AddReborn()
        {
            RebornBar r = Instantiate(rebornBar, rebornBarContainer);
            return r;
        }
        
    }
}
