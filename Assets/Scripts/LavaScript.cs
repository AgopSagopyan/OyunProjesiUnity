using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaScript : MonoBehaviour
{
    public string sceneName = "DeathScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}