using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarManager : MonoBehaviour
{
    public EnemyStats enemyStats;

    public Image healthBar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       healthBar.fillAmount = enemyStats.GetCurrentHealth() / 100; 
    }
}
