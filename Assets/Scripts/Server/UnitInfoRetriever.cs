using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoRetriever : MonoBehaviour
{
    [SerializeField] private Text[] texts;
    private Server _server;

    private void Start()
    {
        _server = new Server();
        StartCoroutine(GetInfo());
    }

    private IEnumerator GetInfo()
    {
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                var units = _server.GetFreeUnitsByType(i + 1, 2);
                texts[i].text = units.Length.ToString();
            }
            yield return new WaitForSeconds(60f);
        }
    }
}
