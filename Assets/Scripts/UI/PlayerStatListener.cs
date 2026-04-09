using TMPro;
using UnityEngine;

public class PlayerStatListener : MonoBehaviour
{
    [Header("PlayerStats ScriptableObject")]
    public PlayerStats playerStats;

    [Header("PlayerStat Texts")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI goldText;

    private void OnEnable() => playerStats.OnStatsChanged += UpdateUI;
    private void OnDisable() => playerStats.OnStatsChanged -= UpdateUI;

    public void UpdateUI()
    {
        healthText.text = "Health: " + playerStats.GetPlayerHealth().ToString();
        powerText.text = "Power: " + playerStats.GetPlayerPower().ToString();
        armorText.text = "Armor: " + playerStats.GetPlayerArmor().ToString();
        goldText.text = "Gold: " + playerStats.GetPlayerGold().ToString();

        
    }

    void Awake()
    {

        playerStats.ResetAllStats();
        UpdateUI();
    }
}
