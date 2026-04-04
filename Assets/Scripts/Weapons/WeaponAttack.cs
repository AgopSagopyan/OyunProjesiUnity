using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    private float _damage;

    public void Initialize(float damageAmount)
    {
        _damage = damageAmount;
    }

        void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Attacked");
            if(other.TryGetComponent(out EnemyHealt enemy))
            {
                enemy.AddHealth(-_damage);
                Debug.Log("Got Hit!!!");
            }
        }
    }
}
