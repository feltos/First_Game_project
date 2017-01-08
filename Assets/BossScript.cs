using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{
    double Health = 500;
    [SerializeField]Transform BossBullet;
    private float ShootCooldown = 0.1f;
    private bool CanFire = false;


    void Awake()
    {

    }

    void Start()
    {
        ShootCooldown = 0f;
    }


    void Update()
    {
        if (ShootCooldown > 0)
        {
            ShootCooldown -= Time.deltaTime;
        }
    }

    void Attack(bool isEnemy)
    {
        var shotTransform = Instantiate(BossBullet) as Transform;
        shotTransform.position = transform.position;

        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            shot.isEnemyShot = isEnemy;
        }
    }
    void CanAttack()
    {
        if (ShootCooldown > Time.deltaTime)
        {
            CanFire = true;
        }

    }
}
