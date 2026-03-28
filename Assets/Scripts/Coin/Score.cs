using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score;
    }
}
