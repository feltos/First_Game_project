using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossScript : MonoBehaviour
{
    [SerializeField]
    float Health;
    [SerializeField]
    Transform BossBullet;
    private float ShootCooldown = 0.35f;
    private float ShootTimer;
    private GameObject Player;
    [SerializeField]
    GameObject BossGun;
    public bool isEnemy = true;
    [SerializeField]
    Slider BossHealthSlider;
    [SerializeField]BossLevelStart BossStart;
    bool dying = false;
    float Timer = 10f;
    [SerializeField]Animator Explosion;



    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void Start()
    {

    }


    void Update()
    {
        ShootTimer += Time.deltaTime;
        if (Player != null && ShootTimer >= ShootCooldown)
        {
            
            if(!BossStart.teleporting && !dying)
            {
                SoundEffects.Instance.BossWeapon();
                Instantiate(BossBullet, BossGun.transform.position, BossGun.transform.rotation);
                ShootTimer = 0f;
            }
            if(dying)
            {
               Timer -= Time.deltaTime;
               Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
            }
        }


    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {

            if (shot.isEnemyShot != isEnemy)
            {
                Health -= shot.damage;
                BossHealthSlider.value = Health;
                Destroy(shot.gameObject);
            }
            if (Health <= 0)
            {
                dying = true;
                Destroy(BossHealthSlider.gameObject);
                if (Timer <= 0)
                {
                    Destroy(gameObject);
                }
                
               


            }
        }
    }
}


