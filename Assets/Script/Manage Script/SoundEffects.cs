using UnityEngine;
using System.Collections;


public class SoundEffects : MonoBehaviour
{
    public static SoundEffects Instance;

    public AudioClip DamageSound;
    public AudioClip playerShotSound;
    public AudioClip EnemyExplode;
    public AudioClip MenuMusic;
    
    

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffects!");
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

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}