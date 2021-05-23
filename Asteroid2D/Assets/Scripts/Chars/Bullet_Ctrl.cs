using UnityEngine;

public class Bullet_Ctrl : MonoBehaviour
{
    float force = 350;

    void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * force); // "Выстрел" пули при активации объекта
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        // Отключение пули если вышла за пределы экрана
        if (trigger.gameObject.name == Constants.borderName)
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        // Отключение пули если вышла за пределы экрана
        if (trigger.GetComponent<ITakeDamage>() != null)
        {
            trigger.GetComponent<ITakeDamage>().TakeDamage();
            gameObject.SetActive(false);
        }
    }
}
