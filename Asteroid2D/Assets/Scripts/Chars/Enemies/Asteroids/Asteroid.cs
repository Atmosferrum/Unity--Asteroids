using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Asteroid : MonoBehaviour, ITakeDamage
{
    public abstract void TakeDamage();

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == Constants.playerTag)
        {
            trigger.gameObject.GetComponent<ITakeDamage>().TakeDamage();
            TakeDamage();
        }
    }

}
