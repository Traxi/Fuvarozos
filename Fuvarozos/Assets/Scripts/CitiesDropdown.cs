using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class CitiesDropdown : MonoBehaviour
{

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
        Debug.Log((Cities)index);
        Cities name = (Cities)index;
        if (index == 0)
        {
            selectedcity.text = "Kérlek válassz telephelyet!";
        }
        else
        {
            selectedcity.text = "Az általad választott székhely: " + name.ToString();
        }

    }



    void Start()
    {
        dropdown.onValueChanged.AddListener(Dropdown_IndexChanged);
        PopulateList();
    }

    void OnDestroy()
    {
        dropdown.onValueChanged.RemoveListener(Dropdown_IndexChanged);
    }

    void PopulateList()
    {
        dropdown.AddOptions(Enum.GetNames(typeof(Cities)).ToList());
    }
}

