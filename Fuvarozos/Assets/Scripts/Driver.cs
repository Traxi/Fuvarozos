using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Driver
{
    public Driver(Quality quality)
    {
        Id = Helpers.GenerateId();
        Quality = quality;
    }
    public string Id;
    public Quality Quality;
}
