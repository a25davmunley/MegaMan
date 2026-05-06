using UnityEngine;
// Importa funcionalidades básicas de Unity (Transform, Vector3, MonoBehaviour, etc.)

public class PlayerSpawn : MonoBehaviour
// Este script controla dónde aparece el jugador al iniciar la partida.
{
    public Transform startSpawn;
    // Punto de spawn por defecto (si no hay checkpoint guardado).

    private const string CheckpointKey = "CheckpointPosition";
    // Clave única para leer el checkpoint guardado (evita errores de strings sueltos).

    void Start()
    // Se ejecuta al iniciar la escena.
    {
        if (PlayerPrefs.HasKey(CheckpointKey))
        // Comprueba si existe un checkpoint guardado en memoria.
        {
            transform.position = LoadCheckpoint();
            // Si existe, coloca al jugador en la posición guardada.
        }
        else
        {
            transform.position = startSpawn.position;
            // Si no hay checkpoint, usa el spawn inicial.
        }
    }

    private Vector3 LoadCheckpoint()
    // Método separado para leer y reconstruir la posición guardada.
    {
        float x = PlayerPrefs.GetFloat(CheckpointKey + "X");
        // Lee la coordenada X del checkpoint.

        float y = PlayerPrefs.GetFloat(CheckpointKey + "Y");
        // Lee la coordenada Y del checkpoint.

        float z = PlayerPrefs.GetFloat(CheckpointKey + "Z");
        // Lee la coordenada Z del checkpoint.

        return new Vector3(x, y, z);
        // Devuelve la posición completa reconstruida.
    }
}