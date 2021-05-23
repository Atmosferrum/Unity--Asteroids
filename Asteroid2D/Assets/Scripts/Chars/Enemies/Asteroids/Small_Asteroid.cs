using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small_Asteroid : Asteroid
{
    /// <summary>
    /// НАНЕСЕНИЕ урона Мальенькому Астероиду
    /// </summary>
    public override void TakeDamage() 
    {
        AudioManager.Instance.AsteroidDied(gameObject.tag);
        GameManager.Instance.uiManager.SetScore(Constants.socre[2]);
        gameObject.SetActive(false);
    }
}
