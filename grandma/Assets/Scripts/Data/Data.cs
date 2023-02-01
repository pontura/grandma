using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Tumba.Stats;

namespace Tumba
{
    public class Data : MonoBehaviour
    {
        static Data mInstance = null;
        public SpreadsheetLoader spreadsheetLoader;
        string newScene;
        public static Data Instance
        {
            get
            {
                return mInstance;
            }
        }
        public void LoadLevel(string aLevelName)
        {
            Debug.Log("DATA LoadLevel " + aLevelName);
            this.newScene = aLevelName;
            SceneManager.LoadScene(aLevelName);
        }
        void Awake()
        {

            if (mInstance == null)
                mInstance = this as Data;
            else if (mInstance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            DontDestroyOnLoad(this);

            spreadsheetLoader = GetComponent<SpreadsheetLoader>();
            GetComponent<StatsLoader>().Init();
        }
    }

}