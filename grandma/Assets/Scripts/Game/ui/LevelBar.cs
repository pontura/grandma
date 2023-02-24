using UnityEngine.UI;
using UnityEngine;
using Tumba.UI;

namespace Tumba.Game.UI
{
    public class LevelBar : MonoBehaviour
    {
        [SerializeField] ProgressBar progressBar;

        void Start()
        {
            Events.OnSoulGrabbed += OnSoulGrabbed;
        }
        void OnDestroy()
        {
            Events.OnSoulGrabbed -= OnSoulGrabbed;
        }
        public void OnInit(System.Action OnFilled)
        {
            progressBar.Init(0, OnFilled);
            progressBar.SetValue(0);
        }
        void AddValue()
        {
            progressBar.Add(0.025f);
        }
        void OnSoulGrabbed(string s)
        {
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
