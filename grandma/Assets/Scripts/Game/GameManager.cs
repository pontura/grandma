using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Tumba.Game.Weapons;
using Tumba.Game.Characters;

namespace Tumba
{
    public class GameManager : MonoBehaviour
    {
        static GameManager mInstance = null;
        public PoolObjects pool;
        public WeaponsMmanager weaponsManager;
        public CharactersManager charactersManager;
        public EnemiesManager enemiesManager;

        public static GameManager Instance
        {
            get  {   return mInstance;  }
        }
       
        void Awake()
        {
            if (mInstance == null)
                mInstance = this as GameManager;
        }
        private void Start()
        {
            charactersManager.Init();
            enemiesManager.Init();
        }
        private void Update()
        {
            charactersManager.OnUpdate();
            enemiesManager.OnUpdate();
        }
    }
}