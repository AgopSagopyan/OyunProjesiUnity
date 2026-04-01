using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float damage;
    public float lifeTime = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
