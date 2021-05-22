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
    public void CreateWindow() 
    {
        var current = Instantiate(window, CanvasSingleton.instance.transform).GetComponent<OrderMenu>();
        current.OrderMenuOn(text);
    }
    public void T()
    {
        Debug.Log("aa");
    }
}
