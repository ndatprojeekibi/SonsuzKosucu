using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        // Yeni tile yarat.
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        // Bir sonraki tile in yaratilacagi noktayi belirle.
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Oyunun en basinda 10 tane tile olustur.
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }   
    }
}
