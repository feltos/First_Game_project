using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectifTextScript : MonoBehaviour
{

    private float timer = 3f;

	void Start ()
    {
       
	}
	
	
	void Update ()
    {
        timer -= Time.deltaTime; 

        if (timer <= 0)
        {
            gameObject.SetActive(false);
            
        }
        
	}
}
