using UnityEngine;
using UnityEngine.InputSystem; // Required for the New Input System

[RequireComponent(typeof(CharacterController))]
public class TPSPlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraTransform;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float gravity = -20f;

    [Header("Jumping (Adjustable)")]
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float groundedGravity = -2f; 

    [Header("Ground Check settings")]
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckRadius = 0.3f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private CharacterController controller;
    private Vector3 velocity;
    private Vector2 moveInput; // Stores our movement vector (X and Y)
    private bool jumpRequested = false;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        CheckGroundStatus();
        MovePlayer();
    }

    private void CheckGroundStatus()
    {
        isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundCheckRadius, groundLayer);
    }

    private void MovePlayer()
    {
        // Read movement values from our Input System callback variable
        float horizontal = moveInput.x;
        float vertical = moveInput.y;

        // Camera forward/right directions
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Remove vertical influence
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calculate movement direction
        Vector3 moveDirection = (forward * vertical) + (right * horizontal);
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        // Move character horizontally
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Rotate character toward movement
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // --- Ground & Gravity Logic ---
        if (isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = groundedGravity;
            }

            // Execute jump if requested while grounded
            if (jumpRequested)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                
                if (animator != null)
                {
                    animator.SetTrigger("Jump");
                }
            }
        }
        
        // Reset the jump flag every frame so it doesn't stay stuck active
        jumpRequested = false;

        // Apply constant gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical movement
        controller.Move(velocity * Time.deltaTime);

        // --- Animation ---
        if (animator != null)
        {
            // Calculate actual movement intensity
            float moveAmount = Mathf.Clamp01(moveInput.magnitude);
            animator.SetFloat("Speed", moveAmount);
            animator.SetBool("IsGrounded", isGrounded);
        }
    }

    #region Input System Callbacks

    /// <summary>
    /// Automatically invoked by PlayerInput component when "Move" action is triggered.
    /// Expects a Vector2 (WASD, D-Pad, Left Stick, or On-Screen Joystick).
    /// </summary>
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        Debug.Log("MOVE INPUT: " + moveInput);

    }

    /// <summary>
    /// Automatically invoked by PlayerInput component when "Jump" action is pressed.
    /// </summary>
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpRequested = true;
        }
    }

    #endregion

    private void OnDrawGizmosSelected()
    {
        if (groundCheckTransform == null) return;

        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
    }
}