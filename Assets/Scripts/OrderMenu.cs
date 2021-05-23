using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderMenu : MonoBehaviour
{
    public float lat;
    public float lng;
    public int? id;
    [SerializeField] private GameObject orderPanel;
    [SerializeField] private Text text;
    [SerializeField] private GameObject circle;
    [SerializeField] private Text descriptionText;
    private Server _server;
    private int _orderType;
    private int[] _units;
    private UnitInfo _admin;

    public void OrderMenuOn(string buttonText, int? id, int orderId)
    {
        text.text = buttonText;
        this.id = id;
        _orderType = orderId;
        _server = new Server();
        var typeToTake = orderId switch
        {
            1 => 4,
            2 => 5,
            3 => 2,
            4 => 1,
            5 => 3,
            6 => 1,
            7 => 4
        };
        _units = _server.GetFreeUnitsByType(typeToTake, 2).Take(10).Select(x => x.id).ToArray();
        _admin = _server.GetFreeUnitsByType(typeToTake, 1)[0];
        var sb = new StringBuilder();
        sb.Append("Будут использованы машины с id: ");
        for (var i = 0; i < _units.Length - 1; i++)
        {
            sb.Append($"{_units[i]}, ");
        }

        sb.Append(_units[_units.Length - 1]);
        sb.Append($"\nБудет назначен контролер с id {_admin.id}");
        descriptionText.text = sb.ToString();
    }

    public void OrderMenuOn(string buttonText, float lat, float lng, int orderId)
    {
        text.text = buttonText;
        this.lat = lat;
        this.lng = lng;
        _orderType = orderId;
    }
    
    public void OrderMenuOff()
    {
        Destroy(gameObject);
    }

    public void SendRequest()
    {
        if (id != null)
        {
            //_server.SetOrderWithObject(_orderType, id.Value, _units, _admin.id);
        }
        else
        {
            _server.SetOrderWithCoords(_orderType, lat, lng, _units, _admin.id);
        }

        CanvasSingleton.instance.GetComponent<CanvasSingleton>().StartCoroutine(StartAnimation());
        StartCoroutine(StartAnimation());
        OrderMenuOff();
    }

    public IEnumerator StartAnimation()
    {
        for (int i = 0; i < 10; i++)
        {
            var current = Instantiate(circle, new Vector3(-19.93f, 19.58f, -4), Quaternion.identity).GetComponent<Animation>();
            current.Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
