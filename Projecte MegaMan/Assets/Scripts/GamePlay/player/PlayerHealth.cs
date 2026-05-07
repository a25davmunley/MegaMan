using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Vida máxima del jugador
    public int maxHealth = 100;

    // Vida actual del jugador
    public int currentHealth;

    void Start()
    {
        // Al iniciar, la vida empieza llena
        currentHealth = maxHealth;
    }

    // Función que reciben TODOS los enemigos
    public void TakeDamage(int damage)
    {
        // Reducir vida
        currentHealth -= damage;

        // Evitar valores negativos
        if (currentHealth < 0)
            currentHealth = 0;

        // Si muere el jugador
        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Aquí puedes luego poner respawn, animación, etc.
        gameObject.SetActive(false);
    }
}