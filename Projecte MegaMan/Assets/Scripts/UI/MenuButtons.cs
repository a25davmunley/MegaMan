using UnityEngine;
// Importa funciones básicas de Unity (Debug, MonoBehaviour, etc.)

using UnityEngine.SceneManagement;
// Permite cambiar entre escenas del juego.

public class MenuButtons : MonoBehaviour
// Script que controla los botones del men?principal.
{
    [Header("Scenes")]
    // Solo organización visual en el Inspector.

    private const string GAME_SCENE = "MundoDeHielo";
    // Nombre de la escena del juego principal.
    // Usar constante evita errores de escritura.

    private const string OPTIONS_SCENE = "Option";
    // Nombre de la escena de opciones.

    public void StartGame()
    // Se ejecuta cuando el jugador pulsa "Start".
    {
        Debug.Log("Cargando nivel...");
        // Mensaje en consola para debug.

        SceneManager.LoadScene(GAME_SCENE);
        // Carga la escena principal del juego.
    }

    public void Options()
    // Se ejecuta cuando el jugador abre opciones.
    {
        Debug.Log("Options");
        // Debug simple para confirmar acción.

        SceneManager.LoadScene(OPTIONS_SCENE);
        // Cambia a la escena de opciones.
    }

    public void ExitGame()
    // Se ejecuta cuando el jugador quiere salir del juego.
    {
        Application.Quit();
        // Cierra el juego en build final.

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // Si estás en el editor, detiene el modo Play.
#endif
    }
}