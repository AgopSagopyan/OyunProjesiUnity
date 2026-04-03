using UnityEngine;
using UnityEngine.Rendering;

public class EnemyTouchAttack : MonoBehaviour
{
    public PlayerStats playerStats;

    public float damage = 10f;


    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Player"))
        {
            playerStats.AddHealth(-damage);
            Debug.Log("10 hasar verildi");

        }

        Debug.Log("Triggered by: " + other.gameObject.name);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Player"))
        {
            PlayerTakeDamage move = hit.gameObject.GetComponent<PlayerTakeDamage>();
            if(move != null)
            {
                Vector3 bumpDir = hit.gameObject.transform.position - transform.position;
                move.AddKnockback(bumpDir, 45.0f);
            }

            Debug.Log("10 hasar verildi");
            playerStats.AddHealth(-damage);
            
        }
    }
}
