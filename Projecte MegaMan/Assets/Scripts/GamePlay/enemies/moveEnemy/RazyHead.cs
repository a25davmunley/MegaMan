using UnityEngine; // Importa la librería principal de Unity

public class RazyHead : MonoBehaviour // Clase que controla el comportamiento de la cabeza del enemigo
{
    public Transform player; // Referencia al jugador

    public float moveSpeed = 6f; // Velocidad de movimiento en fase de posicionamiento
    public float attackDuration = 0.35f; // Duración de cada ataque

    public float arcHeight = 2f; // Altura del arco durante el ataque
    public float vWidth = 3f; // Anchura del movimiento en el ataque (forma de V)

    public float attackCooldown = 0.5f; // Tiempo de espera entre ataques
    public int maxCycles = 2; // Número de ciclos de ataque antes del cooldown

    public float hitSize = 1.2f; // Distancia para considerar impacto al jugador

    private Rigidbody2D rb; // Referencia al Rigidbody2D

    private enum State { Position, Attack } // Estados del enemigo
    private State state; // Estado actual

    private Vector2 startPos; // Posición inicial del ataque
    private Vector2 endPos; // Posición final del ataque

    private float t; // Progreso del ataque (0 a 1)

    private int cycleCount; // Contador de ciclos de ataque

    private bool inCooldown; // Indica si está en cooldown
    private float cooldownTimer; // Temporizador del cooldown

    void Start() // Se ejecuta al inicio
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D

        player = GameObject.FindGameObjectWithTag("Player")?.transform; // Busca al jugador

        rb.freezeRotation = true; // Evita rotación física
        rb.gravityScale = 0f; // Desactiva gravedad

        state = State.Position; // Estado inicial
    }

    void FixedUpdate() // Lógica de física
    {
        if (!player) return; // Si no hay jugador, no hace nada

        if (inCooldown) // Si está en cooldown
        {
            rb.velocity = Vector2.zero; // Detiene movimiento

            cooldownTimer += Time.fixedDeltaTime; // Suma tiempo

            if (cooldownTimer >= attackCooldown) // Si termina cooldown
            {
                cooldownTimer = 0f; // Reinicia timer
                inCooldown = false; // Sale de cooldown
                state = State.Position; // Vuelve a posicionamiento
            }

            return; // No hace más lógica
        }

        if (state == State.Position) // Si está posicionándose
            Position(); // Ejecuta lógica de posicionamiento
        else
            Attack(); // Ejecuta ataque
    }

    void Position() // Movimiento previo al ataque
    {
        Vector2 offset = new Vector2( // Offset relativo al jugador
            -Mathf.Sign(player.position.x - transform.position.x) * 2f, // Se coloca al lado opuesto
            2f // altura fija
        );

        Vector2 target = (Vector2)player.position + offset; // Punto objetivo

        rb.velocity = (target - (Vector2)transform.position) * moveSpeed; // Se mueve hacia el objetivo

        if (Vector2.Distance(transform.position, target) < 0.3f) // Si está cerca
            StartAttack(); // Empieza ataque
    }

    void StartAttack() // Inicializa el ataque
    {
        state = State.Attack; // Cambia estado

        startPos = transform.position; // Guarda posición inicial

        float dir = Mathf.Sign(player.position.x - transform.position.x); // Dirección hacia el jugador

        endPos = startPos + new Vector2(dir * vWidth, 0f); // Define punto final del ataque

        t = 0f; // Reinicia progreso
    }

    void Attack() // Lógica del ataque
    {
        t += Time.fixedDeltaTime / attackDuration; // Avanza progreso del ataque

        Vector2 pos = Vector2.Lerp(startPos, endPos, t); // Interpola posición

        pos.y += -Mathf.Sin(t * Mathf.PI) * arcHeight; // Añade arco vertical

        rb.MovePosition(pos); // Mueve el Rigidbody

        CheckHit(); // Comprueba si golpea al jugador

        if (t >= 1f) // Si termina el ataque
        {
            cycleCount++; // Incrementa ciclo

            if (cycleCount >= maxCycles) // Si alcanzó máximo de ciclos
            {
                cycleCount = 0; // Reinicia contador
                inCooldown = true; // Entra en cooldown
                return;
            }

            StartAttack(); // Repite ataque
        }
    }

    void CheckHit() // Detecta impacto con el jugador
    {
        float dist = Vector2.Distance(transform.position, player.position); // Calcula distancia

        if (dist <= hitSize) // Si está dentro del rango de golpe
        {
            Debug.Log("se toca"); // Indica impacto
        }
    }
}