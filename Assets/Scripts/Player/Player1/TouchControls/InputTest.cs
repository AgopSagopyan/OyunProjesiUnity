using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    [Header("Movement Options")]
    public float moveSpeed = 5f;

    [Header("Jump Options")]
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    [Header("Ground Check Options")]
    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundDistance = 0.4f;

    private GameInput gameInput;

    private Vector2 moveInput;
    private Vector3 velocity;

    private bool isGrounded;

    private CharacterController controller;

    private void Awake()
    {
        gameInput = new GameInput();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        gameInput.Enable();

        gameInput.Player.Move.performed += OnMove;
        gameInput.Player.Move.canceled += OnMove;

        gameInput.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        gameInput.Player.Move.performed -= OnMove;
        gameInput.Player.Move.canceled -= OnMove;

        gameInput.Player.Jump.performed -= OnJump;

        gameInput.Disable();
    }

    private void Update()
    {
        GroundCheck();
        MovePlayer();
        ApplyGravity();
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundDistance,
            groundMask
        );

        // Keeps player grounded properly
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void MovePlayer()
    {
        // World-space movement
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);

        // For local-space movement use this instead:
        // Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Only jump if grounded
        if (isGrounded)
        {
            Debug.Log("Player Jumped");

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}