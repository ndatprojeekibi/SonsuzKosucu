using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int golds;
    public static GameManager inst;

    public PlayerMovement playerMovement;
    public Text playingGoldsText;

    public void IncrementGolds()
    {
        golds++;
        playingGoldsText.text = "Golds: " + golds.ToString();

        // Player in hizini arttir.
        if(golds % 25 == 0)
        {
            playerMovement.speed += playerMovement.speedIncrease;
        }
    }

    private void Awake()
    {
        inst = this; // Singleton
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
