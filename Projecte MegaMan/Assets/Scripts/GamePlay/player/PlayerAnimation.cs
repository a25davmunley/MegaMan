using UnityEngine;
// Librería base de Unity.

public class PlayerAnimation : MonoBehaviour
// Controla animaciones del jugador.
{
    private Animator animator;
    // Sistema de animaciones.

    private PlayerInputHandler input;
    // Input del jugador.

    private Rigidbody2D rb;
    // Física del jugador.

    private void Awake()
    {
        animator = GetComponent<Animator>();
        // Obtiene Animator.

        input = GetComponent<PlayerInputHandler>();
        // Obtiene input.

        rb = GetComponent<Rigidbody2D>();
        // Obtiene físicas.
    }

    private void Update()
    // Se ejecuta cada frame.
    {
        animator.SetFloat("Horizontal", Mathf.Abs(input.MoveInput.x));
        // Envía al Animator la velocidad horizontal (valor absoluto).

        animator.SetFloat("VerticalSpeed", rb.velocity.y);
        // Envía la velocidad vertical (salto o caída).
    }
}