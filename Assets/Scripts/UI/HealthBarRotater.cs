using UnityEngine;

public class HealthBarRotater : MonoBehaviour
{

    public Transform mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
       transform.forward = mainCamera.transform.forward;
    }
}
