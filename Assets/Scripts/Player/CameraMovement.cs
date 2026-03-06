using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Karakterin (Player) Transform'u
    public Vector3 offset = new Vector3(0, 2, -5); // Karakterden uzaklık
    public float sensitivity = 3.0f; // Fare hassasiyeti

    private float _rotationX = 0f;
    private float _rotationY = 0f;

    void Start()
    {
        // Fareyi oyunun içine kilitleyelim ki ekrandan çıkmasın
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Fare hareketlerini alıyoruz
        _rotationY += Input.GetAxis("Mouse X") * sensitivity;
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;

        // Kameranın takla atmaması için dikey açıyı kısıtlıyoruz
        _rotationX = Mathf.Clamp(_rotationX, -40f, 85f);

        // Dönüşü hesaplıyoruz
        Quaternion rotation = Quaternion.Euler(_rotationX, _rotationY, 0);

        // Kamerayı karakterin etrafında döndürüp pozisyonunu güncelliyoruz
        transform.position = target.position + rotation * offset;

        // Kamera her zaman karaktere bakmalı
        transform.LookAt(target.position + Vector3.up * 1.5f); 
    }
}