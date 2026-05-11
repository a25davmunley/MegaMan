using UnityEngine;

public class PepePeng : MonoBehaviour
{
    public float speed = 3f;
    public float amplitude = 1f;
    public float frequency = 2f;

    public int direction = -1;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // movimiento horizontal
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // movimiento vertical en onda (FLY)
        float y = Mathf.Sin(Time.time * frequency) * amplitude;

        transform.position = new Vector3(
            transform.position.x,
            startPos.y + y,
            transform.position.z
        );

        // destruir fuera de cámara
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x < -0.2f || viewPos.x > 1.2f)
        {
            Destroy(gameObject);
        }
    }
}