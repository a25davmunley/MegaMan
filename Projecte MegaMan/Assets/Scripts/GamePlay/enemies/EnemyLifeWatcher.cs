using UnityEngine; // Importa la librería principal de Unity

public class EnemyLifeWatcher : MonoBehaviour // Clase que vigila la vida/muerte del enemigo
{
    private EnemySpawnZone zone; // Referencia a la zona de spawn que controla este enemigo

    public void Init(EnemySpawnZone z) // Método de inicialización para asignar la zona
    {
        zone = z; // Guarda la referencia de la zona de spawn
    }

    void OnDestroy() // Se ejecuta cuando el objeto es destruido
    {
        if (zone != null) // Comprueba que la zona existe
            zone.OnEnemyDeath(); // Notifica a la zona que este enemigo ha muerto
    }
}