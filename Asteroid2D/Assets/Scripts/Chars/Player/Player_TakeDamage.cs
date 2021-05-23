using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TakeDamage : MonoBehaviour, ITakeDamage, IHaveHP
{
    private int hp; // Жизни
    public int HP { get { return hp; } set { hp = value; } }

    private void Start()
    {
        HP = Constants.hpCount;
    }

    /// <summary>
    /// УМЕНЬШЕНИЕ жизней
    /// </summary>
    public void TakeDamage()
    {
        --hp;
        if (hp >= 0)
            GameManager.Instance.uiManager.SetHP(hp);
    }

}
