using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private PlayerInputHandler input;
    private Animator animator;

    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Detectar suelo
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundDistance,
            groundLayer
        );

        animator.SetBool("EnSuelo", isGrounded);

        // 🔥 SALTO REAL
        if (input.JumpPressed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            animator.SetTrigger("Jump");
        }
    }

    void FixedUpdate()
    {
        float x = input.MoveInput.x;

        Vector2 velocity = rb.velocity;
        velocity.x = x * speed;

        rb.velocity = velocity;
    }
}