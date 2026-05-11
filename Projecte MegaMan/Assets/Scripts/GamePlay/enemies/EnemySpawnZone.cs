using UnityEngine; // Importa la librería principal de Unity

public class EnemySpawnZone : MonoBehaviour // Zona que controla el spawn de enemigos
{
    public GameObject enemyPrefab; // Prefab del enemigo a instanciar
    public Transform spawnPoint; // Punto donde aparece el enemigo

    private bool playerInside; // Indica si el jugador está dentro de la zona
    private GameObject currentEnemy; // Referencia al enemigo actual en escena

    void OnTriggerEnter2D(Collider2D other) // Se ejecuta al entrar en el trigger
    {
        Debug.Log("ENTRÓ: " + other.name); // Muestra en consola quién entró
    }

    void OnTriggerExit2D(Collider2D other) // Se ejecuta al salir del trigger
    {
        if (!other.CompareTag("Player")) return; // Solo afecta al jugador

        playerInside = false; // Marca que el jugador salió de la zona
    }

    void OnTriggerStay2D(Collider2D other) // Se ejecuta mientras esté dentro del trigger
    {
        if (other.CompareTag("Player")) // Si es el jugador
            playerInside = true; // Marca que sigue dentro
    }

    void TrySpawn() // Intenta crear un enemigo
    {
        if (!playerInside) return; // Solo spawnea si el jugador está dentro

        if (currentEnemy != null) return; // Evita múltiples enemigos activos

        Vector3 pos = spawnPoint != null // Si hay spawnPoint asignado
            ? spawnPoint.position // Usa su posición
            : transform.position; // Si no, usa la posición del objeto

        currentEnemy = Instantiate(enemyPrefab, pos, Quaternion.identity); // Crea el enemigo

        currentEnemy.AddComponent<EnemyLifeWatcher>().Init(this); // Le añade un script para detectar su muerte
    }

    public void OnEnemyDeath() // Se llama cuando el enemigo muere
    {
        currentEnemy = null; // Limpia referencia del enemigo

        if (playerInside) // Si el jugador sigue dentro de la zona
        {
            TrySpawn(); // Vuelve a intentar spawnear
        }
    }
}