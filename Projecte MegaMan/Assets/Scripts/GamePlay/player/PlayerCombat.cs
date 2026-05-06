using UnityEngine;
// Librería base de Unity.

public class PlayerCombat : MonoBehaviour
// Controla interacciones de daño del jugador.
{
    private void OnTriggerEnter2D(Collider2D other)
    // Se ejecuta cuando entra en contacto con otro trigger.
    {
        if (other.CompareTag("Enemy"))
        // Si el objeto es un enemigo...
        {
            Debug.Log("Daño recibido");
            // Aquí iría sistema de vida / daño.
        }
    }
}