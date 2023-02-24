using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tumba.Game.UI
{
    public class ScreensManager : MonoBehaviour
    {
        public UIScreen[] all;
        Dictionary<string, UIScreen> instantiated;

        public enum types
        {
            LEVELS_UPGRADE
        }
        void Start()
        {
            Events.OnScreenOpen += OnScreenOpen;
            Events.OnScreenClose += OnScreenClose;
            instantiated = new Dictionary<string, UIScreen>();
        }
        void OnDestroy()
        {
            Events.OnScreenOpen -= OnScreenOpen;
            Events.OnScreenClose -= OnScreenClose;
        }
        void OnScreenOpen(types t)
        {
            UIScreen u = GetScreen(t);
            u.Open();
        }
        void OnScreenClose(types t)
        {
            UIScreen u = GetScreen(t);
            u.Close();
        }
        UIScreen GetScreen(types t)
        {
            UIScreen uiScreen = null;
            if (instantiated.ContainsKey(t.ToString()))
                uiScreen = instantiated[t.ToString()];
            if (uiScreen != null)
                return uiScreen;

            foreach (UIScreen _uiScreen in all)
                if (_uiScreen.type == t)
                    uiScreen = Instantiate(_uiScreen, transform);
            Debug.Log("New screen for " + t);
            instantiated.Add(t.ToString(), uiScreen);
            if (uiScreen == null)  Debug.LogError("New screen for " + t);
            return uiScreen;
        }
    }

}