using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatesContainer : MonoBehaviour
{
    public double x;
    public double y;
    public CoordinatesContainer container;

    private void Start()
    {
        if(container == null)
            return;
        Vector2 vec = new Vector2((float) (container.x - x), (float) (container.y - y)).normalized;
        Debug.Log($"{vec.x}, {vec.y}");
    }
}
