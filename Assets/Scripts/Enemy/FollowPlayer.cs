using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Target to chase")]
    public Transform target;

    [Header("Settings for chaser")]
    public float speed = 5f;
    public float rotationSpeed = 10f;
    public float stoppingDistance = 2f;

    private CharacterController _controller;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (target == null) return;

        LookToTarget();
        MoveToTarget();
    }

    void LookToTarget()
    {
       Vector3 lookPosition = target.position - transform.position;
       lookPosition.y = 0;

       transform.rotation = Quaternion.LookRotation(lookPosition);
    }

    void MoveToTarget()
    {
        float currentDistance = Vector3.Distance(transform.position, target.position);

        if(currentDistance > stoppingDistance)
        {
            Vector3 velocity = transform.forward * speed;
            _controller.SimpleMove(velocity);
        }
    }
}
