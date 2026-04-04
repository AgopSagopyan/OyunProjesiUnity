using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    [Header("Settings for attack")]
    public PlayerStats playerStats;
    public GameObject weaponPrefab;
    public GameObject weaponHitBoxPrefab;
    public Transform handTransform;
    public float attackTime = 1f;


    private PlayerControls _playerInputs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _playerInputs = new PlayerControls();

        _playerInputs.Player.Attack.performed += ctx => PerformAttack();
        
    }

    void OnEnable() => _playerInputs.Enable();
    void OnDisable() => _playerInputs.Disable();

    // Update is called once per frame
    void Update()
    {
  
    }

    void PerformAttack()
    {
        Quaternion weaponSpawnRotation = transform.rotation * Quaternion.Euler(0, 90f, 0);

        GameObject weapon = Instantiate(weaponPrefab, handTransform.position, weaponSpawnRotation, handTransform);
        WeaponAttack script = weapon.GetComponent<WeaponAttack>();
        script.Initialize(playerStats.GetPlayerPower());

        Destroy(weapon, attackTime);
    }
}
