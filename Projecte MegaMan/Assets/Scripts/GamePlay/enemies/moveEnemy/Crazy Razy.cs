using UnityEngine;

public class CrazyRazy : MonoBehaviour
{
    public Transform player;

    public float detectRange = 6f;
    public float splitRange = 1.2f;

    public float speed = 3f;

    public GameObject headPrefab;
    public GameObject bodyPrefab;

    private Rigidbody2D rb;

    private bool activated;
    private bool chasing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!player || activated) return;

        float dist = Vector2.Distance(transform.position, player.position);

        chasing = dist <= detectRange;

        if (dist <= splitRange)
        {
            Debug.Log("se toca");

            Split();
        }
    }

    void FixedUpdate()
    {
        if (!chasing || activated) return;

        Vector2 dir = (player.position - transform.position).normalized;

        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    void Split()
    {
        activated = true;

        Instantiate(headPrefab, transform.position, Quaternion.identity);
        Instantiate(bodyPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}