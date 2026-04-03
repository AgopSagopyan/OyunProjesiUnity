using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public GameObject bloodPrefab;

    private CharacterController characterController;

    private Vector3 impact = Vector3.zero;

    public float playerMass = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        characterController = GetComponent<CharacterController>();        

    }

    // Update is called once per frame
    void Update()
    {
        if(impact.magnitude > 0.2f)
        {
            characterController.Move(impact * Time.deltaTime);
        }

        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
        
    }

    public void AddKnockback(Vector3 direction, float force)
    {
        direction.Normalize();
        if(direction.y < 0) direction.y = -direction.y;
        impact += direction.normalized * force / playerMass;

        SpawnBlood(transform.position, transform.rotation);


    }

    public void SpawnBlood(Vector3 position, Quaternion rotation)
    {
        Instantiate(bloodPrefab, position, rotation);
    }
}
