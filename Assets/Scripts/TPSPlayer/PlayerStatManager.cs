using TMPro;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [Header("Player Stat Texts")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI armorText;

    [Header("Player Stats ScriptableObject")]
    public PlayerStats playerStats;


    void Start()
    {
        healthText.text = "Health: " + playerStats.GetPlayerHealth().ToString();
        powerText.text = "Power: " + playerStats.GetPlayerPower().ToString();
        armorText.text = "Armor: " + playerStats.GetPlayerArmor().ToString();
    }


}
