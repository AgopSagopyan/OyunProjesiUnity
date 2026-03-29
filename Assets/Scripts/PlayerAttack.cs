using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        // Her çarpışmayı logla (test için)
        Debug.Log("Bir şeye çarptı: " + other.name);

        // Eğer enemy ise
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy'e vurdu!");

            EnemyHealth enemy = other.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            else
            {
                Debug.Log("EnemyHealth bulunamadı!");
            }
        }
    }
}