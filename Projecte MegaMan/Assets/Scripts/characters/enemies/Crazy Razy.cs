using UnityEngine;

public class CrazyRazy : MonoBehaviour
{
    public Transform player;

    public float detectRange = 6f;   // empieza a perseguir
    public float splitRange = 1.5f;  // explota si está cerca
    public float speed = 3f;

    public GameObject headPrefab;
    public GameObject bodyPrefab;

    private Rigidbody2D rb;
    private bool activated = false;
    private bool chasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("❌ NO HAY PLAYER CON TAG 'Player'");
        }

        // 🔥 evita que el jugador se suba encima fácilmente
        rb.sharedMaterial = new PhysicsMaterial2D()
        {
            friction = 0f,
            bounciness = 0f
        };
    }

    void Update()
    {
        if (player == null || activated) return;

        float dist = Vector2.Distance(transform.position, player.position);

        // 👁️ empieza persecución
        if (dist <= detectRange)
        {
            chasing = true;
        }

        // 💥 split si está muy cerca
        if (dist <= splitRange)
        {
            Split();
        }
    }

    void FixedUpdate()
    {
        if (!chasing || activated) return;

        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        Vector2 dir = (player.position - transform.position).normalized;

        // 🚀 movimiento horizontal estable
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    void Split()
    {
        activated = true;

        Instantiate(headPrefab, transform.position, Quaternion.identity);
        Instantiate(bodyPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // 🔥 evita que el jugador se quede encima
        if (col.gameObject.CompareTag("Player"))
        {
            Rigidbody2D prb = col.rigidbody;

            if (prb != null)
            {
                Vector2 push = (col.transform.position - transform.position).normalized;
                prb.AddForce(push * 3f, ForceMode2D.Impulse);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (player == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, splitRange);
    }
}