using UnityEngine; // Importa la librería principal de Unity
using UnityEngine.Audio; // Permite usar AudioMixer
using UnityEngine.UI; // Permite usar UI como sliders

// Sistema global de configuración del juego
public class SettingsManager : MonoBehaviour // Clase que gestiona opciones del juego
{
    public static SettingsManager Instance; // Singleton: acceso global a esta clase

    [Header("AudioMixer")] // Sección en el Inspector
    public AudioMixer audioMixer; // Controlador de audio global

    [Header("Sliders")] // Sección UI en el Inspector
    public Slider masterSlider; // Slider volumen master
    public Slider musicSlider; // Slider música
    public Slider sfxSlider; // Slider efectos

    private const string MASTER_KEY = "MasterVol"; // Clave de guardado master
    private const string MUSIC_KEY = "MusicVol"; // Clave de guardado música
    private const string SFX_KEY = "SFXVol"; // Clave de guardado SFX

    private void Awake() // Se ejecuta antes de Start
    {
        // Singleton básico
        if (Instance != null) // Si ya existe una instancia
        {
            Destroy(gameObject); // Elimina duplicado
            return;
        }

        Instance = this; // Asigna esta instancia como única
        DontDestroyOnLoad(gameObject); // No se destruye al cambiar de escena
    }

    private void Start() // Se ejecuta al iniciar el juego
    {
        LoadSettings(); // Carga configuración guardada
    }

    // =========================
    // 🎚️ MASTER VOLUME
    // =========================
    public void SetMasterVolume(float value) // Ajusta volumen master
    {
        audioMixer.SetFloat("Master", Mathf.Log10(value) * 20); // Convierte a escala dB
        PlayerPrefs.SetFloat(MASTER_KEY, value); // Guarda valor
    }

    // =========================
    // 🎵 MUSIC VOLUME
    // =========================
    public void SetMusicVolume(float value) // Ajusta volumen música
    {
        audioMixer.SetFloat("Music", Mathf.Log10(value) * 20); // Convierte a dB
        PlayerPrefs.SetFloat(MUSIC_KEY, value); // Guarda valor
    }

    // =========================
    // 💥 SFX VOLUME
    // =========================
    public void SetSFXVolume(float value) // Ajusta volumen efectos
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20); // Convierte a dB
        PlayerPrefs.SetFloat(SFX_KEY, value); // Guarda valor
    }

    // =========================
    // 📥 LOAD SETTINGS
    // =========================
    private void LoadSettings() // Carga ajustes guardados
    {
        SetMasterVolume(PlayerPrefs.GetFloat(MASTER_KEY, 0.5f)); // Carga master o valor por defecto
        SetMusicVolume(PlayerPrefs.GetFloat(MUSIC_KEY, 0.5f)); // Carga música o default
        SetSFXVolume(PlayerPrefs.GetFloat(SFX_KEY, 0.5f)); // Carga SFX o default
    }

    // =========================
    // 🔄 RESET SETTINGS
    // =========================
    public void ResetSettings() // Reinicia configuración
    {
        SetMasterVolume(0.5f); // Valor por defecto master
        SetMusicVolume(0.5f); // Valor por defecto música
        SetSFXVolume(0.5f); // Valor por defecto SFX

        PlayerPrefs.DeleteKey(MASTER_KEY); // Borra master guardado
        PlayerPrefs.DeleteKey(MUSIC_KEY); // Borra música guardada
        PlayerPrefs.DeleteKey(SFX_KEY); // Borra SFX guardado
    }
}