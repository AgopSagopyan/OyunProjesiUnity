using UnityEngine;

public class Movement : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    [Header("Movement Settings")]
    public float playerSpeed = 7.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -18.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if(isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = -2f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        move = transform.forward * move.z + transform.right * move.x;

        controller.Move(move * Time.deltaTime * playerSpeed);

        if(Input.GetButtonDown("Jump") && isGrounded) {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }
}
