using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Cargando nivel...");
        SceneManager.LoadScene("MundoDeHielo");
    }

    public void Options()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("Option");
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}