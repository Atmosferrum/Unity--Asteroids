using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    [SerializeField]
    Transform gun;


    void Update()
    {
        // При нажатии на ЛКМ стрелять
        if (Input.GetMouseButtonDown(0))
            Shoot();           
    }

    /// <summary>
    /// СТРЕЛЯТЬ 
    /// </summary>
    void Shoot()
    {
        GameObject bullet;
        bullet = Pooler.Instance.GetPooledGO(Constants.bulletTag);
        bullet.transform.position = gun.position;
        bullet.transform.rotation = gun.rotation;
        bullet.SetActive(true);
        AudioManager.Instance.Shoot();
    }
}
