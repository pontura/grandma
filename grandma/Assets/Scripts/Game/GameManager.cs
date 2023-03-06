using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Tumba.Game.Weapons;
using Tumba.Game.Characters;
using Tumba.Game.Levels;

namespace Tumba
{
    public class GameManager : MonoBehaviour
    {
        static GameManager mInstance = null;
        public PoolObjects pool;
        public WeaponsMmanager weaponsManager;
        public CharactersManager charactersManager;
        public EnemiesManager enemiesManager;
        public Transform items;
        LevelsMmanager levelsMmanager;

        public static GameManager Instance
        {
            get  {   return mInstance;  }
        }
       
        void Awake()
        {
            if (mInstance == null)
                mInstance = this as GameManager;
            levelsMmanager = GetComponent<LevelsMmanager>();
        }
        public void InitLevel()
        {
            enemiesManager.Init(charactersManager.hero);
            levelsMmanager.InitLevel();
        }
        private void Update()
        {
            charactersManager.OnUpdate();
            enemiesManager.OnUpdate();
        }
    }
}