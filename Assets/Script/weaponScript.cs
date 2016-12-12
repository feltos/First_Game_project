using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
 
    public Transform Bullet;
    /// Temps de rechargement entre deux tirs
    public float shootingRate = 0.25f;

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
            var shotTransform = Instantiate(Bullet) as Transform;

            // Position
            shotTransform.position = transform.position;

            // Propriétés du script
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // On saisit la direction pour le mouvement
            MoveShot move = shotTransform.gameObject.GetComponent<MoveShot>();
            if (move != null)
            {
                move.Direction = this.transform.right; // ici la droite sera le devant de notre objet
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

