using UnityEngine;

public class Coins : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool collected = false;

   

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
        Debug.Log(Score.score);
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterStats stats = other.GetComponent<CharacterStats>();

        if (!collected &&other.CompareTag("Player"))
        {
            collected = true;
            Score.score++;
            Destroy(gameObject);

            //stats.AddCoins(1f);
        }
    }
}
