using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{
    [SerializeField] private Text text;
    private Server _server;
    private TimeInfo _time;
    private void Start()
    {
        _server = new Server();
        _time = _server.GetTime();
        StartCoroutine(GetTime());
    }

    private IEnumerator GetTime()
    {
        while (true)
        {
            _time++;
            text.text = $"{_time.Hours / 10}{_time.Hours % 10}:{_time.Minutes / 10}{_time.Minutes % 10}";
            yield return new WaitForSeconds(1f);
        }
    }
}

public class TimeInfo
{
    public int Hours { get; private set; }
    public int Minutes { get; private set; }
    public int Seconds { get; private set; }
    
    public TimeInfo(int hours, int minutes)
    {
        Hours = hours % 24;
        Minutes = minutes;
        Seconds = 0;
    }

    public static TimeInfo operator ++(TimeInfo time)
    {
        time.Seconds++;
        if (time.Seconds >= 60)
        {
            time.Seconds %= 60;
            time.Minutes++;
        }

        if (time.Minutes >= 60)
        {
            time.Minutes %= 60;
            time.Hours++;
        }

        if (time.Hours >= 24)
            time.Hours %= 24;

        return time;
    }
}