using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private PlayerInputHandler input;
    private PlayerGroundCheck ground;

    private bool wasGrounded;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        input = GetComponent<PlayerInputHandler>();
        ground = GetComponent<PlayerGroundCheck>();

        wasGrounded = ground.IsGrounded;
    }

    void Update()
    {
        bool isGrounded = ground.IsGrounded;

        // ✔ TU PARÁMETRO (NO CAMBIADO)
        animator.SetBool("EnSuelo", isGrounded);

        // ✔ TU PARÁMETRO (NO CAMBIADO)
        animator.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x));

        // 🚀 SOLO DISPARA JUMP UNA VEZ (FIX REAL)
        if (isGrounded == false && wasGrounded == true)
        {
            animator.SetTrigger("Jump");
        }

        wasGrounded = isGrounded;

        Flip();
    }

    void Flip()
    {
        float moveX = input.MoveInput.x;

        if (moveX > 0.1f)
            sprite.flipX = false;
        else if (moveX < -0.1f)
            sprite.flipX = true;
    }
}