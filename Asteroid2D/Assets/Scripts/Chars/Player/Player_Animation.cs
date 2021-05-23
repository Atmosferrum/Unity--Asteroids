using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    [SerializeField]
    GameObject thrust; // Объект выхлопа коробля

    private void FixedUpdate()
    {
        SetThrust(); // Запуск переключения выхлопа коробля
    }

    /// <summary>
    /// ПЕРЕКЛЮЧЕНИЕ выхлопа коробля
    /// </summary>
    public void SetThrust()
    {
        if (Input.GetAxis(Constants.vertical) != 0 && !thrust.activeInHierarchy)
        {
            thrust.SetActive(true);
            AudioManager.Instance.SetThrust(true);
        }
        else if(Input.GetAxis(Constants.vertical) == 0 && thrust.activeInHierarchy)
        {
            thrust.SetActive(false);
            AudioManager.Instance.SetThrust(false);
        }
    }
}
