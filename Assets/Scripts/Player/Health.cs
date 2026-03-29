using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth = 100;

    public PlayerData stats;

    public void TakeDamage(float amount)
    {
        stats.currentHealth -= amount;
        Debug.Log("Player Took Damage!: -" + amount);

    }

}
