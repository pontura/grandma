using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

namespace Tumba
{
    public class Data : MonoBehaviour
    {
        static Data mInstance = null;
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
        }
    }

}