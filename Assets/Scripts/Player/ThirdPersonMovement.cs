using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed = 5f;

    public float jumpForce = 5f;

    public float gravity = -9.81f;

    public Transform cameraTransform;

    private PlayerControls controls;
    private Vector2 moveInput;

    private float verticalVelocity;

    private CharacterController controller;

    void Awake() {

        controller = GetComponent<CharacterController>();

        controls = new PlayerControls();

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


    void Update() {
        Move();
        ApplyGravity();
    }

    void Move() {
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.position += moveDir * speed * Time.deltaTime;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
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
