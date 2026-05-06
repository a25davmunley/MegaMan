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

        if (rb == null)
        {
            Debug.LogError("❌ RazyBody necesita Rigidbody2D");
            return;
        }

        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        rb.velocity = new Vector2(direction * speed, 0f);
    }
}