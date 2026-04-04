using UnityEngine;

public class WeaponSpinAftetCreated : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    System.Collections.IEnumerator RotateWeapon(Transform weaponTarget)
    {
        float elapsed = 0f;
        Quaternion startRotation = weaponTarget.localRotation;
        Quaternion endRotation = Quaternion.Euler(0, 0, 0f);

        yield return null;
    }
}
