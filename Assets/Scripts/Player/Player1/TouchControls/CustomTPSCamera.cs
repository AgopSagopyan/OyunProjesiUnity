using UnityEngine;

public class CustomTPSCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Camera Offset")]
    [SerializeField] private Vector3 targetOffset = new Vector3(0.5f, 1.6f, 0f);

    [Header("Distance")]
    [SerializeField] private float defaultDistance = 3f;
    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float maxDistance = 5f;

    [Header("Rotation Limits")]
    [SerializeField] private float minVerticalAngle = -30f;
    [SerializeField] private float maxVerticalAngle = 70f;

    [Header("Touch Sensitivity")]
    [SerializeField] private float touchSensitivityX = 0.15f;
    [SerializeField] private float touchSensitivityY = 0.15f;

    [Header("Smoothing")]
    [SerializeField] private float rotationSmoothSpeed = 12f;
    [SerializeField] private float positionSmoothSpeed = 18f;
    [SerializeField] private float collisionSmoothSpeed = 20f;

    [Header("Collision")]
    [SerializeField] private LayerMask collisionLayers;
    [SerializeField] private float cameraRadius = 0.2f;
    [SerializeField] private float collisionOffset = 0.15f;

    // Rotation
    private float yaw;
    private float pitch;

    // Distance
    private float currentDistance;

    // Smoothed position
    private Vector3 currentPosition;

    // Touch tracking
    private int lookFingerId = -1;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("Camera target missing.");
            enabled = false;
            return;
        }

        Vector3 angles = transform.eulerAngles;

        yaw = angles.y;
        pitch = angles.x;

        currentDistance = defaultDistance;
        currentPosition = transform.position;
    }

    private void LateUpdate()
    {
        HandleTouchInput();
        UpdateCamera();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount == 0)
            return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Use only right half of screen for camera look
            if (touch.position.x < Screen.width * 0.5f)
                continue;

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    if (lookFingerId == -1)
                    {
                        lookFingerId = touch.fingerId;
                    }

                    break;

                case TouchPhase.Moved:

                    if (touch.fingerId == lookFingerId)
                    {
                        Vector2 delta = touch.deltaPosition;

                        yaw += delta.x * touchSensitivityX;
                        pitch -= delta.y * touchSensitivityY;

                        pitch = Mathf.Clamp(
                            pitch,
                            minVerticalAngle,
                            maxVerticalAngle
                        );
                    }

                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                    if (touch.fingerId == lookFingerId)
                    {
                        lookFingerId = -1;
                    }

                    break;
            }
        }
    }

    private void UpdateCamera()
    {
        // Smooth rotation
        Quaternion targetRotation =
            Quaternion.Euler(pitch, yaw, 0);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSmoothSpeed * Time.deltaTime
        );

        // Shoulder pivot
        Quaternion horizontalRotation =
            Quaternion.Euler(0, yaw, 0);

        Vector3 pivotPosition =
            target.position +
            (horizontalRotation * targetOffset);

        // Camera direction
        Vector3 desiredDirection =
            transform.rotation * Vector3.back;

        // Collision
        float desiredDistance = defaultDistance;

        RaycastHit hit;

        if (Physics.SphereCast(
                pivotPosition,
                cameraRadius,
                desiredDirection,
                out hit,
                defaultDistance,
                collisionLayers,
                QueryTriggerInteraction.Ignore))
        {
            desiredDistance =
                Mathf.Clamp(
                    hit.distance - collisionOffset,
                    minDistance,
                    maxDistance
                );
        }

        // Smooth collision distance
        currentDistance = Mathf.Lerp(
            currentDistance,
            desiredDistance,
            collisionSmoothSpeed * Time.deltaTime
        );

        // Final position
        Vector3 desiredPosition =
            pivotPosition +
            desiredDirection * currentDistance;

        // Smooth movement
        currentPosition = Vector3.Lerp(
            currentPosition,
            desiredPosition,
            positionSmoothSpeed * Time.deltaTime
        );

        transform.position = currentPosition;
    }
}