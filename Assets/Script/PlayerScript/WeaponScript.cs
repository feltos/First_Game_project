using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
 
    public Transform BulletPrefab;
    [SerializeField] SpriteRenderer PlayerSprite;
    /// Temps de rechargement entre deux tirs
    [SerializeField] float shootingRate = 0.25f;

    //--------------------------------
    // 2 - Rechargement
    //--------------------------------

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    //--------------------------------
    // 3 - Tirer depuis un autre script
    //--------------------------------

    /// <summary>
    /// Création d'un projectile si possible
    /// </summary>
    public void Attack(bool isEnemy)
    {
        
    
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Création d'un objet copie du prefab
            var shotTransform = Instantiate(BulletPrefab);

            // Position
            shotTransform.position = transform.position;

            // On saisit la direction pour le mouvement
            
            MoveShot move = shotTransform.gameObject.GetComponent<MoveShot>();
            if (move != null)
               
            {
                if (!PlayerSprite.flipX)
                {
                    move.Direction = Vector2.right; // ici la droite sera le devant de notre objet
                }
                if(PlayerSprite.flipX)
                {
                    move.Direction = Vector2.left;
                }
            }
        }
    }

     public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}

