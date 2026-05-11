using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform playerShootPoint;

    private SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || playerShootPoint == null)
            return;

        GameObject proj = Instantiate(projectilePrefab, playerShootPoint.position, Quaternion.identity);

        MegaManProjectile bullet = proj.GetComponent<MegaManProjectile>();

        if (bullet == null)
            return;

        Vector2 dir = Vector2.right;

        if (sprite != null && sprite.flipX)
            dir = Vector2.left;

        bullet.SetDirection(dir);
    }
}