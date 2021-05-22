using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Camera camera;
    void Start()
    {
       
    }
    public void ZoomIn() 
    {
        if (camera.orthographicSize > 30)
        {
            camera.orthographicSize -= 10;
        }
    }
    public void ZoomOut()
    {
        if (camera.orthographicSize < 150) 
        { 
            camera.orthographicSize += 10;
        }
    }
    void Update()
    {
        
    }
}
