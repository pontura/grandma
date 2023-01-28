using UnityEngine.UI;
using UnityEngine;
using Tumba.UI;

namespace Tumba.Game.UI
{
    public class LevelBar : MonoBehaviour
    {
        [SerializeField] ProgressBar progressBar;

        public void Init()
        {
            progressBar.Init(0, OnFilled);
            Events.OnSoulGrabbed += OnSoulGrabbed;
        }
        void OnDestroy()
        {
            Events.OnSoulGrabbed -= OnSoulGrabbed;
        }
        void OnFilled()
        {
            progressBar.SetValue(0);
        }
        void AddValue()
        {
            progressBar.Add(0.025f);
        }
        void OnSoulGrabbed(string s)
        {
            print("OnSoulGrabbed " + s);
            switch(s)
            {
                case "SOUL":
                    AddValue();
                    break;
            }
        }
        void OnDone()
        {
            Debug.Log("Done!");
        }
    }
}
