using UnityEngine;
using System.Collections;


public class SoundEffects : MonoBehaviour
{
    public static SoundEffects Instance;

    [SerializeField]AudioClip DamageSound;
    [SerializeField]AudioClip playerShotSound;
    [SerializeField]AudioClip EnemyExplode;
    [SerializeField]AudioClip MenuMusic;
    [SerializeField]AudioClip bossShoot;
    

    
    
    

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Multiple instances of SoundEffects!");
        }
        Instance = this;
     }

    public void DamageHeroSound()
    {
        MakeSound(DamageSound);
    }

    public void PlayerShotSound()
    {
        MakeSound(playerShotSound);
    }

    public void EnemyDied()
    {
        MakeSound(EnemyExplode);
    }

    public void BossWeapon()
    {
        MakeSound(bossShoot);
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}