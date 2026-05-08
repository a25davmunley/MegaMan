using UnityEngine;

public class Gabyoall : EnemyAI
{
    public float speed = 2f;
    public float chaseSpeed = 4f;

    public float wallCheckDistance = 0.6f;
    public float groundCheckDistance = 1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!player) return;

        float currentSpeed = chasing ? chaseSpeed : speed;

        CheckWall();
        CheckGroundAhead();

        rb.velocity = new Vector2(direction * currentSpeed, rb.velocity.y);
    }

    void CheckWall()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.right * direction * 0.5f;
        Vector2 dir = Vector2.right * direction;

        Debug.DrawRay(origin, dir * wallCheckDistance, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(origin, dir, wallCheckDistance, groundLayer);

        if (hit.collider != null)
        {
            Flip();
        }
    }

    void CheckGroundAhead()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.right * direction * 0.5f;
        Vector2 down = Vector2.down;

        Debug.DrawRay(origin, down * groundCheckDistance, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(origin, down, groundCheckDistance, groundLayer);

        // ❌ si NO hay suelo → girar
        if (hit.collider == null)
        {
            Flip();
        }
    }

    void Flip()
    {
        direction *= -1;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;

        transform.position += Vector3.right * direction * 0.1f;
    }
}