using System.Collections;
using UnityEngine;

public class PowerCollectable : MonoBehaviour
{
    [Header("PlayerStats ScriptableObject")]
    public PlayerStats playerStats;

    [Header("Collectable Settings")]
    public float shrinkSpeed = 2.0f;
    public float amount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerStats.AddPower(amount);
            StartCoroutine(ShrinkAndDestroy());
        }
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
