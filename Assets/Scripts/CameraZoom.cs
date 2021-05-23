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
            double zoom = camera.orthographicSize-10;
            StartCoroutine(ZoomCameraIn(zoom));
        }
    }
    public void ZoomOut()
    {
        if (camera.orthographicSize < 150) 
        {
            double zoom = camera.orthographicSize + 10;
            StartCoroutine(ZoomCameraOut(zoom));
        }
    }
    IEnumerator ZoomCameraIn(double zoom) 
    {
        while (camera.orthographicSize > zoom) 
        {
            camera.orthographicSize -= 70 * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator ZoomCameraOut(double zoom) 
    {
        while (camera.orthographicSize < zoom)
        {
            camera.orthographicSize += 70 * Time.deltaTime;
            yield return null;
        }
    }
}
