using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public int gold;
    public float power;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI powerText;




    public void AddHealth(float amount)
    {
        currentHealth += amount;
        healthText.text = "Health: " + currentHealth.ToString();
    }


    public void AddPower(float amount)
    {
        power += amount;
        powerText.text = "Power: " + power.ToString();
    }
}
