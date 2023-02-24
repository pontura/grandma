using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tumba.UI;

namespace Tumba.Game.UI
{
    public class GameUI : MonoBehaviour
    {
        static GameUI mInstance = null;
        [SerializeField] LevelBar levelBar;
        [SerializeField] ButtonUI restartBtn;

        public static GameUI Instance   {  get { return mInstance; }   }

        void Awake()   {   if (mInstance == null)   mInstance = this as GameUI;   }

        void Start()
        {
            restartBtn.Init(0, OnRestart, "RESTART");
            OnInitLevel();
        }
        void OnLevelDone()
        {
            Events.OnScreenOpen(ScreensManager.types.LEVELS_UPGRADE);
        }
        public void OnInitLevel()
        {
            levelBar.OnInit(OnLevelDone);
        }
        void OnRestart(int id)
        {
            Data.Instance.LoadLevel("Game");
        }
    }
}
