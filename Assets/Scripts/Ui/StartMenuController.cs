using UnityEngine;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    [SerializeField]
    private Button start;
    [SerializeField]
    private Button exit;
    private void Awake()
    {
        start.onClick.AddListener(StartGame);
        exit.onClick.AddListener(ExitGame);
    }

    
    private void StartGame()
    {
        UiManager.Instance.StartGame();
    }
    private void ExitGame()
    {
        Application.Quit();
    }

}
