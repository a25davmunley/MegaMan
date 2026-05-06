using UnityEngine;
// Importa funcionalidades básicas de Unity (Vector2, MonoBehaviour, etc.)

public class VisualCursor : MonoBehaviour
// Script que controla un cursor visual personalizado en pantalla.
{
    public RectTransform cursor;
    // Referencia al objeto UI que actúa como cursor.
    // RectTransform se usa en interfaces (UI), no en mundo 3D.

    public float speed = 20f;
    // Velocidad con la que el cursor sigue al ratón.
    // Más alto = más rápido, más bajo = más suave.

    private void Start()
    // Se ejecuta al iniciar la escena.
    {
        Cursor.visible = false;
        // Oculta el cursor real del sistema operativo.

        Cursor.lockState = CursorLockMode.Confined;
        // Bloquea el cursor dentro de la ventana del juego.
        // Evita que se salga de la pantalla.
    }

    private void Update()
    // Se ejecuta cada frame.
    {
        MoveCursor();
        // Separa la lógica en un método para mantener el código limpio.
    }

    private void MoveCursor()
    // Controla el movimiento suave del cursor visual.
    {
        cursor.position = Vector2.Lerp(
            cursor.position,
            Input.mousePosition,
            Time.deltaTime * speed
        );
        // Lerp = interpolación suave entre dos puntos.

        // cursor.position → posición actual del cursor visual
        // Input.mousePosition → posición real del ratón
        // Time.deltaTime * speed → suavidad dependiente del tiempo
    }
}