using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float maxHealth = 100f;
    public float currentHealt = 100f;

    public System.Action OnStatsChanged;

    
    public void AddHealth(float amount)
    {
        currentHealt += amount;
        Debug.Log(amount + " Can");
        OnStatsChanged?.Invoke();
    }

    public float GetCurrentHealth()
    {
        return currentHealt;
    }
}
