using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private PlayerInputHandler input;
    private PlayerGroundCheck ground;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        ground = GetComponent<PlayerGroundCheck>();
    }

    void Update()
    {
        if (input.JumpPressed && ground.IsGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // 1. NO destruimos velocidad vertical completamente (IMPORTANTE FIX)
        rb.velocity = new Vector2(rb.velocity.x, 0f);

        // 2. Aplicamos impulso de salto
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}