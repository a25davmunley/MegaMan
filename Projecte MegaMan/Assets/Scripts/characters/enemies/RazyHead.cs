using UnityEngine;

public class RazyHead : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 6f;
    public float attackSpeed = 8f;

    public float minStepTime = 0.25f;   // ⏱️ mínimo tiempo antes de cambiar punto
    public float pauseTime = 0.15f;     // ⏸️ pausa en A / B / C (CLAVE)

    public int maxCycles = 2;

    private Rigidbody2D rb;

    private enum State { Position, Attack }
    private State state;

    private Vector2 A, B, C;
    private Vector2 currentTarget;

    private float stepTimer;
    private float pauseTimer;

    private bool isPaused;

    private int step;
    private int cycleCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        state = State.Position;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        stepTimer += Time.fixedDeltaTime;

        if (state == State.Position)
            Position();
        else
            Attack();
    }

    // 🟢 posicionamiento lateral
    void Position()
    {
        Vector2 dir = (player.position - transform.position).normalized;

        Vector2 offset = new Vector2(-Mathf.Sign(dir.x) * 2f, 2f);
        Vector2 target = (Vector2)player.position + offset;

        rb.velocity = (target - (Vector2)transform.position).normalized * moveSpeed;

        if (Vector2.Distance(transform.position, target) < 0.2f)
        {
            StartAttack();
        }
    }

    // 🔥 iniciar patrón A B C B A
    void StartAttack()
    {
        state = State.Attack;

        step = 0;
        cycleCount = 0;

        stepTimer = 0;
        pauseTimer = 0;
        isPaused = false;

        Vector2 p = player.position;

        A = p + Vector2.left * 2f;
        B = p;
        C = p + Vector2.right * 2f;

        currentTarget = B;
    }

    // 🔴 movimiento con pausa en cada punto
    void Attack()
    {
        // ⏸️ PAUSA EN EL PUNTO
        if (isPaused)
        {
            pauseTimer += Time.fixedDeltaTime;

            rb.velocity = Vector2.zero;

            if (pauseTimer >= pauseTime)
            {
                isPaused = false;
                pauseTimer = 0;
                stepTimer = 0;
                NextStep();
            }

            return;
        }

        // 🚶 movimiento hacia el punto actual
        Vector2 dir = currentTarget - (Vector2)transform.position;
        rb.velocity = dir.normalized * attackSpeed;

        // ✔ llega al punto
        if (Vector2.Distance(transform.position, currentTarget) < 0.2f
            && stepTimer >= minStepTime)
        {
            rb.velocity = Vector2.zero;

            isPaused = true; // 🔥 activa pausa
        }
    }

    void NextStep()
    {
        step++;

        switch (step)
        {
            case 1: currentTarget = C; break;
            case 2: currentTarget = B; break;
            case 3: currentTarget = A; break;
            default:
                cycleCount++;

                if (cycleCount >= maxCycles)
                {
                    state = State.Position;
                    return;
                }

                step = 0;
                currentTarget = B;
                break;
        }
    }
}