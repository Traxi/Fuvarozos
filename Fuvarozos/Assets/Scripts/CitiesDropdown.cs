using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CitiesDropdown : MonoBehaviour {

  enum Cities
    {
        Nincs,
        Győr,
        Budapest,
        Miskolc,
        Szombathely,
        Székesfehérvár,
        Kecskemét,
        Debrecen,
        Pécs,
        Szeged,
        Békéscsaba,
    }
    public Dropdown dropdown;
    public Text selectedcity;

    public void Dropdown_IndexChanged(int index)
    {
        Cities name = (Cities)index;
        

        if (index == 0)
        {
            selectedcity.text = "Kérlek válassz telephelyet!";
        }
        else
        {
            selectedcity.text = "Az általad választott székhely: "+name.ToString();
        }

    }



    void Start()
    {
        PopulateList();

    }
    void PopulateList()
    {
        string[] enumNames = Enum.GetNames(typeof(Cities));
        List<string> names = new List<string>(enumNames);
        dropdown.AddOptions(names);
    }
}

