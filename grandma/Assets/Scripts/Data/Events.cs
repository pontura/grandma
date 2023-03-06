using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tumba.UI;
using Tumba.Game.UI;
using Tumba.Game.Characters;
using Tumba.Game.Levels;

public static class Events
{
    public static System.Action EnergyUpdated = delegate { };  
    public static System.Action ResetApp = delegate { };  
    public static System.Action<string> OnSoulGrabbed = delegate { };
    public static System.Action<Color> AddHelper = delegate { };
    public static System.Action<WaveData> InitWave = delegate { };

    //UI
    public static System.Action<string> OnButtonPressed = delegate { };
    public static System.Action<ScreensManager.types> OnScreenOpen = delegate { };
    public static System.Action<ScreensManager.types> OnScreenClose = delegate { };


}