using UnityEngine;

public class Gabyoall : EnemyAI
// Enemigo que patrulla y persigue.
{
    public float speed = 2f;
    public float chaseSpeed = 4f;

    public float wallCheckDistance = 0.6f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private int direction = 1;

    private RaycastHit2D hit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Física del enemigo.
    }

    void FixedUpdate()
    {
        if (!player) return;

        float currentSpeed = chasing ? chaseSpeed : speed;
        // Si persigue → más rápido.

        CheckWall();
        // Detecta paredes.

        rb.velocity = new Vector2(direction * currentSpeed, rb.velocity.y);
        // Movimiento lateral.
    }

    void CheckWall()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.up * 0.2f;
        Vector2 dir = Vector2.right * direction;

        hit = Physics2D.Raycast(origin, dir, wallCheckDistance, groundLayer);
        // Raycast para detectar pared.

        if (hit.collider != null)
        {
            direction *= -1;
            // Cambia dirección al chocar.
        }
    }
}