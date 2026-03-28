using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StatsRuntime
{
    public float baseValue;
    private List<float> modifiers = new List<float>();

    public StatsRuntime(float baseValue)
    {
        this.baseValue = baseValue;
    }

    public float GetValue()
    {
        float finalValue = baseValue;

        foreach(var mod in modifiers)
        {
            finalValue += mod;
        }

        return finalValue;
    }

    public void AddModifier(float mod)
    {
        modifiers.Add(mod);
    }

    public void ChangeValue(float amount)
    {
        baseValue += amount;    
    }
}
