using UnityEngine;

public class RazyBody : MonoBehaviour
{
    public float speed = 2f;
    public float lifeTime = 3f;

    private Rigidbody2D rb;
    private int direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        CrazyRazy parent = FindObjectOfType<CrazyRazy>();

        if (parent != null)
        {
            direction = -1;
        }

        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * speed, 0f);

        CheckTouch();
    }

    void CheckTouch()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.transform.position);

        if (dist <= 1f)
        {
            Debug.Log("se toca si");
        }
    }
}