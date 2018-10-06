using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle
{
    public Vehicle(int id, Quality quality, int vehiclePurchaseRound,  int motTestDuration)
    {
        Id = id;
        Quality = quality;
        MOTTestDuration = motTestDuration;
    }
    public int Id;
    public Quality Quality;
    public int VehiclePurchaseRound;
    public int MOTTestDuration;
}
