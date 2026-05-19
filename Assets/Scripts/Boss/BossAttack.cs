using UnityEngine;

public class BossRadialShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;

    [Tooltip("How many projectiles will be spawned in a full circle")]
    public int projectileCount = 16;

    [Tooltip("Speed of the projectile")]
    public float projectileSpeed = 10f;

    [Tooltip("Distance from boss before projectile spawns")]
    public float spawnRadius = 1.5f;

    [Header("Attack Settings")]
    [Tooltip("Time between each radial attack")]
    public float attackInterval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= attackInterval)
        {
            Shoot360();
            timer = 0f;
        }
    }

    void Shoot360()
    {
        if (projectilePrefab == null)
        {
            Debug.LogWarning("Projectile Prefab is missing!");
            return;
        }

        float angleStep = 360f / projectileCount;

        for (int i = 0; i < projectileCount; i++)
        {
            float angle = i * angleStep;

            // Convert angle to direction on XZ plane only
            Vector3 direction = new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                0f,
                Mathf.Sin(angle * Mathf.Deg2Rad)
            ).normalized;

            // Spawn around the boss
            Vector3 spawnPosition = transform.position + direction * spawnRadius;

            GameObject projectile = Instantiate(
                projectilePrefab,
                spawnPosition,
                Quaternion.LookRotation(direction)
            );

            // Give velocity if Rigidbody exists
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = direction * projectileSpeed;
            }
        }
    }
}