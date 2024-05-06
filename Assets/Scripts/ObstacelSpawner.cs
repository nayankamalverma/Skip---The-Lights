using UnityEngine;

public class ObstacelSpawner : MonoBehaviour
{
	[SerializeField] private GameObject[] ObstacelsPrefabs;
	[SerializeField] private Transform ObstaclesParent;
	[SerializeField] private float spawnTime = 3f; //base values
	[Range(0f, 1f)] public float spawnTimeFactor = 0.1f;
	[SerializeField] private float speed=3f; // 
    [Range(0f, 1f)] public float speedFactor = 0.2f;


    private float obstacleSpawnTime;
	private float obstacleSpeed;
	
	public static ObstacelSpawner Instance;
	private float timeAlive;
	private float spawnTimer;  //time until obstacle Spawn

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update(){
	  if(GameManager.Instance.isPlaying){
			timeAlive += Time.deltaTime;
			CalculateFactors();
			SpawnLoop();
		}
		else
		{
			ClearAllObstacles();
		}
   }

	private void SpawnLoop()
	{
		spawnTimer += Time.deltaTime;

		if(spawnTimer >= obstacleSpawnTime)
		{
			SpawnObs();
			spawnTimer = 0;  
		}
	}

	public void ResetGame(){
		timeAlive = 1f;
		obstacleSpawnTime = spawnTime;
		obstacleSpeed = speed;

	}

	private void CalculateFactors()
	{
		//obstacleSpawnTime = spawnTime* Mathf.Pow(timeAlive, spawnTimeFactor);
		obstacleSpeed = speed * Mathf.Pow(timeAlive, speedFactor);
	}

	private void ClearAllObstacles() { 
		foreach(Transform child in ObstaclesParent) {
			Destroy(child.gameObject);
		}
	}
	private void SpawnObs()
	{
		GameObject obstacel = Instantiate(ObstacelsPrefabs[Random.Range(0, ObstacelsPrefabs.Length)], transform.position, Quaternion.identity);
		obstacel.transform.parent = ObstaclesParent;
		Rigidbody2D rd = obstacel.GetComponent<Rigidbody2D>();
		rd.velocity = obstacleSpeed *  Vector3.left;
	}
}
