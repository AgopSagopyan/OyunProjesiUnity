using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager1 : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject deathPanel;

    void Start()
    {
        deathPanel.SetActive(false);
    }

    void Update()
    {
        if (playerStats.currentHealth <= 0)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}