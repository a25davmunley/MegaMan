using UnityEngine; // Importa la librería principal de Unity

public class PlayerMovement : MonoBehaviour // Clase que controla el movimiento del jugador
{
    public float speed = 5f; // Velocidad de movimiento horizontal

    private Rigidbody2D rb; // Referencia al Rigidbody2D del jugador
    private PlayerInputHandler input; // Referencia al sistema de input

    void Awake() // Se ejecuta al crear el objeto
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D
        input = GetComponent<PlayerInputHandler>(); // Obtiene el input del jugador
    }

    void FixedUpdate() // Se ejecuta en intervalos de física
    {
        float x = input.MoveInput.x; // Lee el input horizontal

        rb.velocity = new Vector2(x * speed, rb.velocity.y); // Aplica movimiento manteniendo la velocidad vertical
    }
}