using UnityEngine;
// Importa funcionalidades básicas de Unity.

using UnityEngine.InputSystem;
// Importa el nuevo sistema de input de Unity.

public class PlayerInputHandler : MonoBehaviour, PlayerInputAction.IPlayerActions
// Este script SOLO se encarga de leer inputs del jugador.
// Implementa la interfaz generada por el Input System.
{
    private PlayerInputAction inputActions;
    // Contiene todas las acciones configuradas en el Input System.

    public Vector2 MoveInput { get; private set; }
    // Guarda el movimiento del jugador (horizontal y vertical).

    public bool JumpPressed { get; private set; }
    // Indica si el jugador ha presionado salto en este frame.

    private void Awake()
    // Se ejecuta al cargar el objeto, antes de Start.
    {
        inputActions = new PlayerInputAction();
        // Se crea la instancia del sistema de input.

        inputActions.Player.SetCallbacks(this);
        // Este script se registra como receptor de eventos de input.
    }

    private void OnEnable()
    // Cuando el objeto se activa.
    {
        inputActions.Enable();
        // Activa el sistema de input.
    }

    private void OnDisable()
    // Cuando el objeto se desactiva.
    {
        inputActions.Disable();
        // Desactiva el input para evitar errores o inputs fantasma.
    }

    public void OnMove(InputAction.CallbackContext context)
    // Se ejecuta cuando hay input de movimiento.
    {
        MoveInput = context.ReadValue<Vector2>();
        // Lee el valor del joystick o teclado.
    }

    public void OnJump(InputAction.CallbackContext context)
    // Se ejecuta cuando se presiona salto.
    {
        if (context.started)
        // Detecta SOLO el momento inicial del botón.
        {
            JumpPressed = true;
            // Activa salto durante este frame.
        }
    }

    private void LateUpdate()
    // Se ejecuta al final de cada frame.
    {
        JumpPressed = false;
        // Resetea el salto para que no se repita automáticamente.
    }

    public void OnPausa(InputAction.CallbackContext context) { }
    // Input reservado (pausa del juego).

    public void OnPaneldepoderes(InputAction.CallbackContext context) { }
    // Input reservado (UI futura).

    public void OnPoderes(InputAction.CallbackContext context) { }
    // Input reservado (habilidades futuras).
}