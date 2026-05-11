using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public Transform groundCheck;
    public float radius = 0.4f;
    public LayerMask groundLayer;

    public bool IsGrounded { get; private set; }

    void Update()
    {
        if (groundCheck == null)
        {
            IsGrounded = false;
            return;
        }

        IsGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            radius,
            groundLayer
        );
    }
}