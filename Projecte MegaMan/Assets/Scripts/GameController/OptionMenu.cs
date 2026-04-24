using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("Sliders")]
    public Slider volumenGeneral;
    public Slider volumenMusica;
    public Slider volumenEfectos;

    private float defaultGeneral = 50f;
    private float defaultMusica = 50f;
    private float defaultEfectos = 50f;

    void Start()
    {
        LoadValues();
        ApplyAllVolumes();
    }

    public void SetVolumenGeneral(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("General", value);
    }

    public void SetVolumenMusica(float value)
    {
        PlayerPrefs.SetFloat("Musica", value);
    }

    public void SetVolumenEfectos(float value)
    {
        PlayerPrefs.SetFloat("Efectos", value);
    }

    void ApplyAllVolumes()
    {
        AudioListener.volume = volumenGeneral.value;
    }

    public void RestaurarPredeterminados()
    {
        volumenGeneral.value = defaultGeneral;
        volumenMusica.value = defaultMusica;
        volumenEfectos.value = defaultEfectos;

        PlayerPrefs.DeleteAll();
        ApplyAllVolumes();
    }

    void LoadValues()
    {
        volumenGeneral.value = PlayerPrefs.GetFloat("General", 50f);
        volumenMusica.value = PlayerPrefs.GetFloat("Musica", 50f);
        volumenEfectos.value = PlayerPrefs.GetFloat("Efectos", 50f);
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu Principal");
        Debug.Log("BOTÓN FUNCIONA");
    }
}