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

        // 🧠 elegir dirección fija (izquierda o derecha)
        direction = (transform.position.x < FindObjectOfType<CrazyRazy>().transform.position.x) ? 1 : -1;

        // 🔥 IMPORTANTE: evitar que caiga como objeto físico
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        // 🚶 movimiento constante horizontal
        rb.velocity = new Vector2(direction * speed, 0f);
    }
}