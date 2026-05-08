using UnityEngine;

public class EnemySpawnZone : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    private bool playerInside;
    private GameObject currentEnemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTRÓ: " + other.name);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    void TrySpawn()
    {
        if (!playerInside) return;

        // ❌ evita múltiples enemigos
        if (currentEnemy != null) return;

        Vector3 pos = spawnPoint != null
            ? spawnPoint.position
            : transform.position;

        currentEnemy = Instantiate(enemyPrefab, pos, Quaternion.identity);

        currentEnemy.AddComponent<EnemyLifeWatcher>().Init(this);
    }

    public void OnEnemyDeath()
    {
        currentEnemy = null;

        if (playerInside)
        {
            TrySpawn();
        }
    }
}