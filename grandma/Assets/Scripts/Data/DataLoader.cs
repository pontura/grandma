using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba
{
    public class DataLoader : MonoBehaviour
    {
        public string url;
        public TextAsset file_in_server;
        System.Action OnReady;

        private void Start()
        {
            Events.ResetApp += ResetApp;
        }
        private void OnDestroy()
        {
            Events.ResetApp += ResetApp;
        }
        public virtual void LoadData(System.Action OnReady, string url)
        {
            this.OnReady = OnReady;
            //if (Data.Instance.loadType == Data.loadTypes.DATABASE)
            Data.Instance.spreadsheetLoader.LoadFromTo(url, OnLoaded);
            //else if (Data.Instance.loadType == Data.loadTypes.LOCAL)
            //    Data.Instance.spreadsheetLoader.CreateListFromFile(file_in_server.text, OnLoaded);
            //else
            //Data.Instance.spreadsheetLoader.LoadFromTo(Data.Instance.GetURL() + "AssetBundles/" + file_in_server.name + ".txt" + "?rand=" + UnityEngine.Random.Range(1000, 10000), OnLoaded);
        }
        public virtual void OnLoaded(List<SpreadsheetLoader.Line> d)
        {
            if (OnReady != null)
                OnReady();
        }
        void ResetApp() { Reset();  }
        public virtual void Reset() { }
    }
}
