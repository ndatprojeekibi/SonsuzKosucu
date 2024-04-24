using UnityEngine;

public class GoldPick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        // Gold Coin in Player ile carpisip carpismadigi kontrol edilecek.
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Player in golds una eklenecek.
        GameManager.inst.IncrementGolds();
        // Gold Coin i yok et.
        Destroy(gameObject);
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
