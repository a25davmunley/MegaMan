using UnityEngine;
// Importa funciones básicas de Unity.

public class PlayerMovement : MonoBehaviour
// Controla el movimiento horizontal del jugador.
{
    public float speed = 5f;
    // Velocidad de movimiento.

    private Rigidbody2D rb;
    // Referencia al componente de físicas.

    private PlayerInputHandler input;
    // Referencia al script de input.

    private void Awake()
    // Se ejecuta al iniciar el objeto.
    {
        rb = GetComponent<Rigidbody2D>();
        // Obtiene el Rigidbody2D del jugador.

        input = GetComponent<PlayerInputHandler>();
        // Obtiene el script de input del jugador.
    }

    private void FixedUpdate()
    // Se ejecuta en intervalos de físicas (más estable que Update).
    {
        Vector2 velocity = rb.velocity;
        // Obtiene la velocidad actual del Rigidbody.

        velocity.x = input.MoveInput.x * speed;
        // Aplica el movimiento horizontal según input.

        rb.velocity = velocity;
        // Aplica la nueva velocidad al Rigidbody.
    }
}