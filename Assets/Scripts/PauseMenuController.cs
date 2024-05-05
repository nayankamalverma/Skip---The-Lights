using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private Button resume;
    [SerializeField] private Button exit;
    private void Awake()
    {
        resume.onClick.AddListener(ResumeGame);
        exit.onClick.AddListener(EndGame);
    }


    private void EndGame()
    {
       // UiManager.Instance.EndGame();
    }
}
