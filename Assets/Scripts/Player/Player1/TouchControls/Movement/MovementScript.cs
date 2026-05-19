using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class MovementScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Animator animator;

    [Header("Movement Options")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 15f;

    [Header("Jump Options")]
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float groundedGravity = -2f;

    [Header("Ground Check Options")]
    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundDistance = 0.4f;

    [Header("Punch Settings")]
    public int punchDamage = 25;
    public float punchRange = 1.5f;
    public Vector3 punchHitboxSize = new Vector3(1f, 1f, 1f);
    public LayerMask enemyMask;

    public float punchDuration = 0.7f;
    public string punchAnimationTrigger = "Punch";

    private GameInput gameInput;
    private CharacterController controller;

    private Vector2 moveInput;
    private Vector3 velocity;

    private bool isGrounded;
    private bool jumpRequested;
    private bool punchRequested;
    private bool isPunching;

    private void Awake()
    {
        gameInput = new GameInput();
        controller = GetComponent<CharacterController>();

        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void OnEnable()
    {
        gameInput.Enable();

        gameInput.Player.Move.performed += OnMove;
        gameInput.Player.Move.canceled += OnMove;

        gameInput.Player.Jump.performed += OnJump;

        gameInput.Player.Punch.performed += OnPunch;
    }

    private void OnDisable()
    {
        gameInput.Player.Move.performed -= OnMove;
        gameInput.Player.Move.canceled -= OnMove;

        gameInput.Player.Jump.performed -= OnJump;

        gameInput.Player.Punch.performed -= OnPunch;

        gameInput.Disable();
    }

    private void Update()
    {
        GroundCheck();

        HandlePunch();

        if (!isPunching)
        {
            MovePlayer();
        }

        ApplyGravity();

        HandleAnimations();
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundDistance,
            groundMask
        );

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = groundedGravity;
        }
    }

    private void MovePlayer()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection =
            forward * moveInput.y +
            right * moveInput.x;

        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        if (jumpRequested && isGrounded)
        {
            velocity.y =
                Mathf.Sqrt(jumpHeight * -2f * gravity);

            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }

        jumpRequested = false;
    }

    private void HandlePunch()
    {
        if (!punchRequested)
            return;

        Debug.Log("Punch request received");

        punchRequested = false;

        if (!isGrounded)
        {
            Debug.Log("Cannot punch in air");
            return;
        }

        if (isPunching)
        {
            Debug.Log("Already punching");
            return;
        }

        StartCoroutine(PunchRoutine());
    }

    private IEnumerator PunchRoutine()
    {
        Debug.Log("Punch started");

        isPunching = true;

        moveInput = Vector2.zero;

        if (animator != null)
        {
            Debug.Log("Punch animation trigger sent");

            animator.SetTrigger(punchAnimationTrigger);
        }
        else
        {
            Debug.Log("Animator missing");
        }

        Vector3 hitboxCenter =
            transform.position +
            transform.forward * punchRange +
            Vector3.up * 1f;

        Collider[] hitEnemies = Physics.OverlapBox(
            hitboxCenter,
            punchHitboxSize / 2f,
            transform.rotation,
            enemyMask
        );

        Debug.Log("Enemies found: " + hitEnemies.Length);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Enemy hit: " + enemy.name);

            EnemyHealth enemyHealth =
                enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(punchDamage);

                Debug.Log("Damage applied");
            }
            else
            {
                Debug.Log("EnemyHealth component missing");
            }
        }

        yield return new WaitForSeconds(punchDuration);

        isPunching = false;

        Debug.Log("Punch finished");
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleAnimations()
    {
        if (animator != null)
        {
            float moveAmount =
                isPunching
                ? 0f
                : Mathf.Clamp01(moveInput.magnitude);

            animator.SetFloat("Speed", moveAmount);

            animator.SetBool("IsGrounded", isGrounded);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (isPunching)
            return;

        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpRequested = true;
        }
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Punch button pressed");

            punchRequested = true;
        }
    }
}