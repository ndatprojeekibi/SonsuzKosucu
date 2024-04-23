using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text goldsText;
    public static GameOver inst;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Setup()
    {
        gameObject.SetActive(true);
        goldsText.text = GameManager.inst.score + " Golds";
    }

    private void Awake()
    {
        inst = this; // Singleton
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
