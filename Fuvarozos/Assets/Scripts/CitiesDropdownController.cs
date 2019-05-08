using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class CitiesDropdownController : MonoBehaviour
{

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
    public Dropdown Dropdown;
    public Text SelectedCity;
    public Text NextPlayerText;
    public void Dropdown_IndexChanged(int index)
    {
        Debug.Log((Cities)index);
        GameController.Instance.CurrentPlayer.SelectedCity = (Cities)index;
        if (index == 0)
        {
            SelectedCity.text = GameController.Instance.CurrentPlayer.Name + "! Kérlek válassz telephelyet!";
        }
        else
        {
            SelectedCity.text = GameController.Instance.CurrentPlayer.Name + ". Az általad választott székhely: " + GameController.Instance.CurrentPlayer.SelectedCity;
        }

    }

    void Start()
    {
        Dropdown.onValueChanged.AddListener(Dropdown_IndexChanged);
        PopulateList();

        SelectedCity.text = GameController.Instance.CurrentPlayer.Name + "! Kérlek válassz telephelyet!";
        NextPlayerText.text = "Következő Játékos";
    }

    void OnDestroy()
    {
        Dropdown.onValueChanged.RemoveListener(Dropdown_IndexChanged);
    }

    public void OnNextPlayerClick()
    {
        if (GameController.Instance.CurrentPlayer == GameController.Instance.Players.Last())
        {
            IngameUIController.Instance.CitiesDropdownController.gameObject.SetActive(false);
            IngameUIController.Instance.ShopUiController.gameObject.SetActive(true);

            return;
        }

        GameController.Instance.SelectNextPlayer();
        Dropdown.value = (int)GameController.Instance.CurrentPlayer.SelectedCity;
        if (GameController.Instance.PlayerCount - 1 == GameController.Instance.CurrentPlayerIndex)
        {
            NextPlayerText.text = "Játék indítása";
        }
    }

    void PopulateList()
    {
        Dropdown.AddOptions(Enum.GetNames(typeof(Cities)).ToList());
    }
}

