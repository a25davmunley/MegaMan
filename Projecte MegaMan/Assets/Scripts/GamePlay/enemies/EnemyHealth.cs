using UnityEngine; // Importa la librería principal de Unity

public class EnemyHealth : MonoBehaviour // Clase que controla la vida del enemigo
{
    public int maxHealth = 3; // Vida máxima del enemigo
    public int currentHealth; // Vida actual del enemigo

    void Awake() // Se ejecuta antes de Start, al cargar el objeto
    {
        currentHealth = maxHealth; // Inicializa la vida actual con la vida máxima
    }

    public void TakeDamage(int damage) // Método para recibir daño
    {
        currentHealth -= damage; // Resta el daño a la vida actual

        if (currentHealth <= 0) // Si la vida llega a 0 o menos
        {
            Die(); // Llama al método de muerte
        }
    }

    void Die() // Método que maneja la muerte del enemigo
    {
        Destroy(gameObject); // Destruye el objeto enemigo
    }
}