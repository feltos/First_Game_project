﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour
{
    [SerializeField]
    Button[] menuButtons;
   

  
    

    public void SwitchScene(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}



