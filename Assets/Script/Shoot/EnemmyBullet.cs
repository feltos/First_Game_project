using UnityEngine;
using System.Collections;

public class EnemmyBullet : MonoBehaviour {

    public int damage = 1;
    [SerializeField]Vector2 Speed;
    public Vector2 Move;
    public Rigidbody2D rb2d;
    private GameObject Player;
    private bool shoot = false;

    void Start()
    {
        Player = GameObject.Find("Player");
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    void Update()
    {
        Vector2 Direction = (Player.transform.position - transform.position).normalized;
        Move = new Vector2(
               Speed.x * Direction.x,
               Speed.y * Direction.y);
        if (!shoot)
        {
            rb2d.velocity = Move;
            shoot = true;
        }

    }

    void FixedUpdate()
    {
        
    }
}
