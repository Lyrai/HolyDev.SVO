using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using RestSharp;

public class Server
{
    private const string BasePath = "http://fe0a8c3570b2.ngrok.io";
    private const string UnitsInfoPath = "/all";
    private const string FreeUnitsByTypePath = "/free";
    private const string WeatherPath = "/weather";
    private const string SetOrderPath = "/SetOrder";
    private const string UnitByIdPath = "/id";
    private readonly ServerInternal _internal;

    public Server()
    {
        _internal = new ServerInternal();
    }

    public void SetOrderWithObject(int orderId, int vppId, int[] ids, int userId)
    {
        var client = new RestClient(BasePath + SetOrderPath) {Timeout = -1};
        var request = new RestRequest(Method.POST);
        System.Random rnd = new System.Random();
        request.AddHeader("order_id", rnd.Next(7, 100).ToString());
        request.AddHeader("vpp_id", vppId.ToString());
        request.AddHeader("order_type", orderId.ToString());
        var workerIds = string.Join(" ", ids);
        request.AddHeader("workers_id", workerIds);
        request.AddHeader("checker_id", userId.ToString());
        var response = client.Execute(request);
        if(response.IsSuccessful)
            Debug.Log("Request sent");
    }
    
    public void SetOrderWithCoords(int orderId, float lat, float lng, int[] ids, int userId)
    {
        var client = new RestClient(BasePath + SetOrderPath) {Timeout = -1};
        var request = new RestRequest(Method.POST);
        System.Random rnd = new System.Random();
        request.AddHeader("order_id", rnd.Next(7, 100).ToString());
        request.AddHeader("lat", lat.ToString(CultureInfo.InvariantCulture));
        request.AddHeader("lng", lng.ToString(CultureInfo.InvariantCulture));
        request.AddHeader("order_type", orderId.ToString());
        var workerIds = string.Join(" ", ids);
        request.AddHeader("workers_id", workerIds);
        request.AddHeader("checker_id", userId.ToString());
        var response = client.Execute(request);
        if(response.IsSuccessful)
            Debug.Log("Request sent");
    }

    public UnitInfo[] GetUnitsInfo() => _internal.GetInfo<UnitInfo[]>(UnitsInfoPath, Method.GET);

    public UnitInfo[] GetFreeUnitsByType(int type, int userType) =>
        _internal.GetInfo<UnitInfo[]>(FreeUnitsByTypePath, Method.POST, new Header("type", type.ToString()), new Header("user_type", userType.ToString()));

    public UnitInfo GetUnitById(int id) => _internal.GetInfo<UnitInfo>(UnitByIdPath, Method.POST);

    public TimeInfo GetTime()
    {
        var client = new RestClient("http://worldclockapi.com/api/json/utc/now");
        var request = new RestRequest(Method.GET);
        var response = client.Execute(request).Content;
        Regex exp = new Regex("\\d?\\dT\\d?\\d:\\d?\\d");
        var time = exp.Match(response).ToString().Split(':');
        time[0] = $"{time[0][3]}{time[0][4]}";
        Debug.Log(time[0]);
        var result = new TimeInfo(int.Parse(time[0]) + 3, int.Parse(time[1]));

        return result;
    }

    public Weather GetWeather() => _internal.GetInfo<Weather>(WeatherPath, Method.GET);

    private class ServerInternal
    {
        public T GetInfo<T>(string subPath, Method method, params Header[] headers) where T : class
        {
            var response = GetInfo(subPath, method, headers);

            var result = Deserialize<T>(response);

            return result;
        }
        
        private IRestResponse GetInfo(string subPath, Method method, params Header[] headers)
        {
            var client = new RestClient(BasePath + subPath) {Timeout = -1};
            var request = new RestRequest(method);
            foreach (var header in headers)
            {
                request.AddHeader(header.name, header.body);
            }
            var response = client.Execute(request);
            if (response.IsSuccessful == false)
                throw new Exception(response.StatusCode.ToString());

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

    private class Header
    {
        public string name;
        public string body;

        public Header(string name, string body)
        {
            this.name = name;
            this.body = body;
        }
    }
}
