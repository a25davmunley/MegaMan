using UnityEngine; // Importa la librería principal de Unity

public class PlayerAnimation : MonoBehaviour // Controla las animaciones del jugador
{
    private Animator animator; // Referencia al Animator
    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private SpriteRenderer sprite; // Referencia al SpriteRenderer para voltear el personaje
    private PlayerInputHandler input; // Entrada del jugador (input)
    private PlayerGroundCheck ground; // Comprobación de si está en el suelo

    private bool wasGrounded; // Guarda si estaba en el suelo en el frame anterior

    void Awake() // Se ejecuta al iniciar el objeto
    {
        animator = GetComponent<Animator>(); // Obtiene el Animator
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D
        sprite = GetComponent<SpriteRenderer>(); // Obtiene el SpriteRenderer
        input = GetComponent<PlayerInputHandler>(); // Obtiene el input del jugador
        ground = GetComponent<PlayerGroundCheck>(); // Obtiene el sistema de suelo

        wasGrounded = ground.IsGrounded; // Inicializa el estado anterior del suelo
    }

    void Update() // Se ejecuta cada frame
    {
        bool isGrounded = ground.IsGrounded; // Estado actual del suelo

        animator.SetBool("EnSuelo", isGrounded); // Actualiza animación de estar en suelo

        animator.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x)); // Velocidad horizontal para animación

        // Detecta el momento exacto en el que el jugador deja el suelo
        if (isGrounded == false && wasGrounded == true)
        {
            animator.SetTrigger("Jump"); // Activa animación de salto
        }

        wasGrounded = isGrounded; // Actualiza estado anterior

        Flip(); // Controla la dirección del sprite
    }

    void Flip() // Cambia la dirección del personaje
    {
        float moveX = input.MoveInput.x; // Lee input horizontal

        if (moveX > 0.1f) // Si se mueve a la derecha
            sprite.flipX = false; // Mira a la derecha
        else if (moveX < -0.1f) // Si se mueve a la izquierda
            sprite.flipX = true; // Mira a la izquierda
    }
}