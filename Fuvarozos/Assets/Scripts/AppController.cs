using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController
{
    private static AppController instance;

    private AppController()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    public static AppController Instance
    {
        get { return instance ?? (instance = new AppController()); }
    }

    private void OnActiveSceneChanged(Scene beforeScene, Scene afterScene)
    {
        if (afterScene.name == "GameScene")
        {
            Helpers.DrawMap();
        }
    }
}