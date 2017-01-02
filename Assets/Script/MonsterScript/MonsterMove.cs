using UnityEngine;
using System.Collections;

public class MonsterMove : MonoBehaviour
{
    public Vector2 Speed = new Vector2(10,10);
    public Vector2 Direction = new Vector2(-1, 0);
    private Vector2 Movement;
    public Rigidbody2D rb2d;
    [SerializeField]GameObject PlayerCharacter;
    [SerializeField]GameObject enemy;
    [SerializeField]int hp;
    [SerializeField]ParticleSystem smokeEffect;
    [SerializeField]ParticleSystem fireEffect;
    public bool isEnemy = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }
	
	void Update()
    {
        Direction = (PlayerCharacter.transform.position - transform.position).normalized;
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);

    }

    void FixedUpdate()
    {
       rb2d.velocity = Movement;
    }
    ////////////////////SHOOT ON ENEMY////////////////////////
    void OnTriggerEnter2D(Collider2D collider)
    {

        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {

            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;

                
                Destroy(shot.gameObject);

                if (hp <= 0)
                {
                    Instantiate(fireEffect,gameObject.transform.position,gameObject.transform.rotation);
                    Instantiate(smokeEffect,gameObject.transform.position,gameObject.transform.rotation);
                    SoundEffects.Instance.EnemyDied();
                    Destroy(gameObject);
                }
            }
        }
    }
}
