using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D trigger)
    {
        // Если вышли за пределы Трггера Границы, смена позиции
        if(trigger.gameObject.name == Constants.borderName)
            ChangePosition(); // Проверка позиции объекта в данный момент
    }

    /// <summary>
    /// Смена позиции
    /// </summary>
    private void ChangePosition() => transform.position = GameManager.Instance.border.Teleport(transform.position);
}
