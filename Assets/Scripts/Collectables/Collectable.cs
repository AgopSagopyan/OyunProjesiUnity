using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Script for PlayerStats")]
    public PlayerData playerData;

    [Header("Health Text")]
    public TextMeshProUGUI healthText;

    public enum StatType { Health, Armor, Speed, Score}

    [Header("Collectable Settings")]
    public StatType collectableType;
    public int amount = 10;

    public float shrinkSpeed = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerData.AddHealth(amount);
            healthText.text = "Health: " + playerData.currentHealth;
            StartShrinking();
        }
    }
    

    void StartShrinking()
    {
        StartCoroutine(ShrinkAndDestroy());
    }

    private IEnumerator ShrinkAndDestroy()
    {

        Vector3 initialScale = transform.localScale;
        float timer = 0f;

        while (timer< 1f)
        {
            timer += Time.deltaTime * shrinkSpeed;

            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, timer);
            yield return null;
        }

        Destroy(gameObject);

    }
}
