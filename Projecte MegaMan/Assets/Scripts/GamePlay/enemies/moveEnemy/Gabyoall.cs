using UnityEngine; // Importa la librería principal de Unity

public class Gabyoall : EnemyAI // Clase del enemigo que hereda de EnemyAI
{
    public float speed = 2f; // Velocidad normal de movimiento
    public float chaseSpeed = 4f; // Velocidad cuando persigue al jugador

    public float wallCheckDistance = 0.6f; // Distancia del raycast para detectar paredes
    public LayerMask groundLayer; // Capas consideradas como suelo/pared

    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private int direction = 1; // Dirección de movimiento (1 derecha, -1 izquierda)

    private RaycastHit2D hit; // Variable para almacenar impacto del raycast (no se usa directamente aquí)

    void Start() // Se ejecuta al iniciar el objeto
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D del enemigo
    }

    void FixedUpdate() // Se ejecuta en intervalos de física
    {
        if (!player) return; // Si no hay jugador, no hace nada

        float currentSpeed = chasing ? chaseSpeed : speed; // Elige velocidad según estado

        CheckWall(); // Comprueba si hay pared delante

        rb.velocity = new Vector2(direction * currentSpeed, rb.velocity.y); // Mueve al enemigo
    }

    void CheckWall() // Detecta paredes delante del enemigo
    {
        Vector2 origin = (Vector2)transform.position + Vector2.right * direction * 0.5f; // Punto de origen del raycast
        Vector2 dir = Vector2.right * direction; // Dirección del raycast

        Debug.DrawRay(origin, dir * wallCheckDistance, Color.red); // Dibuja raycast en escena

        RaycastHit2D hit = Physics2D.Raycast(origin, dir, wallCheckDistance, groundLayer); // Detecta colisión

        if (hit.collider != null) // Si hay pared delante
        {
            Flip(); // Cambia de dirección
        }
    }

    void Flip() // Invierte la dirección del enemigo
    {
        direction *= -1; // Cambia dirección (izquierda/derecha)

        Vector3 scale = transform.localScale; // Obtiene escala actual
        scale.x = Mathf.Abs(scale.x) * direction; // Invierte visualmente el sprite
        transform.localScale = scale; // Aplica la nueva escala

        transform.position += Vector3.right * direction * 0.1f; // Ajuste para evitar atasco en la pared
    }
}