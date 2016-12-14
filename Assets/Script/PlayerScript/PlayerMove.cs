using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] SpriteRenderer PlayerSprite;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField]float speed;
    [SerializeField]float jump;
    private LayerMask GroundCheck;
    private bool IsGrounded;
    
    

    private void awake()
    {

    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PlayerSprite = GetComponent<SpriteRenderer>();
        Cursor.visible = true;

    }

    void Update()
    {
        /////////////////////FLIP THE PLAYER SPRITE/////////////////////
        if (PlayerSprite != null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                PlayerSprite.flipX = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                PlayerSprite.flipX = false;
            }
        }
        ///////////////////////JUMP/////////////////////////////
        IsGrounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump")&& IsGrounded)
        {
            rb2d.velocity = rb2d.velocity + Vector2.up * jump;
        }
        ///////////////////FIRE/////////////////////////////
        bool shoot = Input.GetButton ("Fire1");
        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
               
                weapon.Attack(false);
            }
        }
    }
        void FixedUpdate()
        {
            rb2d.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb2d.velocity.y);
        }

    
}