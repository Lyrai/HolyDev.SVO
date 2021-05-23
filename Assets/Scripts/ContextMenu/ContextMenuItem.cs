using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable, CreateAssetMenu]
public class ContextMenuItem : ScriptableObject
{
    public string text;
    public UnityEvent Click;
    public ContextMenuItem[] items;
    public GameObject window;
    public float lat;
    public float lng;
    public int? id;
    public int orderType;
    
    public void CreateWindow() 
    {
        var current = Instantiate(window, CanvasSingleton.instance.transform).GetComponent<OrderMenu>();
        if(id != null)
            current.OrderMenuOn(text, id, orderType);
        else
            current.OrderMenuOn(text, lat, lng, orderType);
    }
}
