using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameData GameData;

    [SerializeField] private GameObject player;
    public float currenScore = 0f;
    public bool isPlaying = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //if we have data then load data 
        //else create new data
        GameData = new GameData();
    }

    private void Update()
    {
        if(isPlaying)
        {
            currenScore += Time.deltaTime;
        }

    }

    public void StartGame()
    {
        isPlaying = true;
        if( !player.activeSelf )player.SetActive(true);

        currenScore = 0f;
    }

    public void GameOver()
    {
        if(GameData.highscore <  currenScore)
        {
            GameData.highscore = currenScore;
        }
        isPlaying = false;
    }

    public string GetScore()
    {
        return Mathf.RoundToInt(currenScore).ToString();
    }
    public string GetHighScore()
    {
        return Mathf.RoundToInt(GameData.highscore).ToString();
    }
}
