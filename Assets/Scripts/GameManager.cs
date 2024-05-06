using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
    }

    public void GameOver()
    {
        currenScore = 0f;
        isPlaying = false;
    }

    public string GetScore()
    {
        return Mathf.Floor(currenScore).ToString();
    }
}
