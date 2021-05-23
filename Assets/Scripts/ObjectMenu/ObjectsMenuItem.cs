using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable, CreateAssetMenu]
public class ObjectsMenuItem : ScriptableObject
{
    public string text;
    public UnityEvent Click;
    public ObjectsMenuItem[] items;
    public GameObject _obj;
    private Camera camera;
    private Transform positionCamera;
    private void Awake()
    {
        camera = Camera.main;
        positionCamera = camera.GetComponent<Transform>();
    }
    public void CenterCameraToVPP()
    {
        positionCamera.position = new Vector3(_obj.transform.position.x, _obj.transform.position.y, positionCamera.position.z);
    }
}
