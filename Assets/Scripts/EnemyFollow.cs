using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;   // Takip edilecek karakter
    public float speed = 5f;   // Takip hızı
    public float stoppingDistance = 1.5f; // Düşmanın duracağı mesafe

    void Update()
    {
        if (player == null)
            return;

        // Oyuncuya olan mesafeyi hesapla
        float distance = Vector3.Distance(transform.position, player.position);

        // Eğer mesafe durma mesafesinden büyükse takip et
        if (distance > stoppingDistance)
        {
            // Düşmanı oyuncuya doğru hareket ettir
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Düşmanı oyuncuya bakacak şekilde döndür
            transform.LookAt(player);
        }
    }
}