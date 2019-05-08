using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public LineRenderer lr;
    public Vector3[] GameTilePositions;

    public GameObject InitialMenu;
    public GameObject PlayerSetup;
    public InputField[] Rounds;

    public Transform TeamContainer;
    private List<TeamComponent> Teams = new List<TeamComponent>();


    private void OnNewGameStart()
    {
        for (int i = 0, length = Rounds.Length; i < length; i++)
        {
            GameController.Instance.RoundNumbers[i] = int.Parse(Rounds[i].text);
        }
    }

    public void OnAddNewPlayerClick()
    {
        if (GameController.Instance.PlayerCount < 4)
            GameController.Instance.AddPlayers(new Player(
                Guid.NewGuid().ToString(),
                ""
                ));
        RenderTeams();
    }

    public void OnRemovePlayer(string id)
    {
        GameController.Instance.RemovePlayerById(id);
        RenderTeams();
    }

    private void RenderTeams()
    {
        for (int i = 0; i < Teams.Count; i++)
        {
            if (Teams[i] && Teams[i].gameObject)
                Destroy(Teams[i].gameObject);
        }
        Teams.Clear();


        for (int i = 0; i < GameController.Instance.PlayerCount; i++)
        {
            var go = Instantiate(Resources.Load<TeamComponent>("Team"));
            go.transform.SetParent(TeamContainer);
            go.transform.localPosition.Set(go.transform.localPosition.x, (i + 1) * 40, go.transform.localPosition.z);
            go.CurrentPlayer = GameController.Instance.Players[i];

            Teams.Add(go);
        }
    }

    public void OnNewGameClick()
    {
        Debug.Log("OnNewGameClick");
        InitialMenu.SetActive(false);
        GameController.Instance = null;
        PlayerSetup.SetActive(true);
        OnAddNewPlayerClick();
        OnAddNewPlayerClick();
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
    public void OnDrawMapClick()
    {
        Helpers.DrawMap();

    }
    public void OnStartGameClick()
    {

        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        //Debug.Log(TeamCount.text);
    }
    public void Awake()
    {
        AppController.Instance.Init();
    }
}
