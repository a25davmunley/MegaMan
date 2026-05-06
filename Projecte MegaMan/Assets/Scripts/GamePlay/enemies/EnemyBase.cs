using UnityEngine;

public class EnemyBase : MonoBehaviour
// Clase base que comparten todos los enemigos.
{
    protected Transform player;
    // Referencia al jugador.

    protected EnemyHealth health;
    // Sistema de vida del enemigo.

    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        // Busca al jugador automáticamente.

        health = GetComponent<EnemyHealth>();
        // Obtiene el sistema de vida del enemigo.
    }

    public virtual void TakeDamage(int dmg)
    // Permite que el jugador haga daño al enemigo.
    {
        if (health != null)
        {
            health.TakeDamage(dmg);
            // Aplica daño al sistema de vida.
        }
    }
}