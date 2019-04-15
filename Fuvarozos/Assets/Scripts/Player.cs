using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string Id;
    public int Balance;
    public string Name;
    public CitiesDropdownController.Cities SelectedCity;

    public Player(string id, string name)
    {
        Id = id;
        Name = name;
        Balance = 1000;
        SelectedCity = CitiesDropdownController.Cities.Nincs;
    }
}
