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

    public Player(string id, string name)
    {
        Id = id;
        Name = name;
        Balance = 200;
        SelectedCity = CitiesDropdownController.Cities.Nincs;
        Vehicles.Add(new Vehicle(Quality.Normal, GameController.CurrentRound, 80));
    }
}
