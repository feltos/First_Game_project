﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using InControl;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    SpriteRenderer PlayerSprite;
    [SerializeField]Rigidbody2D rb2d;
    [SerializeField]float speed;
    [SerializeField]float jump;
    [SerializeField] int StartingHealth;
    [SerializeField] int CurrentHealth;
    [SerializeField]Slider HealthSlider;
    [SerializeField]Image DamageImage;
    private float FlashSpeed = 5f;
    [SerializeField]Color FlashColor = new Color(1f, 0f, 0f, 0.1f);
    float timeBetweenDamage;
    float PeriodBetweenShoot = 0.2f;
    float timeBetweenShoot = 0.2f;
    private float PeriodBetweenDamage = 3f;
    [SerializeField]GameObject GroundCheck;
    [SerializeField]bool IsTurnedRight = true;
    float horizontal = 0.0f;
    [SerializeField]Transform BulletPrefab;
    public bool IsGrounded;
    const float WalkDeadZone = 0.01f;
    [SerializeField]ParticleSystem smokeEffect;
    [SerializeField]GameObject PlayerGun;
    [SerializeField]BossLevelStart BossStart;
    float ScoreToSwitch = 300;

    Vector2 direction;



    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PlayerSprite = GetComponent<SpriteRenderer>();
        Cursor.visible = true;
        CurrentHealth = StartingHealth;
        
        
    }

    void Start()
    {



    }

    void Update()
    {
        if (ScoreManager.Score < ScoreToSwitch && (BossStart == null || !BossStart.teleporting))
        {
            timeBetweenDamage += Time.deltaTime;
            timeBetweenShoot += Time.deltaTime;
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, FlashSpeed * Time.deltaTime);
            horizontal = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(speed * horizontal, rb2d.velocity.y);
            /////////////////////FLIP THE PLAYER SPRITE/////////////////////
            if (horizontal > 0 && !IsTurnedRight)
            {
                Flip();
            }
            else if (horizontal < 0 && IsTurnedRight)
            {
                Flip();
            }
            ///////////////////////JUMP/////////////////////////////
            IsGrounded = Physics2D.Linecast(transform.position, GroundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));


            if (Input.GetButtonDown("Jump") && IsGrounded)
            {
                rb2d.velocity = rb2d.velocity + Vector2.up * jump;
            }

            ///////////////////FIRE/////////////////////////////
                Attack(false);
        }
    }

    void FixedUpdate()
    {

    }

    public void Attack(bool isEnemy)
    {

        var inputDevice = (InputManager.Devices.Count > 0) ? InputManager.Devices[0] : null;

        if (inputDevice!= null && timeBetweenShoot > PeriodBetweenShoot &&
            (Mathf.Abs(inputDevice.RightStick.X) > WalkDeadZone || Mathf.Abs(inputDevice.RightStick.Y) > WalkDeadZone))
        {
            direction = new Vector3(inputDevice.RightStick.X, inputDevice.RightStick.Y);
            timeBetweenShoot = 0;
          
            

        }
        else if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            direction = mousePosition - transform.position;
        }
        else
        {
            return;
        }
        
           
        
        
        SoundEffects.Instance.PlayerShotSound();
        var shotTransform = Instantiate(BulletPrefab,PlayerGun.transform.position,PlayerGun.transform.rotation) as Transform;


        shotTransform.position = transform.position;


        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            shot.isEnemyShot = isEnemy;
            shot.Direction = direction.normalized;
        }
    }



    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        IsTurnedRight = !IsTurnedRight;
    }
     void OnTriggerEnter2D(Collider2D collider)
     {
        
        if(collider.gameObject.tag == "enemy" && timeBetweenDamage >= PeriodBetweenDamage)
        {
            DamageImage.color = FlashColor;
            CurrentHealth -= 1;
            HealthSlider.value = CurrentHealth;
            SoundEffects.Instance.DamageHeroSound();
            timeBetweenDamage = 0f;
            
        }

        if (CurrentHealth <= 0)
        {
        
         transform.Rotate(0, 0, 0);
         SceneManager.LoadScene("GameOver");
        }
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "TheCube")
        {
            SceneManager.LoadScene("Victory");
        }
            

    }

    public void Disappear()
    {
        
        PlayerSprite.color = new Color(1, 1, 1, 0);
        
    }

    public void Appear()
    {

        PlayerSprite.color = new Color(1, 1, 1, 1);

    }

}
