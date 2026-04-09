using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    void Start()
    {
        // Mouse aç
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Oyun durdur 
        Time.timeScale = 0f;
    }

    //  YENİDEN DOĞ
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EpisodeTest"); 
    }

    // ANA MENÜ
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}