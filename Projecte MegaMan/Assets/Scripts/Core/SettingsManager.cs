using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// Sistema global de configuración del juego
public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    // Singleton: permite acceso global desde cualquier script

    [Header("AudioMixer")]
    public AudioMixer audioMixer;
    // AudioMixer de Unity para controlar volúmenes correctamente

    [Header("Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private const string MASTER_KEY = "MasterVol";
    private const string MUSIC_KEY = "MusicVol";
    private const string SFX_KEY = "SFXVol";

    private void Awake()
    {
        // Singleton básico
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadSettings();
    }

    // =========================
    // 🎚️ MASTER VOLUME
    // =========================
    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(MASTER_KEY, value);
    }

    // =========================
    // 🎵 MUSIC VOLUME
    // =========================
    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(MUSIC_KEY, value);
    }

    // =========================
    // 💥 SFX VOLUME
    // =========================
    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat(SFX_KEY, value);
    }

    // =========================
    // 📥 LOAD SETTINGS
    // =========================
    private void LoadSettings()
    {
        SetMasterVolume(PlayerPrefs.GetFloat(MASTER_KEY, 0.5f));
        SetMusicVolume(PlayerPrefs.GetFloat(MUSIC_KEY, 0.5f));
        SetSFXVolume(PlayerPrefs.GetFloat(SFX_KEY, 0.5f));
    }

    // =========================
    // 🔄 RESET SETTINGS
    // =========================
    public void ResetSettings()
    {
        SetMasterVolume(0.5f);
        SetMusicVolume(0.5f);
        SetSFXVolume(0.5f);

        PlayerPrefs.DeleteKey(MASTER_KEY);
        PlayerPrefs.DeleteKey(MUSIC_KEY);
        PlayerPrefs.DeleteKey(SFX_KEY);
    }
}