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
    float Timer = 4f;
    [SerializeField]ParticleSystem Explosion;
    [SerializeField]float ExplosionTime = 0.2f;
    [SerializeField]Transform[] ExplosionPoints;
    [SerializeField]Collider2D BossCollider;
    [SerializeField]GameObject TheCube;





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
                
                if (Timer <= 0)
                {
                    Instantiate(TheCube, BossGun.transform.position, BossGun.transform.rotation);
                    Destroy(gameObject);
                    dying = false;
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
        if (dying)
        {
            int ExplosionPointsIndex = Random.Range(0, ExplosionPoints.Length);
            Instantiate(Explosion, ExplosionPoints[ExplosionPointsIndex].position, ExplosionPoints[ExplosionPointsIndex].rotation);
            SoundEffects.Instance.EnemyDied();
        }
        
    }
}


