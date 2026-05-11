using UnityEngine; // Importa la librería principal de Unity
using UnityEngine.InputSystem; // Importa el sistema de input nuevo

public class PauseManager : MonoBehaviour // Clase que controla el sistema de pausa del juego
{
    public GameObject pauseMenu; // Referencia al menú de pausa

    private bool isPaused; // Estado del juego (pausado o no)

    public void OnPausa(InputAction.CallbackContext context) // Input de pausa
    {
        if (!context.performed) return; // Solo ejecuta cuando la acción se completa

        isPaused = !isPaused; // Cambia el estado de pausa

        if (isPaused) // Si está pausado
            Pause(); // Activa pausa
        else // Si no está pausado
            Resume(); // Reanuda el juego
    }

    void Pause() // Método para pausar el juego
    {
        Time.timeScale = 0f; // Congela el tiempo del juego
        pauseMenu.SetActive(true); // Muestra el menú de pausa

        Cursor.lockState = CursorLockMode.None; // Libera el cursor
        Cursor.visible = true; // Muestra el cursor
    }

    void Resume() // Método para reanudar el juego
    {
        Time.timeScale = 1f; // Vuelve el tiempo a la normalidad
        pauseMenu.SetActive(false); // Oculta el menú de pausa

        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false; // Oculta el cursor
    }
}