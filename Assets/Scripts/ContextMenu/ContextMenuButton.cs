using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextMenuButton : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Button button;

    public void Init(ContextMenuItem item)
    {
        text.text = item.text;
        button.onClick.AddListener(item.Click.Invoke);
    }
}
