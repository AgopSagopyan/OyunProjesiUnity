using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Object that player will use for attacking")]
    public GameObject hitboxPrefab;

    [Header("Hand that weapon appear at")]
    public Transform spawnPoint; 

    [Header("Attack settings")]
    public float distanceInFront = 2f;
    public float hitboxLifetime = 0.2f;


    [Header("Weapons attack rotation offset")]
    public Vector3 attackRotationOffset = new Vector3(90, 0, 0);



    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //SpawnHitbox();
            BetterSpawnHitbox();
        }
        
    }

    void SpawnHitbox() { 
        Vector3 spawnPos = transform.position + transform.forward * distanceInFront;
        Quaternion rotationOffset = Quaternion.Euler(90, 0, 0);


        GameObject hitbox = Instantiate(hitboxPrefab, spawnPos, rotationOffset);

        // hitbox.transform.rotation = rotationOffset;

        Destroy(hitbox, hitboxLifetime);

    }

    void BetterSpawnHitbox()
    {
        Quaternion playerRotation = transform.rotation;

        Quaternion finalRotation = playerRotation * Quaternion.Euler(attackRotationOffset);

        GameObject weaponObject = Instantiate(hitboxPrefab, spawnPoint.position, finalRotation);

        weaponObject.transform.SetParent(spawnPoint);
        Destroy(weaponObject, hitboxLifetime);

    }

}
