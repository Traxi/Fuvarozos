using System.Collections;
using System.Collections.Generic;

public class Vehicle
{

    public Vehicle(Quality quality, int vehiclePurchaseRound, int motTestDuration)
    {
        Id = Helpers.GenerateId();
        Quality = quality;
        MOTTestDuration = motTestDuration;
        VehiclePurchaseRound = vehiclePurchaseRound;
    }
    public string Id;
    public Quality Quality;
    public int VehiclePurchaseRound;
    public int MOTTestDuration;
}
