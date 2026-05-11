using UnityEngine;
// Importa funcionalidades básicas de Unity (Vector2, MonoBehaviour, Input, etc.)

public class VisualCursor : MonoBehaviour
// Script que controla un cursor visual personalizado en la UI
{
    public RectTransform cursor;
    // Referencia al objeto UI que actúa como cursor visual

    public float speed = 20f;
    // Velocidad de seguimiento del cursor (más alto = más rápido, más bajo = más suave)

    private void Start()
    // Se ejecuta una vez al iniciar la escena
    {
        Cursor.visible = false;
        // Oculta el cursor real del sistema operativo

        Cursor.lockState = CursorLockMode.Confined;
        // Mantiene el cursor dentro de la ventana del juego
    }

    private void Update()
    // Se ejecuta cada frame
    {
        MoveCursor();
        // Llama al método que mueve el cursor visual
    }

    private void MoveCursor()
    // Controla el movimiento suave del cursor visual
    {
        cursor.position = Vector2.Lerp(
            cursor.position,        // posición actual del cursor UI
            Input.mousePosition,    // posición real del ratón
            Time.deltaTime * speed  // suavidad del movimiento
        );
    }
}