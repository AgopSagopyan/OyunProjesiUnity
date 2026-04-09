using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public Toggle vsyncToggle;

    void Start()
    {
        LoadSettings();
    }

    // AYARLARI YÜKLE
    void LoadSettings()
    {
        // Ses
        float volume = PlayerPrefs.GetFloat("volume", 1f);
        volumeSlider.value = volume;
        AudioListener.volume = volume;

        // Fullscreen
        bool fullscreen = PlayerPrefs.GetInt("fullscreen", 1) == 1;
        fullscreenToggle.isOn = fullscreen;
        Screen.fullScreen = fullscreen;

        // VSync
        bool vsync = PlayerPrefs.GetInt("vsync", 1) == 1;
        vsyncToggle.isOn = vsync;
        QualitySettings.vSyncCount = vsync ? 1 : 0;
    }

    // SES DEĞİŞTİR
    public void ChangeVolume(float value)
    {
        AudioListener.volume = value;
    }

    // FULLSCREEN
    public void ToggleFullscreen(bool isOn)
    {
        Screen.fullScreen = isOn;
    }

    // VSYNC
    public void ToggleVSync(bool isOn)
    {
        QualitySettings.vSyncCount = isOn ? 1 : 0;
    }

    // KAYDET BUTONU
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.SetInt("fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("vsync", vsyncToggle.isOn ? 1 : 0);

        PlayerPrefs.Save();
        Debug.Log("Ayarlar kaydedildi!");
    }

    // GERİ BUTONU
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
