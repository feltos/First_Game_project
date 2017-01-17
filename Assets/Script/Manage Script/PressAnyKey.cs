using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
{
    float timer = 1f;
	
	void Start ()
    {
	
	}
	
	
	void Update ()
    {
        timer -= Time.deltaTime;
	    if(Input.anyKeyDown && timer <= 0)
        {
            SceneManager.LoadScene(0);
        }        
	}
}
