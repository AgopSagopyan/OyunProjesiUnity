using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [Header("PlayerStats Scriptable Object")]
    public PlayerStats playerStats;

    [Header("HealtBar Front Layer")]
    public Image healtBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healtBar.fillAmount = playerStats.GetPlayerHealth() / 100;
    }
}
