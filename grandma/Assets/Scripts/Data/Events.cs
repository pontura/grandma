using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tumba.UI;

public static class Events
{
    public static System.Action EnergyUpdated = delegate { };  
    public static System.Action ResetApp = delegate { };  
    public static System.Action<ButtonCustom.types> OnButtonPressed = delegate { };   

}