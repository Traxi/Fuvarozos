using System.Collections;
using System.Collections.Generic;

public class Vehicle
{
    private static string GenerateId()
    {
        System.Random random = new System.Random();
        var byteArray = new byte[32];
        random.NextBytes(byteArray); //fill with random bytes
        return byteArray.ToString();
    }

    public Vehicle(Quality quality, int vehiclePurchaseRound, int motTestDuration)
    {
        Id = GenerateId();
        Quality = quality;
        MOTTestDuration = motTestDuration;
        VehiclePurchaseRound = vehiclePurchaseRound;
    }
    public string Id;
    public Quality Quality;
    public int VehiclePurchaseRound;
    public int MOTTestDuration;
}
