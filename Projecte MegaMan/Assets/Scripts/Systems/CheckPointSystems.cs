using UnityEngine; // Importa la librería principal de Unity

public class Checkpoint : MonoBehaviour // Clase que gestiona un checkpoint del jugador
{
    private const string CheckpointKey = "CheckpointPosition"; // Clave base para guardar la posición

    private void OnTriggerEnter(Collider other) // Se ejecuta cuando algo entra en el trigger (3D)
    {
        if (!other.CompareTag("Player")) return; // Solo responde si es el jugador

        SaveCheckpoint(); // Guarda el checkpoint
    }

    private void SaveCheckpoint() // Guarda la posición del checkpoint
    {
        Vector3 pos = transform.position; // Obtiene la posición del checkpoint

        PlayerPrefs.SetFloat(CheckpointKey + "X", pos.x); // Guarda coordenada X
        PlayerPrefs.SetFloat(CheckpointKey + "Y", pos.y); // Guarda coordenada Y
        PlayerPrefs.SetFloat(CheckpointKey + "Z", pos.z); // Guarda coordenada Z

        PlayerPrefs.Save(); // Fuerza el guardado en disco
    }
}