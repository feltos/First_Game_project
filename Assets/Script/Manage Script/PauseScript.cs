using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField]GameObject PauseUI;
    private bool Paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            Paused = !Paused;
        }
        
        if(Paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(!Paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        
    }

    public void Reprendre()
    {
        Paused = false;
        
    }

    public void Menu()
    {
        SceneManager.LoadScene("menu");
        Paused = false;

    }

    public void Quitter()
    {
        Application.Quit();
    }
}
