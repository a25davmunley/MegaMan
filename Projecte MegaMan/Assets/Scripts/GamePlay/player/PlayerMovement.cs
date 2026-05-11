using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private PlayerInputHandler input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
    }

    void FixedUpdate()
    {
        float x = input.MoveInput.x;
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }
}