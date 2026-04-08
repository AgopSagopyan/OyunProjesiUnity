using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public PlayerStats playerStats; // ScriptableObject
    public TextMeshProUGUI goldText;

    void Start()
    {
        UpdateUI();
    }

    public void BuyWeapon()
    {
        float price = 100f;        //  fiyat
        float powerIncrease = 10f; //  güç artışı

        if (playerStats.gold >= price)
        {
            // GOLD AZALT
            playerStats.gold -= price;

            // POWER ARTIR
            playerStats.AddPower(powerIncrease);

            Debug.Log("Silah satın alındı!");

            UpdateUI();
        }
        else
        {
            Debug.Log("Yeterli gold yok!");
        }
    }

    void UpdateUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + playerStats.gold;
        }
    }

    void OnEnable()
    {
        if (playerStats != null)
            playerStats.OnStatsChanged += UpdateUI;
    }

    void OnDisable()
    {
        if (playerStats != null)
            playerStats.OnStatsChanged -= UpdateUI;
    }
}