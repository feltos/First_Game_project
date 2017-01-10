using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    Text ScoreText;
    
    void Awake()
    {
        ScoreText = GetComponent<Text>();
        Score = 0;
    }

    void Start ()
    {
	    
	}
	
	void Update ()
    {
        ScoreText.text = "Score : " + Score;
        if(Score >= 300)
        {
            Application.LoadLevel("BossBattle");
        }
    }
}
