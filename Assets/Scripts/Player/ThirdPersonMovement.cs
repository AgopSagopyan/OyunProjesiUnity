using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed = 5f;
    public float sprintSpeed = 10f;
    private float currentSpeed;

    private bool isSprinting = false;

    public float jumpForce = 5f;

    public float gravity = -9.81f;

    public Transform cameraTransform;

    private PlayerControls controls;
    private Vector2 moveInput;

    private float verticalVelocity;

    private CharacterController controller;


    void Awake() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();

        controls = new PlayerControls();

        controls.Player.Sprint.performed += ctx => isSprinting = true;
        controls.Player.Sprint.canceled += ctx => isSprinting = false;

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Jump.performed += ctx => Jump();

    }


    void OnEnable()
    {
        controls.Enable();

    }

    void OnDisable() { 
        controls.Disable();
    }

    void Jump() {

        verticalVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
    }

    void CheckSprinting()
    {

    }


    void Update() {
        Move();
        ApplyGravity();
    }

    void Move() {

        float currentSpeed = isSprinting ? sprintSpeed : speed;


        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.position += moveDir * speed * Time.deltaTime;

            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }
    }

    void ApplyGravity()
    {
        if (controller.isGrounded && verticalVelocity < 0) {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 gravityMove = new Vector3(0, verticalVelocity, 0);
        controller.Move(gravityMove * Time.deltaTime);

    }
}
