using UnityEngine;
using System.Collections;

public class BossLevelStart : MonoBehaviour
{
    float timer = 4.75f;
    [SerializeField]Animator teleportation;
    [SerializeField]GameObject Player;
    public bool teleporting = true;
    [SerializeField]Rigidbody2D PlayerRb2d;
    bool shakeReady = true;
    [SerializeField]ScreenShaker CameraShake;
    [SerializeField]SoundEffects soundEffects;
    [SerializeField]AudioSource BossScream;
    
    

    void Start ()
    {
        
        Instantiate(teleportation, Player.transform.position, Player.transform.rotation);
        PlayerRb2d.gravityScale = 0;
        PlayerRb2d.velocity = Vector3.zero;
    }


    void Update()
    {



        if (teleporting)
        {
            timer -= Time.deltaTime;
            if(timer < 4.3)
            {
                Player.GetComponent<PlayerMove>().Appear();
            }

            if (timer < 3 && shakeReady)
            {
                CameraShake.initShake();
                BossScream.Play();
                shakeReady = false;

            }
            if (timer < 0)
            {
                soundEffects.GetComponent<AudioSource>().Play();
                teleporting = false;
                PlayerRb2d.gravityScale = 2;
            }

        }
    }
    
}

