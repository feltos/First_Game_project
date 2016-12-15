using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] SpriteRenderer PlayerSprite;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField]float speed;
    [SerializeField]float jump;
    [SerializeField] GameObject GroundCheck;
    [SerializeField] bool IsTurnedRight = true;
    float horizontal = 0.0f;
    public Transform BulletPrefab;
    [SerializeField]float shootingRate = 0.25f;
    public bool IsGrounded;


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
        rb2d.velocity = new Vector2(speed *horizontal, rb2d.velocity.y);
    }

    public void Attack(bool isEnemy)
    {
        
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = mousePosition - transform.position;

        var shotTransform = Instantiate(BulletPrefab) as Transform;

            
        shotTransform.position = transform.position;

            
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            shot.isEnemyShot = isEnemy;
        }

            
        MoveShot move = shotTransform.gameObject.GetComponent<MoveShot>();
        if (move != null)
        {
            move.Direction = direction.normalized;
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

}
