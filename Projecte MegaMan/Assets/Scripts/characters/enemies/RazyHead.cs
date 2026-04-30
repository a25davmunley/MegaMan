using UnityEngine;

public class RazyHead : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float arcHeight = 2f;

    private Vector2 startPos;
    private Vector2 targetPos;
    private float t;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        t += Time.deltaTime * speed;

        targetPos = player.position;

        // movimiento base hacia el jugador
        Vector2 linear = Vector2.Lerp(startPos, targetPos, t);

        // arco en U
        float arc = Mathf.Sin(t * Mathf.PI) * arcHeight;

        transform.position = new Vector2(linear.x, linear.y + arc);

        // reset cuando llega
        if (t >= 1f)
        {
            startPos = transform.position;
            t = 0f;
        }
    }
}