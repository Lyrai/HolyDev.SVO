using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public void Test()
    {
        var server = new Server();
        var unit = server.GetUnitsInfo();
        for (var i = 0; i < unit.Length; i++)
        {
            (int id, int type, double lat, double lng, bool isFree) = unit[i];
            Debug.Log($"{i}: {id}, {type}, {lat}, {lng}, {isFree}");
        }
    }
}
