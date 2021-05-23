using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatesContainer : MonoBehaviour
{
    public static CoordinatesContainer instance;
    public float x;
    public float y;
    public CoordinatesContainer containerX;
    public CoordinatesContainer containerY;
    [SerializeField] private float xTest;
    [SerializeField] private float yTest;
    [SerializeField] private Transform test;
    private Vector2 _xAxisWorld;
    private Vector2 _yAxisWorld;
    private Vector2 _xAxisMap;
    private Vector2 _yAxisMap;

    private float _xK;
    private float _yK;

    //z rotation 13.089
    private void Start()
    {
        if (containerX == null)
            return;
        instance = this;
        
        _xAxisWorld = (Vector2)containerX.transform.position - (Vector2)transform.position;
        _yAxisWorld = (Vector2)containerY.transform.position - (Vector2)transform.position;
        _xAxisMap = new Vector2(containerX.x - x, containerX.y - y);
        _yAxisMap = new Vector2(containerY.x - x, containerY.y - y);
        _xK = _xAxisWorld.magnitude / _xAxisMap.magnitude;
        _yK = _yAxisWorld.magnitude / _yAxisMap.magnitude;

        var a = MapToWorldCoord(new Vector2(xTest, yTest));
        Debug.Log($"{a.x}, {a.y}");
        
        a = WorldToMapCoord(test.position);
        Debug.Log($"{a.x}, {a.y}");
    }

    public Vector2 MapToWorldCoord(Vector2 position)
    {
        var angle = Mathf.Deg2Rad * 13;
        
        var vec = new Vector2(position.x - x, position.y - y);
        
        float yValue = vec.y * _yK + transform.position.y;
        float xValue = vec.x * _xK + transform.position.x;
        
        var yOffset = InverseLerp(-64f, 335.3f, yValue) * 15;
        yOffset *= xValue > transform.position.x ? 1 : -1;
        
        var xOffset = InverseLerp(27.9f, 590.9f, xValue) * 14;
        
        vec = new Vector2(xValue - xOffset, yValue - yOffset);
        vec = new Vector2((float)(vec.x * Math.Cos(angle) + vec.y * Math.Sin(angle)),
            (float)(-vec.x * Math.Sin(angle) + vec.y * Math.Cos(angle)));
        
        return vec;
    }

    public Vector2 WorldToMapCoord(Vector2 position)
    {
        var angle = Mathf.Deg2Rad * -13;
        
        var vec = new Vector2(position.x - transform.position.x, position.y - transform.position.y);
        
        float yValue = vec.y / _yK + y;
        float xValue = vec.x / _xK + x;

        vec = new Vector2(xValue, yValue);
        vec = new Vector2((float)(vec.x * Math.Cos(angle) + vec.y * Math.Sin(angle)),
            (float)(-vec.x * Math.Sin(angle) + vec.y * Math.Cos(angle)));

        vec += new Vector2(14, -7);

        return vec;
    }

    private float InverseLerp(float elem1, float elem2, float value)
    {
        Debug.Log(value);
        return (value - elem1) / (elem2 - elem1);
    }
}



public class Matrix2x2
{
    private float[,] _matrix = new float[2,2];
    
    public Matrix2x2(Vector2 vec1, Vector2 vec2)
    {
        _matrix[0, 0] = vec1.x;
        _matrix[1, 0] = vec1.y;
        _matrix[0, 1] = vec2.x;
        _matrix[1, 1] = vec2.y;
    }

    public float this[int index]
    {
        get
        {
            index -= 11;
            return _matrix[index / 10, index % 10];
        }
        set
        {
            index -= 11;
            _matrix[index / 10, index % 10] = value;
        }
    }

    public static Vector2 operator *(Matrix2x2 matrix, Vector2 vector)
    {
        Vector2 result = new Vector2();
        result.x = matrix[11] * vector.x + matrix[12] * vector.y;
        result.y = matrix[21] * vector.x + matrix[22] * vector.y;

        return result;
    }
}