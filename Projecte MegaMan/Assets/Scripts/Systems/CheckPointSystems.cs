using UnityEngine;
// Importa la librería principal de Unity.
// Permite usar MonoBehaviour, Transform, Collider, etc.

public class Checkpoint : MonoBehaviour
// Declara una clase llamada Checkpoint que hereda de MonoBehaviour.
// Esto permite que el script se pueda poner en un GameObject y usar eventos de Unity.
{
    private const string CheckpointKey = "CheckpointPosition";
    // Constante que guarda la “clave” con la que se almacenará el checkpoint.
    // Se usa const para evitar errores de escritura y centralizar el valor.

    private void OnTriggerEnter(Collider other)
    // Método automático de Unity.
    // Se ejecuta cuando otro collider entra en el collider marcado como "Trigger".
    // "other" es el objeto que ha entrado en el trigger.
    {
        if (!other.CompareTag("Player")) return;
        // Comprueba si el objeto que entró NO es el Player.
        // Si no es el Player, sale del método inmediatamente (early return).
        // Esto evita código anidado y mejora legibilidad.

        SaveCheckpoint();
        // Llama a un método separado que se encarga de guardar el checkpoint.
        // Se separa la lógica para que el código sea más limpio y escalable.
    }

    private void SaveCheckpoint()
    // Método privado que encapsula la lógica de guardado del checkpoint.
    // Separar lógica aquí permite reutilización y mejor organización.
    {
        Vector3 pos = transform.position;
        // Obtiene la posición actual del objeto (checkpoint) en el mundo.

        string serialized = $"{pos.x},{pos.y},{pos.z}";
        // Convierte la posición (Vector3) a un string.
        // Se guardan los valores X, Y, Z separados por comas.

        PlayerPrefs.SetString(CheckpointKey, serialized);
        // Guarda la posición en el sistema PlayerPrefs.
        // Se almacena como string usando la clave definida arriba.
        // PlayerPrefs es persistente entre sesiones del juego.
    }
}