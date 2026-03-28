using UnityEngine;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    [Header("Assign ScriptableObjects")]
    public StatData strengthData;
    public StatData coinData;

    [Header("Text that holds Strength stat")]
    public TextMeshProUGUI StrengthText;
    public TextMeshProUGUI CoinText;

    private StatsRuntime strength;    
    private StatsRuntime coin;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       strength = new StatsRuntime(strengthData.baseValue); 
       coin = new StatsRuntime(coinData.baseValue); 
    }

    void Update()
    {
        StrengthText.text = "Strength: " + strength.GetValue();
        CoinText.text = "Gold: " + coin.GetValue();
    }

    public void AddCoins(float amount)
    {
        coin.ChangeValue(amount);
    }

}
