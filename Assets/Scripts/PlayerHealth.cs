using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthBar;

    void Start()
    {
        // Başlangıçta oyuncunun canı tam dolu
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    // Oyuncu hasar aldığında çağrılan fonksiyon
    public void TakeDamage(float damage)
    {
        Debug.Log("Hasar Alındı: " + damage);  // Debugging için hasar bilgisini logla

        currentHealth -= damage;

        // Eğer sağlık 0'ın altına düşerse, 0 yapıyoruz
        if (currentHealth < 0)
            currentHealth = 0;

        // Sağlık barını güncelle
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
            Debug.Log("Sağlık Barı Güncelleniyor: " + healthBar.value);  // Debugging
        }

        // Oyuncunun öldüğü durumda yapılacak işlemler
        if (currentHealth <= 0)
        {
            Debug.Log("Player öldü!");
            // Burada oyuncu öldüğünde yapılacak şeyler eklenebilir (örneğin, oyun bitirme, animasyon vb.)
        }
    }
}