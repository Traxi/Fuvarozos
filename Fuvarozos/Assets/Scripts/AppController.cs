using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController
{
    private static AppController instance;

    private AppController()
    {
        SceneManagement.activeSceneChanged += OnActiveSceneChanged;
    }

    public string PlayerCount
    {
        get { return playerCount.ToString(); }
        set { int.TryParse(value, out playerCount); }
    }

    private int playerCount;

    public static AppController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AppController();
            }

            return instance;
        }
    }

    private void OnActiveSceneChanged(Scene beforeScene, Scene afterScene)
    {
        if (afterScene.name == "GameScene")
        {
            Helpers.DrawMap();
        }
    }
}