using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{
    double Health = 1;
    [SerializeField]
    Transform BossBullet;
    private float ShootCooldown = 0.25f;
    private float timer;
    private GameObject Player;
    [SerializeField]GameObject BossGun;
    public bool isEnemy = true;



    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void Start()
    {

    }


    void Update()
    {
        timer += Time.deltaTime;
        if (Player != null && timer >= ShootCooldown)
        {

            Instantiate(BossBullet, BossGun.transform.position, BossGun.transform.rotation);
            timer = 0f;
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
                Destroy(shot.gameObject);
            }
            if (Health <= 0)
            {
              
                Destroy(gameObject);
            }
        }
    }
}

        