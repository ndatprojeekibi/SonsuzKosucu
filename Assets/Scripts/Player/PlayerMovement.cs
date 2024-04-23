using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 1.5f;

    bool alive = true;

    GameOver gameOver;

    private void FixedUpdate()
    {
        // Player hayatta degilse hareket etmesin.
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Eger asagi duserse Player i oldur.
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    private void Start()
    {

    }

    public void Die()
    {
        alive = false;

        GameOver.inst.Setup();
        Invoke("Restart", 2);
    }

    void Restart()
    {
        // Oyunu yeniden baslat.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
