using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamComponent : MonoBehaviour
{
    public Player CurrentPlayer;
    public Text PlayerName;
    private MenuController _menuController;

    public void OnNameChanged(string value)
    {
        CurrentPlayer.Name = value;

    } 
    private void Start()
    {
        _menuController = FindObjectOfType<MenuController>();

    }
    public void OnRemovePlayerClick()
    {
        _menuController.OnRemovePlayer(CurrentPlayer.Id);
    }
}
