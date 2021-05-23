using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButtonsInObjectsMenu : MonoBehaviour
{
    [SerializeField] private ObjectsMenuItem[] items;
    [SerializeField] private GameObject objectPanel;
    [SerializeField] private RectTransform button;
    private GameObject[] _activeItems;
    void Start()
    {
        Vector3 buttonSize = button.sizeDelta;
        _activeItems = new GameObject[items.Length];
        for (var i = 0; i < 2; i++)
        {

            var current = Instantiate(button,objectPanel.transform);
            current.anchoredPosition -= new Vector2(0, buttonSize.y * i+1);
            current.GetComponent<ObjectMenuButton>().Init(items[i]);
            _activeItems[i] = current.gameObject;
        }
    }
}
