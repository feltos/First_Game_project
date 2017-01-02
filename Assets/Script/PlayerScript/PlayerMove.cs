using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]SpriteRenderer PlayerSprite;
    [SerializeField]Rigidbody2D rb2d;
    [SerializeField]float speed;
    [SerializeField]float jump;
    [SerializeField]int health;
    [SerializeField]GameObject GroundCheck;
    [SerializeField]bool IsTurnedRight = true;
    float horizontal = 0.0f;
    public Transform BulletPrefab;
    [SerializeField]float shootingRate;
    public bool IsGrounded;
    const float WalkDeadZone = 0.1f;
    [SerializeField]ParticleSystem smokeEffect;
    [SerializeField]ParticleSystem fireEffect;



    private void awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PlayerSprite = GetComponent<SpriteRenderer>();
        Cursor.visible = true;
    }

    void Start()
    {



    }

    void Update()
    {

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

        if (Input.GetMouseButtonDown(0))
            Attack(false);

    }
    void FixedUpdate()
    {

    }

    public void Attack(bool isEnemy)
    {
        SoundEffects.Instance.PlayerShotSound();
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = mousePosition - transform.position;

        var shotTransform = Instantiate(BulletPrefab) as Transform;


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

        //m_SpriteRenderer.flipX = !m_SpriteRenderer.flipX;

        IsTurnedRight = !IsTurnedRight;
    }
     void OnTriggerEnter2D(Collider2D collider)
     {
        
        if(collider.gameObject.tag == "enemy")
        {
            health -= 1;
        }
        if (health <= 0)
        {

         transform.Rotate(0, 0, 0);
         Instantiate(fireEffect, gameObject.transform.position, gameObject.transform.rotation);
         Instantiate(smokeEffect, gameObject.transform.position, gameObject.transform.rotation);
         Debug.Log("prout");
      //////NEED TO FIX THE DESTROY CAMERA PROBLEM !!!!!!!!! ///////////
        Application.LoadLevel("GameOver");
        }
      }
}
