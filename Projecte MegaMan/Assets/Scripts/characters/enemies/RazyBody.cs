using UnityEngine;

public class RazyBody : MonoBehaviour
{
    public float speed = 2f;
    public float lifeTime = 3f;

    private Rigidbody2D rb;
    private int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // puede ser derecha o izquierda según diseño
        direction = Random.value > 0.5f ? 1 : -1;

        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
}