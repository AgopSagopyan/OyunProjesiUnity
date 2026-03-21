using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject hitboxPrefab;
    public float distanceInFront = 2f;
    public float hitboxLifetime = 0.2f;



    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            SpawnHitbox();
        }
        
    }

    void SpawnHitbox() { 
        Vector3 spawnPos = transform.position + transform.forward * distanceInFront;

        GameObject hitbox = Instantiate(hitboxPrefab, spawnPos, transform.rotation);

        Destroy(hitbox, hitboxLifetime);
    }
}
