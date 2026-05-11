using UnityEngine; // Importa la librería principal de Unity

public class PlayerHealth : MonoBehaviour // Clase que controla la vida del jugador
{
    public int maxHealth = 100; // Vida máxima del jugador
    public int currentHealth; // Vida actual del jugador

    void Awake() // Se ejecuta antes de Start al cargar el objeto
    {
        currentHealth = maxHealth; // Inicializa la vida actual con la máxima
    }
}