using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSingleton : MonoBehaviour
{
    public static Canvas instance;

    private void Awake()
    {
        instance = GetComponent<Canvas>();
    }
}
