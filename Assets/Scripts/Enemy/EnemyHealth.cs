using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    [Header("EnemyStats Scriptable Object")]
    public EnemyStats enemyStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddHealth(float amount)
    {
        enemyStats.AddHealth(amount);   
        
    }
}
