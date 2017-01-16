using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonsterMove : MonoBehaviour
{
    private int Score;
    public Vector2 Speed = new Vector2(10,10);
    public Vector2 Direction = new Vector2(-1, 0);
    private Vector2 Movement;
    public Rigidbody2D rb2d;
    [SerializeField]GameObject enemy;
    private int KillPoints = 10;
    [SerializeField]int hp;
    [SerializeField]ParticleSystem smokeEffect;
    public bool isEnemy = true;
    Transform Player;
    private GameObject Target;
    float ScoreToSwitch = 300;
    
    void Awake()
    {
       Target = GameObject.Find("Player");
    } 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }
	
	void Update()
    {

        Direction = (Target.transform.position - transform.position).normalized;
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);

        if (ScoreManager.Score >= ScoreToSwitch)
        {
            Destroy(gameObject);
        }

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
                    Instantiate(smokeEffect, transform.position, transform.rotation);
                    SoundEffects.Instance.EnemyDied();
                    Destroy(gameObject);
                    ScoreManager.Score += KillPoints;
                    
                }
            }
        }
    }
}
