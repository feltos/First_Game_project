using UnityEngine;
using System.Collections;

public class MonsterMove : MonoBehaviour
{
    public Vector2 Speed = new Vector2(10,10);
    public Vector2 Direction = new Vector2(-1, 0);
    private Vector2 Movement;
    public Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	void Update()
    {
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);

    }

    void FixedUpdate()
    {
       rb2d.velocity = Movement;
    }
}
