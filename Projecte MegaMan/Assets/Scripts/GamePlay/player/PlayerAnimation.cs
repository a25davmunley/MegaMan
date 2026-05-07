using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerInputHandler input;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [Header("Suelo")]
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (groundCheck == null) return;

        // Suelo
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundDistance,
            groundLayer
        );

        animator.SetBool("EnSuelo", isGrounded);

        // Salto
        if (input != null && input.JumpPressed && isGrounded)
        {
            animator.SetTrigger("Jump");
        }

        // 🔥 GIRO CORRECTO (SIN CAMBIAR ESCALA)
        Flip();
    }

    private void LateUpdate()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x));
    }

    private void Flip()
    {
        float moveX = input.MoveInput.x;

        if (moveX > 0.1f)
        {
            sprite.flipX = false;
        }
        else if (moveX < -0.1f)
        {
            sprite.flipX = true;
        }
    }
}