using UnityEngine;

public class BossShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform bossShootPoint;

    public Transform player;

    void Shoot()
    {
        GameObject proj = Instantiate(projectilePrefab, bossShootPoint.position, Quaternion.identity);

        Vector2 dir = (player.position - bossShootPoint.position).normalized;

        proj.GetComponent<Rigidbody2D>().velocity = dir * 6f;
    }
}