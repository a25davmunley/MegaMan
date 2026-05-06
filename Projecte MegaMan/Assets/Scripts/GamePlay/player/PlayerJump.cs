using UnityEngine;
// Librería base de Unity.

public class PlayerJump : MonoBehaviour
// Controla la lógica del salto.
{
    public float jumpForce = 7f;
    // Fuerza del salto.

    private Rigidbody2D rb;
    // Física del jugador.

    private PlayerInputHandler input;
    // Input del jugador.

    private PlayerGroundCheck ground;
    // Sistema que detecta si está en el suelo.

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Obtiene físicas.

        input = GetComponent<PlayerInputHandler>();
        // Obtiene input.

        ground = GetComponent<PlayerGroundCheck>();
        // Obtiene detección de suelo.
    }

    private void Update()
    // Se ejecuta cada frame.
    {
        if (input.JumpPressed && ground.IsGrounded)
        // Si el jugador ha pulsado salto Y está en el suelo...
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            // Aplica fuerza vertical de salto.
        }
    }
}