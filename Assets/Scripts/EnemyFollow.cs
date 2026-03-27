using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;

    [Header("Hareket")]
    public float speed = 5f;
    public float stoppingDistance = 2f;

    [Header("Saldırı")]
    public GameObject hitboxPrefab;
    public float attackDistance = 2f;
    public float attackCooldown = 1.5f;
    public float hitboxLifetime = 0.3f;
    public float distanceInFront = 1.5f;

    private float lastAttackTime;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Oyuncuya dön (sadece yatay)
        Vector3 lookPos = player.position - transform.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.LookRotation(lookPos);

        // Takip et
        if (distance > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
        // Saldır
        else if (distance <= attackDistance)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                SpawnHitbox();
                lastAttackTime = Time.time;
            }
        }
    }

    void SpawnHitbox()
    {
        Vector3 spawnPos = transform.position + transform.forward * distanceInFront;

        GameObject weapon = Instantiate(hitboxPrefab, spawnPos, transform.rotation);

        Destroy(weapon, hitboxLifetime);
    }

    // Düşmanın oyuncuya vereceği hasar
    public float damageAmount = 20f;

    // Düşman objesi, oyuncuya çarptığında hasar verecek
    // Düşman objesi, oyuncuya çarptığında hasar verecek
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Düşman Oyuncuya Çarptı!");  // Debugging

            // Oyuncunun PlayerHealth bileşenini al
            PlayerHealth ph = other.GetComponent<PlayerHealth>();

            // Eğer PlayerHealth bileşeni varsa, hasar ver
            if (ph != null)
            {
                ph.TakeDamage(damageAmount);  // Hasar miktarını parametre olarak veriyoruz
            }
        }
    }
}