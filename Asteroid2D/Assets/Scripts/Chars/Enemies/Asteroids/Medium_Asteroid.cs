using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium_Asteroid :  Asteroid
{
    int asteroidQwty = 2; // Кол-во астероидов для Появления после смерти

    /// <summary>
    ///  НАНЕСЕНИЕ урона Среднему Астероиду
    /// </summary>
    public override void TakeDamage()
    {
        for (int i = asteroidQwty ; i > 0; i--)
        {
            GameObject asteroid = Pooler.Instance.GetPooledGO(Constants.smallAsteroid);
            asteroid.transform.position = transform.position;
            asteroid.SetActive(true);            
        }
        AudioManager.Instance.AsteroidDied(gameObject.tag);
        GameManager.Instance.uiManager.SetScore(Constants.socre[1]);
        gameObject.SetActive(false);
    }
}
