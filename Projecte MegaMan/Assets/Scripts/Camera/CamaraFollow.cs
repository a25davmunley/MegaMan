using UnityEngine; // Importa la librería principal de Unity

public class CameraFollow : MonoBehaviour // Clase que hace que la cámara siga al jugador
{
    private Transform player; // Referencia al transform del jugador
    public Vector3 offset = new Vector3(0, 3, -6); // Desplazamiento de la cámara respecto al jugador

    void Start() // Se ejecuta al iniciar la escena
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform; // Busca el objeto con tag "Player"
    }

    void LateUpdate() // Se ejecuta después de Update (ideal para cámara)
    {
        if (player == null) return; // Si no hay jugador, no hace nada

        transform.position = player.position + offset; // Mueve la cámara siguiendo al jugador con offset
    }
}