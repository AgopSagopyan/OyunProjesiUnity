using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{

    [Header("Projectile Prefab")]
    public GameObject projectilePrefab;

    [Header("Ranged Attack Settings")] 
    public float damage = 10f;
    public float attackSpeed = 5f;
    public float lifeTime = 5f;

    private float nextFireTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextFireTime)
        {
            ThrowProjectile();

            float fireDelay = 1f/ Mathf.Max(attackSpeed, 0.1f);
            nextFireTime = Time.time + fireDelay;
        }
        
    }

    void ThrowProjectile()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}
