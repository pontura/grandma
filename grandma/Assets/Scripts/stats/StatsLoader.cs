using System.Collections;
using System.Collections.Generic;
using Tumba.Game.Characters;
using UnityEngine;
namespace Tumba.Stats
{
    public class StatsLoader : DataLoader
    {

        public List<StatsData> allStats;

        public void Init()
        {
            LoadData(null, url);
        }
        public override void OnLoaded(List<SpreadsheetLoader.Line> d)
        {
            OnDataLoaded(d);
        }
        void AllLoaded()
        {
            GameManager.Instance.charactersManager.InitStats(allStats);
            GameManager.Instance.InitLevel();
        }
        void OnDataLoaded( List<SpreadsheetLoader.Line> d)
        {
            int colID = 0;
            int rowID = 0;
            int id = 0;
            allStats = new List<StatsData>();
            for(int a = 0; a< 4; a++)
            {
                StatsData s = new StatsData();
                allStats.Add(s);
            }
            foreach (SpreadsheetLoader.Line line in d)
            {
                foreach (string value in line.data)
                {
                    //print("row: " + rowID + "  colID: " + colID + "  value: " + value);
                    if (rowID >= 1)
                    {
                        if (colID == 0)
                        {
                        }
                        else
                        {
                            if (rowID == 1)
                            {
                                allStats[colID-1].health = int.Parse(value);
                            }
                            if (rowID == 2)
                            {
                                allStats[colID - 1].speed = int.Parse(value);
                            }
                            if (rowID == 3)
                            {
                                allStats[colID - 1].hitTime = int.Parse(value);
                            }
                            if (rowID == 4)
                            {
                                allStats[colID - 1].power = int.Parse(value);
                            }
                           // print(rowID + " - " + colID + ":" + value);
                        }
                    }
                    colID++;
                }
                colID = 0;
                rowID++;
            }
            AllLoaded();
        }
    }
}
