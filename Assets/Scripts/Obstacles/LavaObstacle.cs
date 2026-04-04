using UnityEngine;
using UnityEngine.Playables;

public class LavaObstacle : MonoBehaviour
{
    public PlayerStats playerStats;

    public float damageValue = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Nigger");
            playerStats.AddHealth(-damageValue);
        }
    }
}
