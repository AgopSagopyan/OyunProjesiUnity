using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("GroundCheck Settings")]
    public bool isGrounded;
    public Transform groundCheck;
    public float sphereRadius = 0.4f;
    public LayerMask groundLayer;

    [Header("Jump Settings")]
    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private CharacterController _characterController;
    private float _verticalVelocity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsGrounded();
        ApplyGravity();

        
    }

    void ApplyGravity()
    {
        if(!isGrounded)
        {
            _verticalVelocity += gravity * Time.deltaTime;

            Vector3 gravityMove = new Vector3(0, _verticalVelocity, 0);

            _characterController.Move(gravityMove * Time.deltaTime);
            
            
        }
    }

    void CheckIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundLayer);


    }
}
