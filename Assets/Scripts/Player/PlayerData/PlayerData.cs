using NUnit.Framework.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
   public float maxHealth = 100f;
   public float currentHealth;
   public int gold;
    

    public void AddHealth(float amount)
    {
        currentHealth += amount;
    }
}
