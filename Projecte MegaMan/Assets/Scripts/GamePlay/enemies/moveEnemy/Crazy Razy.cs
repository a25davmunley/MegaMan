using UnityEngine; // Importa la librería principal de Unity

public class CrazyRazy : MonoBehaviour // Define una clase que hereda de MonoBehaviour (comportamiento de Unity)
{
    public Transform player; // Referencia al jugador

    public float detectRange = 6f; // Distancia a la que el enemigo empieza a perseguir
    public float splitRange = 1.2f; // Distancia a la que se divide

    public float speed = 3f; // Velocidad de movimiento

    public GameObject headPrefab; // Prefab de la cabeza al dividirse
    public GameObject bodyPrefab; // Prefab del cuerpo al dividirse

    private Rigidbody2D rb; // Referencia al Rigidbody2D del objeto

    private bool activated; // Evita que el enemigo actúe después de dividirse
    private bool chasing; // Indica si está persiguiendo al jugador

    void Start() // Se ejecuta al iniciar el objeto
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D del propio objeto
        player = GameObject.FindGameObjectWithTag("Player")?.transform; // Busca al jugador por tag
        rb.freezeRotation = true; // Evita que el objeto rote físicamente
    }

    void Update() // Se ejecuta cada frame
    {
        if (!player || activated) return; // Si no hay jugador o ya se activó, no hace nada

        float dist = Vector2.Distance(transform.position, player.position); // Calcula la distancia al jugador
        chasing = dist <= detectRange; // Activa persecución si está dentro del rango

        if (dist <= splitRange) // Si está lo suficientemente cerca
        {
            Split(); // Se divide
        }
    }

    void FixedUpdate() // Se ejecuta en intervalos fijos (física)
    {
        if (!chasing || activated) return; // Si no persigue o está activado, no hace nada

        Vector2 dir = (player.position - transform.position).normalized; // Dirección hacia el jugador
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y); // Mueve al enemigo en X manteniendo Y
    }

    void Split() // Función que maneja la división del enemigo
    {
        activated = true; // Marca como activado para evitar más acciones

        Instantiate(headPrefab, transform.position, Quaternion.identity); // Crea la cabeza
        Instantiate(bodyPrefab, transform.position, Quaternion.identity); // Crea el cuerpo

        Destroy(gameObject); // Elimina el objeto original
    }
}