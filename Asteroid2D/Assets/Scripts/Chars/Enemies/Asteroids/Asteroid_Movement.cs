using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Movement : MonoBehaviour
{
    float[] asteroidSpeed = { 10, 7.5f, 5, 2.5f }; // Скорость Астероидов
    float[] randomDirection = { -1, -2, +1, +2 }; // Отклонение при получении направления

    private void OnEnable()
    {        
        GetComponent<Rigidbody2D>().AddForce(Direction() * Force()); // "Выстрел" при активации объекта
    }

    /// <summary>
    /// ПОЛУЧЕНИЕ велечины силы
    /// </summary>
    /// <returns></returns>
    private float Force()
    {
        return gameObject.name == Constants.smallAsteroid ? asteroidSpeed[0]
                            : (gameObject.name == Constants.mediumAsteroid ? asteroidSpeed[1]
                            : (gameObject.name == Constants.bigAsteroid ? asteroidSpeed[3]
                            : asteroidSpeed[4]));
    }

    /// <summary>
    /// ПОЛУЧЕНИЕ направления изначального движения
    /// </summary>
    /// <returns></returns>
    private Vector2 Direction()
    {
        return new Vector2(GameManager.Instance.transform.position.x + randomDirection[Random.Range(0, randomDirection.Length - 1)] - transform.position.x,
                           GameManager.Instance.transform.position.y + randomDirection[Random.Range(0, randomDirection.Length - 1)] - transform.position.y);
    }
}
