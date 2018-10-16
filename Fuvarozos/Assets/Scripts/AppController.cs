using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController
{
    private static AppController instance;
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
