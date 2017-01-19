using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossScript : MonoBehaviour
{
    [SerializeField]float Health;
    [SerializeField]Transform BossBullet;
    private float ShootCooldown = 0.35f;
    private float ShootTimer;
    private GameObject Player;
    [SerializeField]GameObject BossGun;
    public bool isEnemy = true;
    [SerializeField]Slider BossHealthSlider;
    [SerializeField]BossLevelStart BossStart;
    bool dying = false;
    float Timer = 4f;
    [SerializeField]ParticleSystem Explosion;
    [SerializeField]float ExplosionTime = 0.2f;
    [SerializeField]Transform[] ExplosionPoints;
    [SerializeField]Collider2D BossCollider;
    [SerializeField]GameObject TheCube;
    [SerializeField]SpriteRenderer fadeRenderer;
    [SerializeField]Sprite BossDamageState;
    [SerializeField]Sprite BossNormalState;
    float FadeOutPeriod = 2.0f;
    float FadeInPeriod = 1.8f;
    float CubeSpawn = 0.5f;
    float currentBlinkTimer;
    [SerializeField]float BlinkTimer = 0.1f;




    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void Start()
    {
        currentBlinkTimer = BlinkTimer;
    }


    void Update()
    {
        ShootTimer += Time.deltaTime;
        BlinkManager();
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
                

                if (Timer <= FadeInPeriod)
                {
                    fadeRenderer.color = new Color(1.0f, 1.0f, 1.0f,
                    fadeRenderer.color.a - 1.0f / FadeInPeriod * Time.deltaTime);
                    Destroy(GetComponent<SpriteRenderer>());

                }

                else
                {
                    fadeRenderer.color = new Color(1.0f, 1.0f, 1.0f,
                    fadeRenderer.color.a + 1.0f / FadeOutPeriod * Time.deltaTime);
                    
                    if (fadeRenderer.color.a > 1.0)
                    {
                        
                        fadeRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    }
                }
               
                
                if (Timer <= 0)
                {
                    dying = false;
                    Destroy(gameObject);
                    Instantiate(TheCube, BossGun.transform.position, BossGun.transform.rotation);

                }
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
                GetComponent<SpriteRenderer>().sprite = BossDamageState;

                Destroy(shot.gameObject);
            }
            if (Health <= 0)
            {
                dying = true;
                InvokeRepeating("BossDying", ExplosionTime, ExplosionTime);
                Destroy(BossHealthSlider.gameObject);
                BossCollider.enabled = false;
               

            }
        }
    }

    void BossDying()
    {
        if (dying && Timer > FadeInPeriod)
        {
            int ExplosionPointsIndex = Random.Range(0, ExplosionPoints.Length);
            Instantiate(Explosion, ExplosionPoints[ExplosionPointsIndex].position, ExplosionPoints[ExplosionPointsIndex].rotation);
            SoundEffects.Instance.EnemyDied();
        }
        
    }
    void BlinkManager()
    {
        if (!dying)
        {
            if (GetComponent<SpriteRenderer>().sprite == BossDamageState)
            {
                currentBlinkTimer -= Time.deltaTime;
                if (currentBlinkTimer <= 0)
                {
                    GetComponent<SpriteRenderer>().sprite = BossNormalState;
                    currentBlinkTimer = BlinkTimer;
                }
            }
        }

    
    }
}


