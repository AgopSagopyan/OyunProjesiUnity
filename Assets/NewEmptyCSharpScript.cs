using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;

    public TMP_Text volumeText;
    public TMP_Text fullscreenText;

    void Start()
    {
        // Yazılar
        volumeText.text = "SES DÜZEYİ";
        fullscreenText.text = "FULL EKRAN";

        // Başlangıç değerleri
        volumeSlider.value = AudioListener.volume;
        fullscreenToggle.isOn = Screen.fullScreen;

        // Dinleyiciler
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}