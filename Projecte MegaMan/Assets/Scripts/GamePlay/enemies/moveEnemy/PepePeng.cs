using UnityEngine; // Importa la librería principal de Unity

public class PepePeng : MonoBehaviour // Clase que controla el movimiento del pingüino enemigo
{
    public float speed = 3f; // Velocidad del movimiento horizontal
    public float amplitude = 1f; // Amplitud de la onda (altura del movimiento vertical)
    public float frequency = 2f; // Frecuencia de la onda (rapidez del movimiento vertical)

    public int direction = -1; // Dirección del movimiento horizontal (-1 izquierda, 1 derecha)

    private Vector3 startPos; // Posición inicial del objeto

    void Start() // Se ejecuta al inicio
    {
        startPos = transform.position; // Guarda la posición inicial
    }

    void Update() // Se ejecuta cada frame
    {
        // movimiento horizontal
        transform.position += Vector3.right * direction * speed * Time.deltaTime; // Mueve el objeto en X

        // movimiento vertical en onda 
        float y = Mathf.Sin(Time.time * frequency) * amplitude; // Calcula movimiento tipo onda senoidal

        transform.position = new Vector3( // Actualiza la posición del objeto
            transform.position.x, // Mantiene la posición actual en X
            startPos.y + y, // Aplica el movimiento en Y sobre la posición inicial
            transform.position.z // Mantiene Z
        );

        // destruir fuera de cámara
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); // Convierte posición a espacio de cámara

        if (viewPos.x < -0.2f || viewPos.x > 1.2f) // Si sale de la pantalla
        {
            Destroy(gameObject); // Destruye el objeto
        }
    }
}