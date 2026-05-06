using UnityEngine;

public class EnemyHealth : MonoBehaviour
// Gestiona la vida y muerte de cualquier enemigo.
{
    public int maxHealth = 3;
    // Vida máxima del enemigo.

    private int currentHealth;
    // Vida actual.

    void Awake()
    {
        currentHealth = maxHealth;
        // Al empezar, la vida actual es la máxima.
    }

    public void TakeDamage(int damage)
    // Recibe daño desde el jugador o armas.
    {
        currentHealth -= damage;
        // Reduce vida.

        if (currentHealth <= 0)
        {
            Die();
            // Si llega a 0 → muere.
        }
    }

    void Die()
    // Muerte del enemigo.
    {
        Destroy(gameObject);
        // Elimina el enemigo de la escena.
    }
}