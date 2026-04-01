using UnityEngine;

public class EnemyTouchAttack : MonoBehaviour
{
    public PlayerStats playerStats;

    public float damage = 10f;

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Player"))
        {
            playerStats.AddHealth(-damage);

        }
    }
}
