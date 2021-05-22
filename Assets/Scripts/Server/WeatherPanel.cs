using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherPanel : MonoBehaviour
{
    [SerializeField] private Text text;
    private Server _server;
    
    private void Start()
    {
        StartCoroutine(GetTime());
    }

    private IEnumerator GetTime()
    {
        while (true)
        {
            _server.GetWeather();
            yield return new WaitForSeconds(1f);
        }
    }
}

public class Weather
{
    
}