using UnityEngine; // Importa la librería principal de Unity

public class Shooter : MonoBehaviour // Clase que controla el sistema de disparo del jugador
{
    public GameObject projectilePrefab; // Prefab del proyectil que se va a instanciar
    public Transform playerShootPoint; // Punto desde donde sale el disparo

    private SpriteRenderer sprite; // Referencia al SpriteRenderer para saber hacia dónde mira

    void Awake() // Se ejecuta al iniciar el objeto
    {
        sprite = GetComponent<SpriteRenderer>(); // Obtiene el SpriteRenderer del jugador
    }

    void Update() // Se ejecuta cada frame
    {
        if (Input.GetKeyDown(KeyCode.E)) // Si se presiona la tecla E
        {
            Shoot(); // Lanza el disparo
        }
    }

    void Shoot() // Método que crea y lanza el proyectil
    {
        if (projectilePrefab == null || playerShootPoint == null) // Verifica referencias
            return;

        GameObject proj = Instantiate(projectilePrefab, playerShootPoint.position, Quaternion.identity); // Instancia el proyectil

        MegaManProjectile bullet = proj.GetComponent<MegaManProjectile>(); // Obtiene el script del proyectil

        if (bullet == null) // Si no tiene el script, no hace nada
            return;

        Vector2 dir = Vector2.right; // Dirección por defecto (derecha)

        if (sprite != null && sprite.flipX) // Si el sprite está volteado
            dir = Vector2.left; // Cambia dirección a la izquierda

        bullet.SetDirection(dir); // Asigna la dirección al proyectil
    }
}