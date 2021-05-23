using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Manager")]
    public static GameManager Instance;

    [Header("Game")]
    private bool pause = false;

    [Header("Camera")]
    public Camera mainCam;

    [Header("UI")]
    public UIManager uiManager;

    [Header("Player")]
    public GameObject player;

    [Header("Level")]
    public Border border;

    [Header("Managers")]
    public Spawner spawner;

    public SceneSize sceneSize;

    private void Awake()
    {
        sceneSize = new SceneSize(mainCam);

        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        Pause();
    }

    /// <summary>
    /// ПАУЗА в игре
    /// </summary>
    public void Pause()
    {
        if (pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
