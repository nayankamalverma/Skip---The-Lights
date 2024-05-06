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
        SoundManger.Instance.Play(Sounds.ButtonClick);
        UiManager.Instance.Replay();
    }

    private void EndGame()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        UiManager.Instance.BackToMenu();
    }
}
