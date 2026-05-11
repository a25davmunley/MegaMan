using UnityEngine; // Importa la librería principal de Unity

public class PlayerJump : MonoBehaviour // Clase que controla el salto del jugador
{
    public float jumpForce = 7f; // Fuerza del salto

    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private PlayerInputHandler input; // Referencia al sistema de input del jugador
    private PlayerGroundCheck ground; // Referencia al sistema de detección de suelo

    void Awake() // Se ejecuta al iniciar el objeto
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D
        input = GetComponent<PlayerInputHandler>(); // Obtiene el input del jugador
        ground = GetComponent<PlayerGroundCheck>(); // Obtiene el detector de suelo
    }

    void Update() // Se ejecuta cada frame
    {
        if (input.JumpPressed && ground.IsGrounded) // Si se ha pulsado salto y está en el suelo
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Resetea la velocidad vertical antes de saltar

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Aplica fuerza de salto en impulso
        }
    }
}