using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderMenu : MonoBehaviour
{
    [SerializeField] GameObject orderPanel;
    [SerializeField] Text text;
    public void OrderMenuOn(string buttonText)
    {
        text.text = buttonText;
        Debug.Log(buttonText);
    }
    public void OrderMenuOff()
    {
        Destroy(gameObject);
    }
}
