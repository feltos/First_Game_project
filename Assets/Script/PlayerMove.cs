using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    private SpriteRenderer PlayerSprite;
    public Rigidbody2D rb2d;
    [SerializeField]float speed;
    [SerializeField]float jump;
    float GroundDistance;
    private bool IsGrounded;
    public GameObject Bullet;

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
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = rb2d.velocity + Vector2.up * jump;
        }
        ///////////////////FIRE/////////////////////////////
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Instantiate(Bullet, transform.position, transform.rotation);

        }
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb2d.velocity.y);
    }

}