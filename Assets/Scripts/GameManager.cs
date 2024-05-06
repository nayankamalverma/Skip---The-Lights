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
        string loadedData = SaveSystem.Load("save");
        if(loadedData != null)
        {
            GameData = JsonUtility.FromJson<GameData>(loadedData);
        }
        else
        {
            GameData = new GameData();
        }
        
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

            string saveString = JsonUtility.ToJson(GameData);

            SaveSystem.Save("save", saveString);
        }
        isPlaying = false;
    }

    public string GetScore()
    {
        return Mathf.Floor(currenScore).ToString();
    }
    public string GetHighScore()
    {
        return Mathf.Floor(GameData.highscore).ToString();
    }
}
