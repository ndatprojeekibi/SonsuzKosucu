using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 1.5f;

    bool alive = true;

    public float speedIncrease = 1f;

    private float jumpForce = 10;
    public bool isOnGround = true;

    private void FixedUpdate()
    {
        // Player hayatta degilse hareket etmesin.
        if (!alive) return;

        // Player in dikeydeki ve yataydaki hizlarini ayarladik.
        // Yataydaki hizini oynanis daha iyi olsun diye horizontalMultiplier kere daha hizli yaptik.
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

        // Ziplama Movement
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            // Player zeminde degil.
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // eger collision varsa demek ki Player zeminde.
        isOnGround = true;
    }

    private void Start()
    {

    }

    public void Die()
    {
        alive = false;
        // Oyun bitince toplam biriken Golds u goster.
        GameOver.inst.Setup();
        Invoke("Restart", 2);
    }

    void Restart()
    {
        // Oyunu yeniden baslat.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
