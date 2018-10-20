using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    private void OnEnable()
    {
        TeamCount.onValueChanged.AddListener(OnPlayerCounteditEnd);
    }

    private void OnDisable()
    {
        TeamCount.onValueChanged.RemoveListener(OnPlayerCounteditEnd);
    }

    public GameObject InitialMenu;
    public GameObject PlayerSetup;
    public InputField[] Rounds;
    public InputField TeamCount;
    public InputField[] Teams;

    private void OnNewGameStart()
    {
        for (int i = 0, length = Rounds.Length; i < length; i++)
        {
            GameController.Instance.RoundNumbers[i] = int.Parse(Rounds[i].text);
        }
    }

    private void OnPlayerCounteditEnd(string value)
    {
        int outvalue = 0;
        int.TryParse(value, out outvalue);
        outvalue = Mathf.Clamp(outvalue, 2, 4);
        TeamCount.text = outvalue.ToString();

        for (int i = 0, length = Teams.Length; i < length; i++)
        {
            if (i < outvalue)
            {
                Teams[i].gameObject.SetActive(true);
            }
            else
            {
                Teams[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnNewGameClick()
    {
        Debug.Log("OnNewGameClick");
        InitialMenu.SetActive(false);
        GameController.Instance = null;
        PlayerSetup.SetActive(true);

        for (int i = 0, length = Rounds.Length; i < length; i++)
        {
            Rounds[i].text = GameController.Instance.RoundNumbers[i].ToString();
        }
    }

    public void OnBackClick()
    {
        Debug.Log("OnBackClick");
        InitialMenu.SetActive(true);
        PlayerSetup.SetActive(false);
    }

    public void OnRulesClick()
    {
        Debug.Log("OnRulesClick");
    }
    public void OnExitClick()
    {
        Debug.Log("OnExitClick");
    }

    public void OnGenerateMapClick()
    {
        Helpers.GenerateGameTiles(ref Gamerules.GameMap);
    }
}
