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
        // 1. Leemos input horizontal
        float x = input.MoveInput.x;

        // 2. Mantenemos la velocidad vertical intacta (IMPORTANTE)
        Vector2 velocity = rb.velocity;

        // 3. Aplicamos solo movimiento horizontal
        velocity.x = x * speed;

        // 4. Aplicamos al rigidbody
        rb.velocity = velocity;
    }
}