using UnityEngine;

public class ObstacelSpawner : MonoBehaviour
{
   [SerializeField]
   private GameObject[] ObstacelsPrefabs;
   [SerializeField]
   private float spawnTime = 2f;
    [SerializeField]
    private float speed=3f;


   private float spawnTimer;

   private void Update(){
      SpawnLoop();
   }

    private void SpawnLoop()
    {
        spawnTimer += Time.deltaTime;
        float time= Random.Range(1, spawnTime);

        if(spawnTimer >= time)
        {
            SpawnObs();
            spawnTimer = 0;  
        }
    }

    private void SpawnObs()
    {
        GameObject obstacel = Instantiate(ObstacelsPrefabs[Random.Range(0, ObstacelsPrefabs.Length)], transform.position, Quaternion.identity);
        Rigidbody2D rd = obstacel.GetComponent<Rigidbody2D>();
        rd.velocity = speed *  Vector3.left;
    }
}
