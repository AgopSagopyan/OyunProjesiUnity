using UnityEngine;
using Unity.Cinemachine; // Change to Cinemachine if using older package versions

public class CinemachineMobileInput : MonoBehaviour
{
    private CinemachineCamera _freeLookCam; // Or CinemachineFreeLook if on older versions
    private TouchCameraAxisProvider _touchProvider;

    void Start()
    {
        _freeLookCam = GetComponent<CinemachineCamera>();
        
        // Find the touch zone in the scene
        _touchProvider = FindFirstObjectByType<TouchCameraAxisProvider>();

        if (_touchProvider == null)
        {
            Debug.LogError("Please add a TouchCameraAxisProvider script to your UI Touch Zone!");
        }
    }

    void Update()
    {
        if (_freeLookCam == null || _touchProvider == null) return;

        // Force feed the UI touch values directly into the Cinemachine axes
        // Note: Check your specific Cinemachine version properties if names differ (e.g., Target.OnAxisValueChange)
        // For modern Cinemachine, we can override input values directly:
        
        // If using older Cinemachine FreeLook (XAxis / YAxis):
        // _freeLookCam.m_XAxis.m_InputAxisValue = _touchProvider.TouchX;
        // _freeLookCam.m_YAxis.m_InputAxisValue = _touchProvider.TouchY;
    }
}