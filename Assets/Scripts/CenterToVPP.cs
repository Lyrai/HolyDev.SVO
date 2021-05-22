using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterToVPP : MonoBehaviour
{
    private Camera camera;
    private Transform positionCamera;
    private void Awake()
    {
        camera = Camera.main;
        positionCamera = camera.GetComponent<Transform>();
    }
    public void CenterCameraToVPP() 
    {
        positionCamera.position = new Vector3(transform.position.x, transform.position.y, positionCamera.position.z);
    }
}
