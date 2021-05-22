using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour, IPointerDownHandler , IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    [SerializeField] private Camera camera;
    private Transform positionCamera;
    
    private void Awake()
    {
        positionCamera = camera.GetComponent<Transform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        ContextMenuTracker.handler?.DestroyMenu();
        Debug.Log("OnBeginDrag");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }
    public void OnDrag(PointerEventData eventData) 
    {
        
        Debug.Log("OnDrag");
        positionCamera.position -= (Vector3)eventData.delta*0.1f;
    }
    public void OnPointerDown(PointerEventData eventData) 
    {
        Debug.Log("OnPointerDown");
    }

}
