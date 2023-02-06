using UnityEngine.UI;
using UnityEngine;
using Tumba.UI;

namespace Tumba.Game.UI
{
    public class EnergyBar : MonoBehaviour
    {
        [SerializeField] ProgressBar progressBar;
        float value;

        public void Init()
        {
            value = 1;
            progressBar.Init(value, null);
           // Events.OnSoulGrabbed += OnSoulGrabbed;
        }
        void OnDestroy()
        {
         //   Events.OnSoulGrabbed -= OnSoulGrabbed;
        }
        public void SetValue(float v)
        {
            value = v;
            if (value < 0) value = 1; else if (value > 1) value = 1;
            progressBar.SetValue(value);
            if (value == 0)
                OnDone();
        }
        void OnSoulGrabbed(string s)
        {
            print("OnSoulGrabbed " + s);
            switch (s)
            {
                case "SOUL":
                  //  AddValue();
                    break;
            }
        }
        void OnDone()
        {
            Debug.Log("Done!");
        }
    }
}
