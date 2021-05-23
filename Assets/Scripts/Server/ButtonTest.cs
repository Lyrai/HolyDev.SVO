using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public void Test()
    {
        var server = new Server();
        var ids = server.GetUnitsInfo();
    }
}
