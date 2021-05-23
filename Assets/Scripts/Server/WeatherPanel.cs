using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherPanel : MonoBehaviour
{
    [SerializeField] private Text text;
    private Server _server;
    private Weather _weather;
    private void Start()
    {
        StartCoroutine(GetWeather());
    }

    private IEnumerator GetWeather()
    {
        while (true)
        {
            _server = new Server();
            _weather=_server.GetWeather();
            text.text =$"Температура:{_weather.temp}  ветер:{_weather.wind}  скорость ветра:{_weather.val}  осадки:{_weather.osd}  количество осадков:{_weather.osdVal}";
            yield return new WaitForSeconds(2 * 60f);
        }
    }
}

public class Weather
{
    public string wind { get; set; }
    public float val { get; set; }
    public string osd { get; set; }
    public float osdVal { get; set; }
    public float temp { get; set; }

    
    /*public Weather(string wind, float val, string osd, float osdVal, float temp)
    {
        Wind = wind;
        Val = val;
        Osd = osd;
        OsdVal = osdVal;
        Temp = temp;
    }*/
}