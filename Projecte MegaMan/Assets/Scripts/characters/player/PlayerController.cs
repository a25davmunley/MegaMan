using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInputAction.IPlayerActions
{
    private PlayerInputAction inputActions;
    private Rigidbody2D rb;

    public float speed = 5f;
    public float jumpForce = 7f;

    private float moveX;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;

    private void Awake()
    {
        inputActions = new PlayerInputAction();
        inputActions.Player.SetCallbacks(this);

        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Transform spawn = GameObject.Find("StartPoint").transform;
        transform.position = spawn.position;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        CheckGround();
        Move();
        
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveX = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void OnPausa(InputAction.CallbackContext context) { }
    public void OnPaneldepoderes(InputAction.CallbackContext context) { }
    public void OnPoderes(InputAction.CallbackContext context) { }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}