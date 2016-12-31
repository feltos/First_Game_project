using UnityEngine;
using System.Collections;


public class SoundEffects : MonoBehaviour
{
    public static SoundEffects Instance;

    public AudioClip explosionSound;
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

    public void ExplosionSound()
    {
        MakeSound(explosionSound);
    }

    public void PlayerShotSound()
    {
        MakeSound(playerShotSound);
    }

    public void EnemyDied()
    {
        MakeSound(EnemyExplode);
    }

    public void Menu()
    {
        MakeSound(MenuMusic);
    }
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}