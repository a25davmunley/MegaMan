using UnityEngine; // Importa la librería principal de Unity

public class FootHolder : MonoBehaviour // Clase que hace que el objeto se mueva en vertical de forma oscilante
{
    public float minSpeed = 1f; // Velocidad mínima del movimiento
    public float maxSpeed = 3f; // Velocidad máxima del movimiento

    public float minHeight = 1f; // Altura mínima del movimiento
    public float maxHeight = 4f; // Altura máxima del movimiento

    private float speed; // Velocidad final aleatoria
    private float height; // Altura final aleatoria
    private Vector3 startPos; // Posición inicial del objeto

    void Start() // Se ejecuta al iniciar el objeto
    {
        startPos = transform.position; // Guarda la posición inicial

        speed = Random.Range(minSpeed, maxSpeed); // Asigna una velocidad aleatoria
        height = Random.Range(minHeight, maxHeight); // Asigna una altura aleatoria
    }

    void Update() // Se ejecuta cada frame
    {
        float y = Mathf.PingPong(Time.time * speed, height); // Calcula movimiento oscilante en Y

        transform.position = new Vector3( // Actualiza la posición del objeto
            startPos.x, // Mantiene X fija
            startPos.y + y, // Suma el movimiento en Y
            startPos.z // Mantiene Z fija
        );
    }
}