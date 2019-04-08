using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController
{
    private static AppController instance;

    public int PlayerCount { get { return playerCount; } set { var x = 0;
            int.TryParse(value, out x) } };
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
}
