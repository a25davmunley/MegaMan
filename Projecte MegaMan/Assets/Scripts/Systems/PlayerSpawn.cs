using UnityEngine; // Importa la librería principal de Unity

public class PlayerSpawn : MonoBehaviour // Clase que gestiona el spawn del jugador
{
    public Transform startSpawn; // Punto de inicio por defecto

    private const string CheckpointKey = "CheckpointPosition"; // Clave base para cargar checkpoint

    void Start() // Se ejecuta al iniciar la escena
    {
        if (HasCheckpoint()) // Si existe un checkpoint guardado
        {
            transform.position = LoadCheckpoint(); // Coloca al jugador en el checkpoint
        }
        else // Si no hay checkpoint guardado
        {
            if (startSpawn != null) // Si hay spawn inicial asignado
            {
                transform.position = startSpawn.position; // Coloca al jugador en el spawn inicial
            }
            else // Si no hay spawn asignado
            {
                Debug.LogError("StartSpawn no asignado en el Inspector"); // Error en consola
            }
        }
    }

    private bool HasCheckpoint() // Comprueba si existe checkpoint guardado
    {
        return PlayerPrefs.HasKey(CheckpointKey + "X"); // Si existe la clave X, hay checkpoint
    }

    private Vector3 LoadCheckpoint() // Carga la posición del checkpoint
    {
        float x = PlayerPrefs.GetFloat(CheckpointKey + "X"); // Carga X
        float y = PlayerPrefs.GetFloat(CheckpointKey + "Y"); // Carga Y
        float z = PlayerPrefs.GetFloat(CheckpointKey + "Z"); // Carga Z

        return new Vector3(x, y, z); // Devuelve la posición completa
    }
}