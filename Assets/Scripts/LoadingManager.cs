using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    public string sceneToLoad = "GameScene";

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
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
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
}