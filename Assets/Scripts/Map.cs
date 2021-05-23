using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(ContextMenuTracker.isMenuActive)
            ContextMenuTracker.handler.DestroyMenu();
    }
}
