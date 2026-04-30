using UnityEngine;

public class CrazyRazy : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 3f;
    public float speed = 2f;

    public GameObject headPrefab;
    public GameObject bodyPrefab;

    private bool activated = false;

    void Update()
    {
        if (player == null || activated) return;

        Move();

        float dist = Vector2.Distance(transform.position, player.position);
        if (dist < triggerDistance)
        {
            Split();
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
}