using UnityEngine;

public class Float : MonoBehaviour
{
    [Header("Floating Settings")]
    public float floatAmplitude = 0.5f;
    public float floatFrequency = 1f;

    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       startPos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
       float yOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
       transform.position = startPos + new Vector3(0, yOffset, 0);
    }
}
