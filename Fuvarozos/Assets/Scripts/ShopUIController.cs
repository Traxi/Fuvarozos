using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    public Dropdown WhatDropdown;
    public Dropdown QualityDropdown;

    // Start is called before the first frame update
    void OnEnable()
    {
        WhatDropdown.ClearOptions();
        QualityDropdown.ClearOptions();
        FIllWhatDropdown();

        GameController.Instance.CurrentPlayer = GameController.Instance.Players.FirstOrDefault();
    }

    void OnDisable()
    {

    }

    private void FIllWhatDropdown()
    {
        WhatDropdown.AddOptions(new List<string>() { "Vehicle", "Driver", "MOT" });
    }

    public void OnBuyClick()
    {

    }

}
