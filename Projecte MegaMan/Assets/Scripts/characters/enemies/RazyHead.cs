using UnityEngine;

public class RazyHead : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float arcHeight = 3f;

    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 toPlayer = (Vector2)player.position - rb.position;

        //  persecución real
        direction = toPlayer.normalized;

        //  efecto U (arco vertical tipo ataque)
        Vector2 arc = new Vector2(0, Mathf.Sin(Time.time * 5f) * arcHeight);

        Vector2 move = (direction * speed + arc);

        rb.velocity = move;
    }
}