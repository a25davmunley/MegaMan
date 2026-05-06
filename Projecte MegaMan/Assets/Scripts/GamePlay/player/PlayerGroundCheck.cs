using UnityEngine;
// Librería base de Unity.

public class PlayerGroundCheck : MonoBehaviour
// Detecta si el jugador está tocando el suelo.
{
    public Transform groundCheck;
    // Punto desde donde se hace la comprobación.

    public float radius = 0.4f;
    // Tamaño del área de detección.

    public LayerMask groundLayer;
    // Capas que cuentan como suelo.

    public bool IsGrounded { get; private set; }
    // Resultado: si está en el suelo o no.

    private void Update()
    // Se ejecuta cada frame.
    {
        IsGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            radius,
            groundLayer
        );
        // Crea un círculo invisible que detecta colisiones con el suelo.
    }

    private void OnDrawGizmosSelected()
    // Dibuja visualmente el área en el editor.
    {
        if (groundCheck == null) return;
        // Evita errores si no está asignado.

        Gizmos.color = Color.red;
        // Color del dibujo.

        Gizmos.DrawWireSphere(groundCheck.position, radius);
        // Dibuja el radio de detección del suelo.
    }
}