using UnityEngine; // Importa la librería principal de Unity
using UnityEngine.InputSystem; // Importa el sistema de input nuevo

public class PlayerInputHandler : MonoBehaviour, PlayerInputAction.IPlayerActions // Maneja la entrada del jugador
{
    private PlayerInputAction inputActions; // Sistema de input generado por Unity

    public Vector2 MoveInput { get; private set; } // Input de movimiento (horizontal y vertical)
    public bool JumpPressed { get; private set; } // Indica si se ha pulsado salto

    private float jumpBufferTime = 0.1f; // Tiempo de buffer para salto (permite saltar aunque sea ligeramente tarde)
    private float jumpTimer; // Temporizador del buffer de salto

    void Awake() // Se ejecuta al iniciar el objeto
    {
        inputActions = new PlayerInputAction(); // Inicializa el sistema de input
        inputActions.Player.SetCallbacks(this); // Asigna este script como receptor de inputs
        inputActions.Player.Enable(); // Activa el input del jugador
    }

    void Update() // Se ejecuta cada frame
    {
        if (JumpPressed) // Si se ha pulsado salto en este frame
        {
            jumpTimer = jumpBufferTime; // Reinicia el buffer de salto
        }

        if (jumpTimer > 0) // Si el buffer está activo
            jumpTimer -= Time.deltaTime; // Lo reduce con el tiempo
    }

    public bool ConsumeJump() // Método para consumir el salto (usado por el controlador del jugador)
    {
        if (jumpTimer > 0) // Si hay salto disponible en buffer
        {
            jumpTimer = 0; // Lo consume
            return true; // Permite saltar
        }
        return false; // No hay salto disponible
    }

    public void OnMove(InputAction.CallbackContext context) // Input de movimiento
    {
        MoveInput = context.ReadValue<Vector2>(); // Lee el vector de movimiento
    }

    public void OnJump(InputAction.CallbackContext context) // Input de salto
    {
        if (context.performed) // Cuando la acción se ejecuta
        {
            JumpPressed = true; // Marca que se ha pulsado salto
        }
    }

    void LateUpdate() // Se ejecuta al final del frame
    {
        JumpPressed = false; // Resetea el input de salto cada frame
    }

    public void OnPausa(InputAction.CallbackContext context) { } // Input vacío (pausa)
    public void OnPaneldepoderes(InputAction.CallbackContext context) { } // Input vacío
    public void OnPoderes(InputAction.CallbackContext context) { } // Input vacío
}