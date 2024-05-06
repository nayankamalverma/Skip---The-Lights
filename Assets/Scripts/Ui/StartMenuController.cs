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
        SoundManger.Instance.Play(Sounds.ButtonClick);
        UiManager.Instance.StartGame();
    }
    private void ExitGame()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }

}
