using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LoadingManager : MonoBehaviour
{

    public static string SceneToLoad = "GameScene";

    public Slider loadingBar;
    public TextMeshProUGUI progressText;
    public Image fillImage;

    // Yavaşlatma ayarı (arttır → daha yavaş)
    public float loadingSpeed = 0.5f;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneToLoad);
        operation.allowSceneActivation = false;

        float displayedProgress = 0f;

        while (!operation.isDone)
        {
            float realProgress = Mathf.Clamp01(operation.progress / 0.9f);

            // YAVAŞ DOLMA EFEKTİ
            displayedProgress = Mathf.MoveTowards(
                displayedProgress,
                realProgress,
                loadingSpeed * Time.deltaTime
            );

            // BAR
            loadingBar.value = displayedProgress;

            // YÜZDE
            progressText.text = "%" + (displayedProgress * 100f).ToString("F0");

            // 🎨 RENK (Kırmızı → Sarı → Yeşil)
            fillImage.color = Color.Lerp(
                Color.red,
                Color.green,
                Mathf.SmoothStep(0, 1, displayedProgress)
            );

            // TAMAMLANDI
            if (displayedProgress >= 1f)
            {
                yield return new WaitForSeconds(0.5f);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public static void Load(string sceneName)
    {
        SceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
}