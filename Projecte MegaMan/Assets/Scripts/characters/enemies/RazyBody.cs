using UnityEngine;

public class RazyBody : MonoBehaviour
{
    public float lifeTime = 1.5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 dir = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
        rb.velocity = dir * 2f;

        Destroy(gameObject, lifeTime);
    }
}