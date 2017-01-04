using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        Score = 0;
    }

    void Start ()
    {
	    
	}
	
	void Update ()
    {
        text.text = "Score : " + Score;
    }
}
