using UnityEngine;

public class FootHolder : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 3f;

    public float minHeight = 1f;
    public float maxHeight = 4f;

    private float speed;
    private float height;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        speed = Random.Range(minSpeed, maxSpeed);
        height = Random.Range(minHeight, maxHeight);
    }

    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, height);

        transform.position = new Vector3(
            startPos.x,
            startPos.y + y,
            startPos.z
        );
    }
}