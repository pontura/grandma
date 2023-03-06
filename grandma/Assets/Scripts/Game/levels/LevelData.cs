using System.Collections;
using System.Collections.Generic;
using System;

namespace Tumba.Game.Levels
{
    [Serializable]
    public class LevelData
    {
        public int id;
        public List<WaveData> waveData;
    }
}
