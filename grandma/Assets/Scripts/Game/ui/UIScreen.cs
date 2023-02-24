using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.UI
{
    public class UIScreen : MonoBehaviour
    {
        public ScreensManager.types type;
        public void Open()
        {
            gameObject.SetActive(true);
            OnInit();
        }
        public void Close()
        {
            gameObject.SetActive(false);
            OnClose();
        }
        public virtual void OnInit() { }
        public virtual void OnClose() { }
    }
}
