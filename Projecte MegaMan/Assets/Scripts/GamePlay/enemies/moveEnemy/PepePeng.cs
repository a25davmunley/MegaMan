using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PepePeng : MonoBehaviour
{
    public float speed = 3f;
    public float amplitude = 1f;
    public float frequency = 2f;

    public int direction = -1;

    private Vector3 startPos;
    private float offset;

    void Start()
    {
        Vector3 pos = transform.position;
        pos.z = 10f;
        transform.position = pos;
    }

    void Update()
    {
        // movimiento horizontal
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // vuelo sinusoidal independiente
        float y = Mathf.Sin((Time.time + offset) * frequency) * amplitude;

        transform.position = new Vector3(
            transform.position.x,
            startPos.y + y,
            transform.position.z
        );

        // destruir fuera de cámara
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x < -0.3f || viewPos.x > 1.3f)
        {
            Destroy(gameObject);
        }
    }
}