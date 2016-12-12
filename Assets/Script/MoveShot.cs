using UnityEngine;
using System.Collections;

public class MoveShot : MonoBehaviour
{
    public Vector2 Speed = new Vector2(10, 10);
    public Vector2 Direction = new Vector2(-1, 0);
    public Vector2 Move;
    public Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);

    }

    void FixedUpdate()
    {
        rb2d.velocity = Move;
    }
}
