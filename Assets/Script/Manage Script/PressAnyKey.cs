using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
{

	
	void Start ()
    {
	
	}
	
	
	void Update ()
    {
	    if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }        
	}
}
