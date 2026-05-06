using UnityEngine;
// Importa funciones básicas de Unity (MonoBehaviour, Debug, etc.)

using UnityEngine.SceneManagement;
// Permite cambiar de escenas.

using UnityEngine.UI;
// Permite usar sliders de la interfaz.

public class OptionsMenu : MonoBehaviour
// Controla exclusivamente la UI del menú de opciones.
{
    [Header("Sliders")]
    // Organización visual en el Inspector.

    public Slider masterSlider;
    // Slider del volumen general.

    public Slider musicSlider;
    // Slider del volumen de música.

    public Slider sfxSlider;
    // Slider del volumen de efectos.

    private const string MASTER_KEY = "MasterVol";
    private const string MUSIC_KEY = "MusicVol";
    private const string SFX_KEY = "SFXVol";
    // Claves centralizadas para evitar errores de escritura en PlayerPrefs.

    private void Start()
    // Se ejecuta al abrir la escena.
    {
        LoadUI();
        // Carga los valores guardados en los sliders.
    }

    // =========================
    // 🎚️ EVENTS FROM SLIDERS
    // =========================

    public void OnMasterChanged(float value)
    // Se ejecuta cuando cambia el slider de master.
    {
        SettingsManager.Instance.SetMasterVolume(value);
        // Envía el valor al sistema global de audio.
    }

    public void OnMusicChanged(float value)
    // Se ejecuta cuando cambia el slider de música.
    {
        SettingsManager.Instance.SetMusicVolume(value);
        // Actualiza volumen de música.
    }

    public void OnSFXChanged(float value)
    // Se ejecuta cuando cambia el slider de efectos.
    {
        SettingsManager.Instance.SetSFXVolume(value);
        // Actualiza volumen de efectos.
    }

    // =========================
    // 📥 LOAD UI STATE
    // =========================

    private void LoadUI()
    // Sincroniza sliders con valores guardados.
    {
        masterSlider.value = PlayerPrefs.GetFloat(MASTER_KEY, 0.5f);
        // Carga volumen master (valor por defecto 0.5)

        musicSlider.value = PlayerPrefs.GetFloat(MUSIC_KEY, 0.5f);
        // Carga volumen música

        sfxSlider.value = PlayerPrefs.GetFloat(SFX_KEY, 0.5f);
        // Carga volumen efectos
    }

    // =========================
    // 🔄 RESET SETTINGS
    // =========================

    public void ResetOptions()
    // Restaura configuración por defecto.
    {
        SettingsManager.Instance.ResetSettings();
        // Resetea todo el sistema de audio global.

        LoadUI();
        // Refresca los sliders en pantalla.
    }

    // =========================
    // 🎮 BACK TO MENU
    // =========================

    public void BackToMenu()
    // Vuelve al menú principal.
    {
        SceneManager.LoadScene("Menu Principal");
        // Cambia a la escena del menú.
    }
}