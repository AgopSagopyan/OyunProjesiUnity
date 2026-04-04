using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerCameraMovement : MonoBehaviour
{
    [Header("Third Person Camera Settings")]
    public Transform tpsCameraTransform;

    [Header("Player Movement Settings")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;

    [Header("Player Jump Settings")]
    public float jumpForce = 5f;
    public float gravity = -9.81f;


    //Private Variables
    private CharacterController _characterController;
    private PlayerControls playerInputSystem;

    private bool isSprinting;
    private Vector2 moveInput;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();




        //Player Input System
        playerInputSystem = new PlayerControls();

        playerInputSystem.Player.Sprint.performed += ctx => isSprinting = true;
        playerInputSystem.Player.Sprint.canceled += ctx => isSprinting = false;

        playerInputSystem.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInputSystem.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        playerInputSystem.Player.Jump.performed += ctx => Jump();

        
    }

    void OnEnable() => playerInputSystem.Enable();
    void OnDisable() => playerInputSystem.Disable();

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Jump()
    {
        
    }

    void Move()
    {
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +tpsCameraTransform.eulerAngles.y;

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.position += moveDir * walkSpeed * Time.deltaTime;

            _characterController.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }
    }
}
