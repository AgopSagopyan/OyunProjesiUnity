using UnityEngine;

public class Player1TouchControls : MonoBehaviour
{
    [Header("Ground Check Settings")]
    public Transform groundCheck;

    public Transform dasdas123;

    public float sphereRadius = 0.4f;
    public LayerMask groundLayer;
    private bool isGrounded;

    [Header("Movement Settings")]
    public float speed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    
    [Header("References")]
    public Transform cameraTransform;
    public Joystick joystick; // Assign your Fixed Joystick here in the Inspector

    private float verticalVelocity;
    private CharacterController controller;
    private bool isSprinting = false;

    // Optional: Keep this if you still want to toggle sprint via UI button
    public void SetSprinting(bool sprinting) => isSprinting = sprinting;

    void Awake() 
    {
        // NOTE: For mobile, you usually want the cursor visible/unlocked 
        // so players can tap UI buttons. Commenting these out for mobile:
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;

        controller = GetComponent<CharacterController>();
    }

    void Update() 
    {
        Move();
        ApplyGravity();
    }

    void Move() 
    {
        // 1. Get input directly from the Joystick
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // Determine current speed based on sprint state
        float currentSpeed = isSprinting ? sprintSpeed : speed;

        // Check if joystick is being pushed significantly
        if (direction.magnitude >= 0.1f)
        {
            // 2. Calculate rotation relative to the Camera's view
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // 3. Move the character using ONLY the CharacterController
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }
    }

    // Public method to be called by a UI Jump Button component
    public void Jump() 
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundLayer);

        if (isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    void ApplyGravity()
    {
        // Using controller.isGrounded as it's more reliable for gravity resets
        if (controller.isGrounded && verticalVelocity < 0) 
        {
            verticalVelocity = -2f; 
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 gravityMove = new Vector3(0, verticalVelocity, 0);
        controller.Move(gravityMove * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(groundCheck.position, sphereRadius);
        }
    }
}