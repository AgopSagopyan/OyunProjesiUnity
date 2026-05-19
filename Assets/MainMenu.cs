using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings Açıldı");
    }

    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("Oyundan Çıkıldı");
    }
}
