using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using RestSharp;

public class Server
{
    private const string BasePath = "http://localhost:8888";
    private const string UnitInfoPath = "/";
    private const string TimePath = "/";
    private const string WeatherPath = "/";
    private readonly ServerInternal _internal;

    public Server()
    {
        _internal = new ServerInternal();
    }

    public UnitInfo GetUnitInfo() => _internal.GetInfo<UnitInfo>(UnitInfoPath);

    public UnitInfo[] GetUnitsInfo() => _internal.GetInfo<UnitInfo[]>(UnitInfoPath);

    public Time GetTime() => _internal.GetInfo<Time>(TimePath);

    public Weather GetWeather() => _internal.GetInfo<Weather>(WeatherPath);

    private class ServerInternal
    {
        public T GetInfo<T>(string subPath) where T : class
        {
            var response = GetInfo(subPath);

            var result = Deserialize<T>(response);

            return result;
        }
        
        private IRestResponse GetInfo(string subPath)
        {
            var client = new RestClient(BasePath + subPath) {Timeout = -1};
            var request = new RestRequest(Method.POST);
            var response = client.Execute(request);
            if (response.IsSuccessful == false)
                throw new Exception("Response not completed");

            return response;
        }

        [CanBeNull]
        private T Deserialize<T>(IRestResponse response) where T : class
        {
            T result = null;
            try
            {
                result = JsonSerializer.Deserialize<T>(response.RawBytes);
            }
            catch (Exception e)
            {
                Debug.Log($"Error: {e.Message}");
            }

            return result;
        }
    }
}
