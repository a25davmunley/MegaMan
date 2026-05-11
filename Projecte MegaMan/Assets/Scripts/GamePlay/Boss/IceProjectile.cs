using UnityEngine; // Importa la librería principal de Unity

public class IceProjectile : MonoBehaviour // Clase que controla el proyectil de hielo
{
    public float speed = 6f; // Velocidad del proyectil
    public float lifeTime = 3f; // Tiempo de vida antes de destruirse

    private Rigidbody2D rb; // Referencia al Rigidbody2D

    void Awake() // Se ejecuta al crear el objeto
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D del proyectil
        Destroy(gameObject, lifeTime); // Destruye el proyectil tras un tiempo
    }

    void Start() // Se ejecuta al inicio del frame siguiente a Awake
    {
        rb.velocity = transform.right * speed; // Mueve el proyectil hacia su dirección local derecha
    }

    void OnTriggerEnter2D(Collider2D other) // Se ejecuta al tocar otro collider
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>(); // Intenta obtener el script de vida del jugador

        if (player != null) // Si el objeto tocado es el jugador
        {
            player.currentHealth -= 3; // Resta vida al jugador

            if (player.currentHealth <= 0) // Si la vida llega a 0 o menos
            {
                Debug.Log("Player muerto"); // Mensaje en consola
                player.gameObject.SetActive(false); // Desactiva al jugador
            }
        }

        Destroy(gameObject); // Destruye el proyectil al impactar
    }
}