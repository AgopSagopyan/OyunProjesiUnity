using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Enemy attack weapon prefab")]
    public GameObject weaponPrefab;

    [Header("Enemy weapon spawn hand")]
    public Transform spawnPoint;

    [Header("Enemy attack settings")]
    public float attackDistance = 2f;
    public float attackCooldown = 1.5f;
    public float weaponLifetime = 0.3f;

    [Header("Targets health")]
    public Health targetHealth;

    [Header("Weapons attack rotation offset")]
    public Vector3 attackRotationOffset = new Vector3(90, 0, 0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetHealth.TakeDamage(59);
    }

    // Update is called once per frame
    void Update()
    {
       Attack(); 
    }

    public void Attack()
    {
        Quaternion playerRotation = transform.rotation;

        Quaternion finalRotation = playerRotation * Quaternion.Euler(attackRotationOffset);

        GameObject weaponObject = Instantiate(weaponPrefab, spawnPoint.position, finalRotation);

        weaponObject.transform.SetParent(spawnPoint);
        Destroy(weaponObject, weaponLifetime);

    }
}
