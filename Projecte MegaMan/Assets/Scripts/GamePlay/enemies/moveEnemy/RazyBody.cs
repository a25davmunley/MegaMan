using UnityEngine; // Importa la librería principal de Unity

public class RazyBody : MonoBehaviour // Clase que controla el comportamiento del cuerpo de Razy
{
    public float speed = 2f; // Velocidad de movimiento del cuerpo
    public float lifeTime = 3f; // Tiempo de vida antes de destruirse

    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private int direction; // Dirección de movimiento

    void Start() // Se ejecuta al iniciar el objeto
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D

        rb.gravityScale = 0f; // Desactiva la gravedad
        rb.freezeRotation = true; // Evita rotación física

        CrazyRazy parent = FindObjectOfType<CrazyRazy>(); // Busca al enemigo principal

        if (parent != null) // Si existe el enemigo principal
        {
            direction = -1; // Asigna dirección fija (izquierda)
        }

        Destroy(gameObject, lifeTime); // Destruye el objeto después de un tiempo
    }

    void FixedUpdate() // Lógica de física
    {
        rb.velocity = new Vector2(direction * speed, 0f); // Movimiento horizontal

        CheckTouch(); // Comprueba contacto con el jugador
    }

    void CheckTouch() // Detecta si toca al jugador
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Busca al jugador

        if (player == null) return; // Si no existe, no hace nada

        float dist = Vector2.Distance(transform.position, player.transform.position); // Calcula distancia

        if (dist <= 1f) // Si está cerca del jugador
        {
            Debug.Log("se toca si"); // Mensaje de contacto
        }
    }
}