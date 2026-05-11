using UnityEngine;

public class IceProjectile : MonoBehaviour
{
    public float speed = 6f;
    public float lifeTime = 3f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.currentHealth -= 3;

            if (player.currentHealth <= 0)
            {
                Debug.Log("Player muerto");
                player.gameObject.SetActive(false);
            }
        }

        Destroy(gameObject);
    }
}