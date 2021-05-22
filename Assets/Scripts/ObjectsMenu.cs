using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsMenu : MonoBehaviour
{
    [SerializeField] private GameObject objectMenu;
    [SerializeField] private GameObject[] VPPs;
    [SerializeField] private Button thisButton;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite highlightSprite;
    private bool f = false;
    
    public void OpenObjectsMenu() 
    {
        var actualsprite = thisButton.spriteState;
        if (f)
        {
            thisButton.image.sprite = highlightSprite;
            actualsprite.highlightedSprite = normalSprite;
            thisButton.spriteState = actualsprite;
            objectMenu.SetActive(false);
            f = false;
        }
        else 
        { 
            thisButton.image.sprite = normalSprite;
            actualsprite.highlightedSprite = highlightSprite;
            thisButton.spriteState = actualsprite;
            objectMenu.SetActive(true);
            f = true;
        }
    }

    public void CloseContextMenu()
    {
        ContextMenuTracker.handler?.DestroyMenu();
    }
}
