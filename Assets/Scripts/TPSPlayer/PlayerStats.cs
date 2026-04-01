using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{

    public System.Action OnStatsChanged;

    [Header("Player Stats")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public float power = 5f;
    public float armor = 20f;

    public float GetPlayerHealth()
    {
        return currentHealth;
    }

    public float GetPlayerPower()
    {
        return power;
    }

    public float GetPlayerArmor()
    {
        return armor;
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        Debug.Log("+" + amount + " Health");
        OnStatsChanged?.Invoke();
    }

    public void AddPower(float amount)
    {
        power += amount;
        Debug.Log("+" + amount + " Power");
        OnStatsChanged?.Invoke();
    }

    public void AddArmor(float amount)
    {
        armor += amount;
        Debug.Log("+" + amount + "Armor");
        OnStatsChanged?.Invoke();
    }

}
