using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCamera : MonoBehaviour
{
    [SerializeField] private GameObject empty1;
    [SerializeField] private GameObject empty2;
    private Camera camera;
    private Transform transformCamera;
    private void Start()
    {
        camera = Camera.main;
        transformCamera = camera.transform;
    }
    void Update()
    {
        CheckBorders();
    }
    private void CheckBorders() 
    { 
        Vector3[] frustumCorners = new Vector3[4];
        camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);
        if (transformCamera.position.x + frustumCorners[0].x <= empty1.transform.position.x)
            transformCamera.position = new Vector3(empty1.transform.position.x - frustumCorners[0].x, camera.transform.position.y, transformCamera.position.z);
       
        if(camera.transform.position.y + frustumCorners[0].y <= empty1.transform.position.y)
            transformCamera.position = new Vector3(camera.transform.position.x, empty1.transform.position.y - frustumCorners[0].y,transformCamera.position.z);
        
        if (camera.transform.position.x+frustumCorners[2].x >= empty2.transform.position.x)
            transformCamera.position = new Vector3(empty2.transform.position.x-frustumCorners[2].x, camera.transform.position.y,transformCamera.position.z);
        
        if (camera.transform.position.y+frustumCorners[2].y >= empty2.transform.position.y)
            transformCamera.position = new Vector3(camera.transform.position.x, empty2.transform.position.y - frustumCorners[2].y,transformCamera.position.z);
    }
    
}
