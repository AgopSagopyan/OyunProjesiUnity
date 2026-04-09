using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [Header("Player Data")]
    public PlayerStats playerStats;

    [Header("UI")]
    public TextMeshProUGUI goldText;

    [Header("Category Panels")]
    public GameObject weaponContent;
    public GameObject armorContent;
    public GameObject healthContent;

    void Start()
    {
        UpdateUI();
        ShowWeapons(); // oyun açılınca weapon açık
    }

    //  SATIN ALMA (WEAPON)
    public void BuyWeapon()
    {
        float price = 100f;
        float powerIncrease = 10f;

        if (playerStats.gold >= price)
        {
            playerStats.gold -= price;
            playerStats.AddPower(powerIncrease);

            Debug.Log("Silah satın alındı!");
            UpdateUI();
        }
        else
        {
            Debug.Log("Yeterli gold yok!");
        }
    }

    //  (ŞİMDİLİK BOŞ )
    public void BuyArmor()
    {
        Debug.Log("Armor sistemi sonra yapılacak");
    }

    //  (ŞİMDİLİK BOŞ)
    public void BuyHealth()
    {
        Debug.Log("Health sistemi sonra yapılacak");
    }

    //  UI GÜNCELLE
    void UpdateUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + playerStats.gold;
        }
    }

    //  EVENT BAĞLAMA
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

    // 📂 CATEGORY SİSTEMİ
    public void ShowWeapons()
    {
        weaponContent.SetActive(true);
        armorContent.SetActive(false);
        healthContent.SetActive(false);
    }

    public void ShowArmor()
    {
        weaponContent.SetActive(false);
        armorContent.SetActive(true);
        healthContent.SetActive(false);
    }

    public void ShowHealth()
    {
        weaponContent.SetActive(false);
        armorContent.SetActive(false);
        healthContent.SetActive(true);
    }
}