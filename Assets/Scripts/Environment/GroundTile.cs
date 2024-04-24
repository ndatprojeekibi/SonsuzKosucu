using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    public GameObject goldPrefab;
    public GameObject tallObstaclePrefab;
    float tallObstacleChance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnGolds();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // Hangi engeli ortaya cikaracagini sec.
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);

        if(random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }

        // Engeli ortaya cikarmak icin rastgele bir konum sec.
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Engeli olustur.
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnGolds()
    {
        int goldsToSpawn = 10;

        for (int i = 0; i < goldsToSpawn; i++)
        {
            // Bir Gold yarat ve bunu tile a bagla. Yani tile i yok ettigimizde Gold da Tile ile beraber yok olacak.
            GameObject temp = Instantiate(goldPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        // Colliderin icinde rastgele bir nokta getir.
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x , collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        // Gelen nokta tam sinirdaysa tekrardan nokta al.
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        // Goldlari ayni yukseklikte olusturabilmek icin.
        point.y = 1;

        return point;
    }
}
