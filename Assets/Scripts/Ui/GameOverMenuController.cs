using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    [SerializeField] private Button restart;
    [SerializeField] private Button exit;

    private void Awake()
    {
        restart.onClick.AddListener(RestartGame);
        exit.onClick.AddListener(EndGame);
    }

    private void RestartGame()                      ///creating gameover
    {
        UiManager.Instance.Replay();
    }

    private void EndGame()
    {
        UiManager.Instance.BackToMenu();
    }
}
