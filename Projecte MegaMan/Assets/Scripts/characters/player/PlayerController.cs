using UnityEngine; // Importa la librería principal de Unity
using UnityEngine.InputSystem; // Importa el nuevo sistema de input de Unity

public class PlayerController : MonoBehaviour, PlayerInputAction.IPlayerActions // Controlador del jugador e interfaz de inputs
{
    private PlayerInputAction inputActions; // Referencia al sistema de inputs generado
    private Rigidbody2D rb; // Referencia al Rigidbody2D del jugador

    public float speed = 5f; // Velocidad de movimiento horizontal
    public float jumpForce = 7f; // Fuerza del salto

    public Transform startSpawn; // Punto inicial de spawn del jugador

    private float moveX; // Valor de entrada horizontal

    [Header("Ground Check")] // Sección visual en el Inspector
    public Transform groundCheck; // Punto para comprobar si está en el suelo
    public float groundRadius = 0.4f; // Radio de detección de suelo
    public LayerMask groundLayer; // Capa que se considera suelo

    private bool isGrounded; // Indica si el jugador está en el suelo

    [Header("Animacion")] // Sección de animación

    private Animator animator; // Referencia al Animator
    private SpriteRenderer sprite; // Referencia al SpriteRenderer

    private void Awake() // Se ejecuta al crear el objeto
    {
        inputActions = new PlayerInputAction(); // Inicializa el sistema de input
        inputActions.Player.SetCallbacks(this); // Asigna este script como receptor de inputs

        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D del jugador
    }

    private void Start() // Se ejecuta al inicio del juego
    {
        sprite = GetComponent<SpriteRenderer>(); // Obtiene el SpriteRenderer

        if (startSpawn != null) // Si hay punto de spawn asignado
        {
            transform.position = startSpawn.position; // Coloca al jugador en el spawn
        }
        else // Si no hay spawn asignado
        {
            Debug.LogError("StartSpawn no asignado en el Inspector"); // Muestra error
        }

        animator = GetComponent<Animator>(); // Obtiene el Animator
    }

    private void OnEnable() // Se activa cuando el objeto se habilita
    {
        if (inputActions == null) // Si no está inicializado
        {
            inputActions = new PlayerInputAction(); // Lo crea
            inputActions.Player.SetCallbacks(this); // Asigna callbacks
        }

        inputActions.Enable(); // Activa el sistema de input
    }

    private void OnDisable() // Se ejecuta al desactivar el objeto
    {
        inputActions.Disable(); // Desactiva inputs
    }

    private void Update() // Se ejecuta cada frame
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f); // Fuerza Z a 0

        CheckGround(); // Comprueba si está en el suelo
        Move(); // Aplica movimiento

        animator.SetFloat("Horizontal", Mathf.Abs(moveX)); // Actualiza animación de movimiento
        animator.SetBool("EnSuelo", isGrounded); // Actualiza estado de suelo

        if (moveX > 0) // Si se mueve a la derecha
        {
            sprite.flipX = false; // Mira a la derecha
        }
        else if (moveX < 0) // Si se mueve a la izquierda
        {
            sprite.flipX = true; // Mira a la izquierda
        }
    }

    private void Move() // Movimiento del jugador
    {
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y); // Aplica velocidad horizontal
    }

    private void CheckGround() // Comprueba si está tocando el suelo
    {
        isGrounded = Physics2D.OverlapCircle( // Detecta colisión circular
            groundCheck.position, // Posición del chequeo
            groundRadius, // Radio
            groundLayer // Capa de suelo
        );
    }

    public void OnMove(InputAction.CallbackContext context) // Input de movimiento
    {
        moveX = context.ReadValue<Vector2>().x; // Lee eje horizontal
    }

    public void OnJump(InputAction.CallbackContext context) // Input de salto
    {
        if (context.started && isGrounded) // Si se presiona y está en el suelo
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplica salto
        }
    }

    public void OnPausa(InputAction.CallbackContext context) { } // Input vacío (pausa)
    public void OnPaneldepoderes(InputAction.CallbackContext context) { } // Input vacío
    public void OnPoderes(InputAction.CallbackContext context) { } // Input vacío

    private void OnDrawGizmosSelected() // Dibuja gizmos en el editor
    {
        if (groundCheck == null) return; // Evita errores si no está asignado

        Gizmos.color = Color.red; // Color del gizmo
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius); // Dibuja radio de suelo
    }
}