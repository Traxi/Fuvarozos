using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string Id;
    public int Balance;
    public string Name;
    public CitiesDropdownController.Cities SelectedCity;
    public List<Vehicle> Vehicles = new List<Vehicle>();
    public List<Driver> Drivers = new List<Driver>();
    public Player(string id, string name)
    {
        Id = id;
        Name = name;
        Balance = 200;
        SelectedCity = CitiesDropdownController.Cities.Nincs;
        Vehicles.Add(new Vehicle(Quality.Normal, GameController.Instance.CurrentRound, 80));
        Drivers.Add(new Driver(Quality.Normal));
    }
}
