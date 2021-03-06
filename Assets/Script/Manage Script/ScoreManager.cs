﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    Text ScoreText;
    [SerializeField]GameObject player;
    [SerializeField]Animator Teleportation;
    float timer = 1f;
    bool Teleporting = false;
    [SerializeField]Rigidbody2D PlayerRb2d;
    float ScoreToSwitch = 300;
    
 
    void Awake()
    {
        ScoreText = GetComponent<Text>();
        Score = 0;
        player = GameObject.Find("Player");
        
    }

    void Start ()
    {
	    
	}
	
	void Update ()
    {
        
        ScoreText.text = "Score : " + Score;
        if(Score >= ScoreToSwitch && !Teleporting)
        {
            
            Teleporting = true;
            Instantiate(Teleportation, player.transform.position, player.transform.rotation);
            SoundEffects.Instance.Teleport();
            PlayerRb2d.gravityScale = 0;
            PlayerRb2d.velocity = Vector3.zero;
            player.GetComponent<PlayerMove>().Disappear();
            SoundEffects.Instance.Teleport();
        }
        if (Teleporting)
        {
            
            timer -= Time.deltaTime;
            if(timer < 0.0f)
            {
                Score = 0;
                SceneManager.LoadScene("BossBattle");
            }
        }
           
    }
}
