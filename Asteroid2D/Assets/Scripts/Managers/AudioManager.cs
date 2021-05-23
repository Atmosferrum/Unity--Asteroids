using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    AudioSource thrustAS;
    [SerializeField]
    AudioSource gunAS;
    [SerializeField]
    AudioSource asteroidsAS;
    [SerializeField]
    AudioClip[] asteroidDiedSFX;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetThrust(bool set)
    {
        if (set)
            thrustAS.Play();
        else if (!set)
            thrustAS.Stop();
    }

    public void Shoot() => gunAS.Play();

    public void AsteroidDied(string asteroidTag)
    {
        if (asteroidTag == Constants.bigAsteroid)
            asteroidsAS.PlayOneShot(asteroidDiedSFX[0]);
        else if (asteroidTag == Constants.mediumAsteroid)
            asteroidsAS.PlayOneShot(asteroidDiedSFX[1]);
        else if (asteroidTag == Constants.smallAsteroid)
            asteroidsAS.PlayOneShot(asteroidDiedSFX[2]);
               
    }
}
