using UnityEngine;

public class EnemyLifeWatcher : MonoBehaviour
{
    private EnemySpawnZone zone;

    public void Init(EnemySpawnZone z)
    {
        zone = z;
    }

    void OnDestroy()
    {
        if (zone != null)
            zone.OnEnemyDeath();
    }
}