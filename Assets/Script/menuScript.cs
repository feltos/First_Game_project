using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour
{
    public AudioClip ButtonClick;
    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeight = 60;
        
        // Affiche un bouton pour démarrer la partie
        if (
          GUI.Button(
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Start!"
          )
        )
        {
            
            Application.LoadLevel("Main");
        }
    }
 
}



