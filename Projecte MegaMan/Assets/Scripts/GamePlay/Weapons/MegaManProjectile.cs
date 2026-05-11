using UnityEngine; // Importa la librería principal de Unity

public class MegaManProjectile : MonoBehaviour // Clase que controla el proyectil
{
    public float speed = 10f; // Velocidad del proyectil
    public float lifeTime = 2f; // Tiempo de vida antes de destruirse automáticamente

    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private Vector2 direction; // Dirección del movimiento del proyectil

    void Awake() // Se ejecuta al crearse el objeto, antes de Start
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D del objeto
        Destroy(gameObject, lifeTime); // Destruye el proyectil después de un tiempo
    }

    public void SetDirection(Vector2 dir) // Método para asignar dirección al proyectil
    {
        direction = dir.normalized; // Normaliza la dirección para evitar velocidades inconsistentes
        rb.velocity = direction * speed; // Aplica la velocidad en esa dirección
    }
}