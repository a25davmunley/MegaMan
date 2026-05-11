using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour, PlayerInputAction.IPlayerActions
{
    private PlayerInputAction inputActions;

    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    private float jumpBufferTime = 0.1f;
    private float jumpTimer;

    void Awake()
    {
        inputActions = new PlayerInputAction();
        inputActions.Player.SetCallbacks(this);
        inputActions.Player.Enable();
    }

    void Update()
    {
        if (JumpPressed)
        {
            jumpTimer = jumpBufferTime;
        }

        if (jumpTimer > 0)
            jumpTimer -= Time.deltaTime;
    }

    public bool ConsumeJump()
    {
        if (jumpTimer > 0)
        {
            jumpTimer = 0;
            return true;
        }
        return false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpPressed = true;
        }
    }

    void LateUpdate()
    {
        JumpPressed = false;
    }

    public void OnPausa(InputAction.CallbackContext context) { }
    public void OnPaneldepoderes(InputAction.CallbackContext context) { }
    public void OnPoderes(InputAction.CallbackContext context) { }
}