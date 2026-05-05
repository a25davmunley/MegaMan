using UnityEngine;

public class Gabyoall : MonoBehaviour
{
    public Transform player;

    public float speed = 2f;
    public float chaseSpeed = 4f;
    public float detectRange = 5f;

    public float wallCheckDistance = 0.6f;

    public LayerMask groundLayer; // 🔥 IMPORTANTE

    private Rigidbody2D rb;

    private int direction = 1;
    private bool chasing = false;

    private RaycastHit2D lastHit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        Debug.Log("🔥 Gabyoall START");
    }

    void FixedUpdate()
    {
        if (!player) return;

        float dist = Vector2.Distance(transform.position, player.position);
        chasing = dist <= detectRange;

        CheckWall();

        float currentSpeed = chasing ? chaseSpeed : speed;

        rb.velocity = new Vector2(direction * currentSpeed, rb.velocity.y);

        Debug.Log($"👁 Dist: {dist} | Chase: {chasing} | Dir: {direction}");
    }

    void CheckWall()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.up * 0.2f;
        Vector2 dir = Vector2.right * direction;

        lastHit = Physics2D.Raycast(origin, dir, wallCheckDistance, groundLayer);

        // 👇 AQUÍ MISMO
        if (lastHit.collider == null)
        {
            Debug.Log("❌ NO detecta pared");
        }
        else
        {
            Debug.Log("✔ detecta: " + lastHit.collider.name);
        }

        Debug.DrawLine(origin, origin + dir * wallCheckDistance, lastHit.collider ? Color.red : Color.green);

        if (lastHit.collider != null)
        {
            direction *= -1;
        }
    }

    void OnDrawGizmos()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.up * 0.2f;
        Vector2 dir = Vector2.right * direction;
        Vector2 end = origin + dir * wallCheckDistance;

        Gizmos.color = lastHit.collider ? Color.red : Color.green;
        Gizmos.DrawLine(origin, end);
        Gizmos.DrawSphere(end, 0.07f);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)dir * 0.5f);
    }
}