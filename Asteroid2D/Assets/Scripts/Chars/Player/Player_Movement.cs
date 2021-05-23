using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float thrustSpeed = 1f; // Скорость перемещения
    private float rotationSpeed = -180f; // Скорость вращения
    private float maxSpeed = 2f; // Максимальная скорость
    private Rigidbody2D playerRB2D; // Компонент RigidBody2D Игрока

    private void Start()
    {
        playerRB2D = GetComponent<Rigidbody2D>(); // Получение Компонента RigidBody2D Игрока
    }

    private void Update()
    {
        // Если Вертикальная ось в действии, Ускорять корабль
        if (Input.GetAxis("Vertical") != 0)
            Thrust();

        // Если Горизонтальная ось в дейсствии, Вращать корабль
        if (Input.GetAxis("Horizontal") != 0)
            RotateShip();        
    }

    /// <summary>
    /// УСКОРЕНИЕ коробля
    /// </summary>
    private void Thrust()
    {
        playerRB2D.AddForce(transform.up * thrustSpeed * Input.GetAxis("Vertical"));
        playerRB2D.velocity = new Vector2(Mathf.Clamp(playerRB2D.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(playerRB2D.velocity.y, -maxSpeed, maxSpeed));
    }

    /// <summary>
    /// ПОВОРОТ коробля
    /// </summary>
    private void RotateShip() => transform.Rotate(0, 0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
}
