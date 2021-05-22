using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;
using UnityEngine;

public class UnitInfo
{
    public int Id {get;}
    public int Type {get;}
    public double Lat {get;}
    public double Lng {get;}
    public bool IsFree {get;}

    public UnitInfo(int id, int type, double lat, double lng, bool isFree)
    {
        Id = id;
        Type = type;
        Lat = lat;
        Lng = lng;
        IsFree = isFree;
    }

    public void Deconstruct(out int id, out int type, out double lat, out double lng, out bool isFree)
    {
        id = Id;
        type = Type;
        lat = Lat;
        lng = Lng;
        isFree = IsFree;
    }
}
