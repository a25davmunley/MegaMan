using UnityEngine; // Importa la librería principal de Unity

public class PlayerGroundCheck : MonoBehaviour // Clase que comprueba si el jugador está en el suelo
{
    public Transform groundCheck; // Punto desde el que se hace la comprobación de suelo
    public float radius = 0.4f; // Radio del área de detección
    public LayerMask groundLayer; // Capas que cuentan como suelo

    public bool IsGrounded { get; private set; } // Propiedad que indica si está en el suelo (solo lectura pública)

    void Update() // Se ejecuta cada frame
    {
        if (groundCheck == null) // Si no hay punto de referencia asignado
        {
            IsGrounded = false; // Se considera que no está en el suelo
            return; // Sale del método
        }

        IsGrounded = Physics2D.OverlapCircle( // Detecta colisión en forma de círculo
            groundCheck.position, // Centro del círculo
            radius, // Radio de detección
            groundLayer // Capas consideradas suelo
        );
    }
}