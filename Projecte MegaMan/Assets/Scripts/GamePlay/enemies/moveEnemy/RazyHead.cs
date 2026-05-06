using UnityEngine;

public class RazyHead : MonoBehaviour
// Enemigo tipo boss con posicionamiento + ataque en V.
{
    public Transform player;

    [Header("Movement")]
    public float moveSpeed = 6f;

    [Header("Attack")]
    public float attackDuration = 0.35f;
    public float arcHeight = 2f;
    public float vWidth = 3f;

    [Header("Cooldown")]
    public float attackCooldown = 0.5f;
    public int maxCycles = 2;

    private Rigidbody2D rb;

    private enum State { Position, Attack }
    private State state;

    private Vector2 startPos;
    private Vector2 endPos;

    private float t;
    private int cycleCount;

    private bool inCooldown;
    private float cooldownTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("❌ RazyHead necesita Rigidbody2D");
            return;
        }

        rb.freezeRotation = true;
        rb.gravityScale = 0f;

        // fallback seguro (por si no lo asignas en Inspector)
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player")?.transform;

        state = State.Position;
    }

    void FixedUpdate()
    {
        if (!player || rb == null) return;

        // ======================
        // COOLDOWN
        // ======================
        if (inCooldown)
        {
            rb.velocity = Vector2.zero;

            cooldownTimer += Time.fixedDeltaTime;

            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0f;
                inCooldown = false;
                state = State.Position;
            }

            return;
        }

        // ======================
        // STATES
        // ======================
        if (state == State.Position)
            Position();
        else
            Attack();
    }

    void Position()
    {
        Vector2 offset = new Vector2(
            -Mathf.Sign(player.position.x - transform.position.x) * 2f,
            2f
        );

        Vector2 target = (Vector2)player.position + offset;

        rb.velocity = (target - (Vector2)transform.position) * moveSpeed;

        if (Vector2.Distance(transform.position, target) < 0.3f)
            StartAttack();
    }

    void StartAttack()
    {
        state = State.Attack;

        startPos = transform.position;

        float dir = Mathf.Sign(player.position.x - transform.position.x);

        endPos = startPos + new Vector2(dir * vWidth, 0f);

        t = 0f;
    }

    void Attack()
    {
        t += Time.fixedDeltaTime / attackDuration;

        Vector2 pos = Vector2.Lerp(startPos, endPos, t);

        float height = -Mathf.Sin(t * Mathf.PI) * arcHeight;
        pos.y += height;

        rb.MovePosition(pos);

        if (t >= 1f)
        {
            cycleCount++;

            if (cycleCount >= maxCycles)
            {
                cycleCount = 0;
                inCooldown = true;
                return;
            }

            StartAttack();
        }
    }
}