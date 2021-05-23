using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ContextMenu : ScriptableObject
{
    [SerializeField] private ContextMenuItem[] items;
    [SerializeField] private RectTransform button;
    private GameObject[] _activeItems;

    public void Create(Vector3 position, int id)
    {
        Create(position);
        for (var i = 0; i < items.Length; i++)
        {
            items[i].id = id;
        }
    }

    public void Create(Vector3 position, Vector2 latlng)
    {
        Create(position);
        for (var i = 0; i < items.Length; i++)
        {
            items[i].lat = latlng.x;
            items[i].lng = latlng.y;
        }
    }
    
    private void Create(Vector3 position)
    {
        Vector3 buttonSize = button.sizeDelta;
        _activeItems = new GameObject[items.Length];
        for (var i = 0; i < items.Length; i++)
        {
            var current = Instantiate(button, CanvasSingleton.instance.transform);
            current.position = new Vector3(position.x, position.y,-1);
            current.anchoredPosition -= new Vector2(0, buttonSize.y * i);
            items[i].Click.AddListener(Destroy);
            current.GetComponent<ContextMenuButton>().Init(items[i]);
            _activeItems[i] = current.gameObject;
        }
    }

    public void Destroy()
    {
        foreach (var activeItem in _activeItems)
        {
            Destroy(activeItem);
        }

        _activeItems = new GameObject[items.Length];
    }

    public void DestroyActiveMenu()
    {
        ContextMenuTracker.handler.DestroyMenu();
    }
}
