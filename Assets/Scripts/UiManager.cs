using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    //Ui objects
    [SerializeField] private GameObject startMenu;
   // [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI score;


    //varible for initialization
    private GameManager gameManager;
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
    }
    private void Update()
    {
        UpdateScore();
    }

    //on start game
    public void StartGame()
    {
        startMenu.SetActive(false);
        gameManager.StartGame();
    }

    private void UpdateScore()
    {
        score.text = "Score : " + gameManager.GetScore();
    }

    public void GameOver()
    {
        gameManager.GameOver();
    }
}
