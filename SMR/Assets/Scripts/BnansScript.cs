using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BnansScript : MonoBehaviour
{
    public int money;
    public int HowMuchAMin = 150;

    public void time()
    {

    }

    void Start()
    {
        time();
        if (PlayerPrefs.GetInt("moneys") == 0)
        {
            PlayerPrefs.SetInt("moneys", 1);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
