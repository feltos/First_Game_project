using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour
{
    [SerializeField]
    Button[] menuButtons;
    float timer = 1.20F;
    [SerializeField]Animator Teleportation;
    [SerializeField]SpriteRenderer Player;

    bool isCountdownStarted = false;
    string buttonName;

    public void SwitchScene(string sceneName)
    {
        Instantiate(Teleportation, Player.transform.position, Player.transform.rotation);
        Player.color = new Color(1, 1, 1, 0);
        
        isCountdownStarted = true;
        buttonName = sceneName;
    }

    void Update()
    {
        if(isCountdownStarted == true)
        {
            timer -= Time.deltaTime;
            
           
        }

        if (timer < 0)
        {
            SceneManager.LoadScene(buttonName);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}



