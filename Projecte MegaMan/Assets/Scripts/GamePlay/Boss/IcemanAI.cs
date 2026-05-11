using UnityEngine; // Importa la librería principal de Unity

public class IcemanAI : MonoBehaviour // IA del enemigo tipo Iceman
{
    [Header("Movimiento")] // Sección visual en el Inspector
    public float speed = 2f; // Velocidad de patrulla
    public Transform leftPoint; // Punto límite izquierdo
    public Transform rightPoint; // Punto límite derecho

    [Header("Disparo")] // Sección de disparo en el Inspector
    public GameObject iceProjectile; // Prefab del proyectil de hielo
    public Transform shootPoint; // Punto desde donde dispara
    public float shootCooldown = 2f; // Tiempo entre disparos

    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private bool movingRight = true; // Dirección actual de movimiento
    private float shootTimer; // Temporizador de disparo

    void Awake() // Se ejecuta al instanciar el objeto
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D
        shootTimer = shootCooldown; // Inicializa el temporizador
    }

    void Update() // Se ejecuta cada frame
    {
        Patrol(); // Controla el movimiento de patrulla
        ShootLogic(); // Controla la lógica de disparo
    }

    void Patrol() // Movimiento entre dos puntos
    {
        if (movingRight) // Si se mueve a la derecha
        {
            rb.velocity = new Vector2(speed, rb.velocity.y); // Se mueve a la derecha

            if (transform.position.x >= rightPoint.position.x) // Si llega al límite derecho
                Flip(); // Cambia dirección
        }
        else // Si se mueve a la izquierda
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y); // Se mueve a la izquierda

            if (transform.position.x <= leftPoint.position.x) // Si llega al límite izquierdo
                Flip(); // Cambia dirección
        }
    }

    void ShootLogic() // Controla el temporizador de disparo
    {
        shootTimer -= Time.deltaTime; // Reduce el tiempo

        if (shootTimer <= 0f) // Si puede disparar
        {
            Shoot(); // Dispara
            shootTimer = shootCooldown; // Reinicia temporizador
        }
    }

    void Shoot() // Método de disparo
    {
        if (iceProjectile == null || shootPoint == null) return; // Validación

        Instantiate(iceProjectile, shootPoint.position, Quaternion.identity); // Crea el proyectil
    }

    void Flip() // Cambia la dirección del enemigo
    {
        movingRight = !movingRight; // Invierte dirección

        Vector3 scale = transform.localScale; // Obtiene escala actual
        scale.x *= -1; // Invierte horizontalmente el sprite
        transform.localScale = scale; // Aplica la nueva escala
    }
}