using UnityEngine;
using UnityEngine.UI;

namespace Tumba.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] Image image;
        System.Action OnFilled;
        float v;

        public void Init(float value, System.Action OnFilled)
        {
            this.OnFilled = OnFilled;
            SetValue(value);
        }
        public void Add(float value)
        {
            v += value;
            SetValue(v);
        }
        public void SetValue(float value)
        {
            v = value;
            if (v >= 1)
            {
                image.fillAmount = 1;
                if (OnFilled != null)
                {
                    OnFilled();
                    OnFilled = null;
                }
            }
            else
            {
                image.fillAmount = v;
            }
        }
        private void OnDestroy()
        {
            if(OnFilled != null)
                OnFilled = null;
        }
    }
}