using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreTxt;
    [SerializeField]
    GameObject[] hp;
    [SerializeField]
    GameObject endScreen;


    private int score = 0;

    /// <summary>
    /// ВЫВОД очков
    /// </summary>
    /// <param name="score"></param>
    public void SetScore(int score)
    {
        this.score += score;
        scoreTxt.text = $" {this.score}";
    }

    /// <summary>
    /// УМЕНЬШЕНИЕ жизней
    /// </summary>
    public void SetHP(int index)
    {
        hp[index].SetActive(false);
        
        if (index <= 0)
        {
            endScreen.SetActive(true);
            GameManager.Instance.Pause();

        }
    }
}
