using UnityEngine;

public class IcemanAI : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 2f;
    public Transform leftPoint;
    public Transform rightPoint;

    [Header("Disparo")]
    public GameObject iceProjectile;
    public Transform shootPoint;
    public float shootCooldown = 2f;

    private Rigidbody2D rb;
    private bool movingRight = true;
    private float shootTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shootTimer = shootCooldown;
    }

    void Update()
    {
        Patrol();
        ShootLogic();
    }

    void Patrol()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            if (transform.position.x >= rightPoint.position.x)
                Flip();
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

            if (transform.position.x <= leftPoint.position.x)
                Flip();
        }
    }

    void ShootLogic()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootCooldown;
        }
    }

    void Shoot()
    {
        if (iceProjectile == null || shootPoint == null) return;

        Instantiate(iceProjectile, shootPoint.position, Quaternion.identity);
    }

    void Flip()
    {
        movingRight = !movingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}