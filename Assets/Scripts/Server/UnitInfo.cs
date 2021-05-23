using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;
using UnityEngine;

public class UnitInfo
{
    public int id {get; set; }
    public int type {get; set; }
    public double lat {get; set; }
    public double lng {get; set; }
    public bool status {get; set; }
    public string date { get; set; }
    public int user_type { get; set; }
    public string username { get; set; }
}
