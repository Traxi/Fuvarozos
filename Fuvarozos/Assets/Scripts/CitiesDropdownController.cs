using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class CitiesDropdownController : MonoBehaviour
{
    private Player _currentPlayer;
    private Player CurrentPlayer
    {
        get { return _currentPlayer; }
        set
        {
            _currentPlayer = value;
            dropdown.value = (int) _currentPlayer.SelectedCity;
        }
    }

    private int currentPlayerIndex = 0;

    public enum Cities
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
        CurrentPlayer.SelectedCity = (Cities)index; 
        if (index == 0)
        {
            selectedcity.text =CurrentPlayer.Name+"! Kérlek válassz telephelyet!";
        }
        else
        {
            selectedcity.text =CurrentPlayer.Name+ ". Az általad választott székhely: " + CurrentPlayer.SelectedCity;
        }

    }



    void Start()
    {
        dropdown.onValueChanged.AddListener(Dropdown_IndexChanged);
        PopulateList();
        CurrentPlayer = GameController.Instance.Players.FirstOrDefault();
        selectedcity.text = CurrentPlayer.Name + "! Kérlek válassz telephelyet!";

    }

    void OnDestroy()
    {
        dropdown.onValueChanged.RemoveListener(Dropdown_IndexChanged);
    }

    public void OnNextPlayerClick()
    {
        if (currentPlayerIndex < GameController.Instance.Players.Count-1)
            CurrentPlayer = GameController.Instance.Players[++currentPlayerIndex];
    }

    void PopulateList()
    {
        dropdown.AddOptions(Enum.GetNames(typeof(Cities)).ToList());
    }
}

