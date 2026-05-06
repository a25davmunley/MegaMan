using UnityEngine;

public class CrazyRazy : EnemyAI
// Enemigo que persigue y se divide al tocar al jugador.
{
    public float speed = 3f;
    public GameObject headPrefab;
    public GameObject bodyPrefab;

    private Rigidbody2D rb;
    private bool activated = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Obtiene física del enemigo

        if (rb == null)
        {
            Debug.LogError("❌ Falta Rigidbody2D en CrazyRazy");
            return;
        }

        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        rb.sharedMaterial = new PhysicsMaterial2D()
        {
            friction = 0f,
            bounciness = 0f
        };

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            // fallback por si EnemyAI no lo asigna
        }
    }

    void FixedUpdate()
    {
        if (activated) return;
        if (!player || !chasing) return;

        Move();
    }

    void Move()
    {
        if (player == null || rb == null) return;

        Vector2 dir = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (activated) return;

        if (col == null || col.gameObject == null) return;

        if (col.gameObject.CompareTag("Player"))
        {
            Split();

            Rigidbody2D prb = col.rigidbody;

            if (prb != null)
            {
                Vector2 push = (col.transform.position - transform.position).normalized;
                prb.AddForce(push * 3f, ForceMode2D.Impulse);
            }
        }
    }

    void Split()
    {
        activated = true;

        if (headPrefab != null)
            Instantiate(headPrefab, transform.position, Quaternion.identity);
        else
            Debug.LogWarning("⚠ headPrefab no asignado");

        if (bodyPrefab != null)
            Instantiate(bodyPrefab, transform.position, Quaternion.identity);
        else
            Debug.LogWarning("⚠ bodyPrefab no asignado");

        EnemyHealth health = GetComponent<EnemyHealth>();

        if (health != null)
            health.TakeDamage(999);
        else
            Debug.LogWarning("⚠ EnemyHealth no encontrado");

        Destroy(gameObject);
    }
}