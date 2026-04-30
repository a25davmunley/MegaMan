using UnityEngine;

public class CrazyRazy : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 3f;
    public float timeToSplit = 2f;
    public float speed = 2f;

    public GameObject headPrefab;
    public GameObject bodyPrefab;

    private bool activated = false;
    private bool counting = false;
    private float timer = 0f;

    void Update()
    {
        if (player == null || activated) return;

        Move();

        // SOLO detecta una vez cuando entra en rango
        if (!counting)
        {
            float dist = Vector2.Distance(transform.position, player.position);

            if (dist < triggerDistance)
            {
                counting = true; // empieza el contador
            }
        }

        // una vez empieza, NO depende de distancia
        if (counting)
        {
            timer += Time.deltaTime;

            if (timer >= timeToSplit)
            {
                Split();
            }
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }

    void Split()
    {
        activated = true;

        Instantiate(headPrefab, transform.position, Quaternion.identity);
        Instantiate(bodyPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !counting)
        {
            counting = true;
        }
    }
}