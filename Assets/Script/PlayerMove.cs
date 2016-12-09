using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    private SpriteRenderer PlayerSprite;
    public Rigidbody2D rb2d;
    [SerializeField] float speed;
    [SerializeField] float jump;

    private void awake()
    {
        
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PlayerSprite = GetComponent<SpriteRenderer>();

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
            if(Input.GetKey(KeyCode.D))
            {
                PlayerSprite.flipX = false;
            }
        }
        ///////////////////////JUMP/////////////////////////////
        
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = rb2d.velocity + Vector2.up * jump;
        }
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb2d.velocity.y);
    }

}