using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ContextMenu menu;
    private Camera _camera;
    private bool _isMenuActive;
    
    private void Start()
    {
        _camera = Camera.main;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnLeftClick();
        if (eventData.button == PointerEventData.InputButton.Right)
            OnRightClick(_camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, transform.position.z)));
    }

    public void DestroyMenu()
    {
        menu.Destroy();
    }

    private void OnRightClick(Vector3 position)
    {
        if(_isMenuActive)
            menu.Destroy();
        else if(ContextMenuTracker.isMenuActive && ContextMenuTracker.handler != this)
            ContextMenuTracker.handler.DestroyMenu();

        ContextMenuTracker.SetMenuState(true, this);
        if(GetComponent<Map>() == null && int.TryParse(name[3].ToString(), out int n))
            menu.Create(position, n);
        else
            menu.Create(position, CoordinatesContainer.instance.WorldToMapCoord(position));
        _isMenuActive = true;
    }

    private void OnLeftClick()
    {
        if(_isMenuActive)
        {
            menu.Destroy();
            ContextMenuTracker.SetMenuState(false, null);
        }
    }
}
