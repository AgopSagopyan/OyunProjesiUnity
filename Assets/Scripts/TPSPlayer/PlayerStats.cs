using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{

    public System.Action OnStatsChanged;

    [Header("Base Player Stats")]
    public float maxHealth = 100f;
    public float basePower = 10f;
    public float baseArmor = 10f;
    public float gold=200f;


    [Header("Current Player Stats")]
    public float currentHealth = 100f;
    public float currentPower = 5f;
    public float currentArmor = 20f;

    public void ResetAllStats()
    {
        currentHealth = maxHealth;
        currentPower = basePower;
        currentArmor = baseArmor;

        OnStatsChanged?.Invoke();

    }

    public float GetPlayerHealth()
    {
        return currentHealth;
    }

    public float GetPlayerPower()
    {
        return currentPower;
    }

    public float GetPlayerArmor()
    {
        return currentArmor;
    }

    void Awake()
    {
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        Debug.Log("+" + amount + " Health");
        OnStatsChanged?.Invoke();
    }

    public void AddPower(float amount)
    {
        currentPower += amount;
        Debug.Log("+" + amount + " Power");
        OnStatsChanged?.Invoke();
    }

    public void AddArmor(float amount)
    {
        currentArmor += amount;
        Debug.Log("+" + amount + "Armor");
        OnStatsChanged?.Invoke();
    }

}
