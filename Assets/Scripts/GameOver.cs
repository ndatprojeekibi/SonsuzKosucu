using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text finalGoldsText;
    public static GameOver inst;

    // Start is called before the first frame update
    void Start()
    {
        // En basta oyun bitis ekranini gostermeyi kapat.
        gameObject.SetActive(false);
    }

    public void Setup()
    {
        // Oyun sonunda oyun bitis ekranini goster.
        gameObject.SetActive(true);
        finalGoldsText.text = GameManager.inst.golds + " Golds";
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
