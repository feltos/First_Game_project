using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemyShot = false;
    [SerializeField]Vector2 Speed;
    private Vector2 Move;
    public Vector2 Direction = new Vector2(-1, 0);
    [SerializeField] Rigidbody2D rb2d;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
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
