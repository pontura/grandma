using UnityEngine.UI;
using UnityEngine;
using Tumba.UI;

namespace Tumba.Game.UI
{
    public class RebornBar : MonoBehaviour
    {
        [SerializeField] ProgressBar progressBar;
        [SerializeField] Image image;
        float value;
        GameObject go;

        public void Init(GameObject go, Color color)
        {
            this.go = go;
            value = 1;
            progressBar.Init(value, null);
            image.color = color;
        }
        void OnDestroy()
        {
        }
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        void Update()
        {
            transform.position = Camera.main.WorldToScreenPoint(go.transform.position);
        }
        public void SetValue(float v)
        {
            value = v;
            if (value < 0) value = 1; else if (value > 1) value = 1;
            progressBar.SetValue(value);
            if (value == 0)
                OnDone();
        }
        void OnDone()
        {
            Debug.Log("Done!");
        }
    }
}
