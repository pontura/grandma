using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.Levels
{
    public class LevelsMmanager : MonoBehaviour
    {
        public List<LevelData> all;
        LevelData levelActive;
        int levelID;

        public void InitLevel()
        {
            levelActive = all[0];
            Events.InitWave(levelActive.waveData[0]);
        }
    }
}
