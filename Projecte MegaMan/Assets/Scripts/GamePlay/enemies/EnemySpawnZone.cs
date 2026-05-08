using UnityEngine;

public class EnemySpawnZone : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnCooldown = 2f;

    private bool playerInside;
    private bool canSpawn = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = true;

        Spawn();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = false;
    }

    void Spawn()
    {
        if (!playerInside || !canSpawn) return;

        canSpawn = false;

        // 📌 POSICIÓN: borde derecho de la cámara
        Camera cam = Camera.main;
        Vector3 rightEdge = cam.ViewportToWorldPoint(new Vector3(1.1f, 0.5f, 10f));

        Vector3 spawnPos = new Vector3(rightEdge.x, Random.Range(-1f, 2f), 0f);

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // dirección izquierda
        if (enemy.TryGetComponent(out PepePeng pp))
        {
            pp.direction = -1;
        }

        Invoke(nameof(ResetSpawn), spawnCooldown);
    }

    void ResetSpawn()
    {
        canSpawn = true;

        if (playerInside)
            Spawn();
    }
}