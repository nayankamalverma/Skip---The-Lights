using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    //Ui objects
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI score;


    //varible for initialization
    private GameManager gameManager;
    private ObstacelSpawner obstacelSpawner;
    public static UiManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        gameManager = GameManager.Instance;
        obstacelSpawner = ObstacelSpawner.Instance;
    }
    private void Update()
    {
        UpdateScore();
    }

    //on start game
    public void StartGame()
    {
        startMenu.SetActive(false);
        obstacelSpawner.ResetGame();
        gameManager.StartGame();
    }

    public void BackToMenu()
    {
        startMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    public void Replay()
    {
        gameOverMenu.SetActive(false);
        obstacelSpawner.ResetGame();
        gameManager.StartGame();
    }
    private void UpdateScore()
    {
        score.text = "Score : " + gameManager.GetScore();
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        gameManager.GameOver();
    }
}
