using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

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
        //StartCoroutine(MoveCamera(transform.position,200f));

    }
    /*IEnumerator MoveCamera(Vector3 position, float speed)
    {
            while (Vector3.Distance(positionCamera.position, position) > 180f)
            {
                positionCamera.position = Vector3.MoveTowards(positionCamera.position, position, Time.deltaTime * speed);
                yield return null;
            }
        //positionCamera.position = position;
    }*/
}
