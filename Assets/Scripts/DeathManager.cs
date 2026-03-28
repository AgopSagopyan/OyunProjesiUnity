using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject deathScreen;

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);

        // Oyunu durdur
        Time.timeScale = 0f;

        // Fareyi göster ve kilidini aç
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // tekrar aç

        // Fareyi tekrar kilitle ve gizle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}