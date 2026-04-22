using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MundoDeHielo");
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}