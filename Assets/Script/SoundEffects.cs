using UnityEngine;
using System.Collections;


public class SoundEffects : MonoBehaviour
{
    public static SoundEffects Instance;

    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    

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

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}