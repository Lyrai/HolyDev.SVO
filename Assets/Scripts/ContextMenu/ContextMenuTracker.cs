using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ContextMenuTracker
{
    public static bool isMenuActive;
    public static ClickHandler handler;
    
    public static void SetMenuState(bool state, ClickHandler handler)
    {
        isMenuActive = state;
        ContextMenuTracker.handler = handler;
    }
}
