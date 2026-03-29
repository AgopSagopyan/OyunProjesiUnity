using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Target to chase")]
    public Transform target;

    [Header("Settings for chaser")]
    public float speed = 5f;
    public float rotationSpeed = 10f;

    private CharacterController _controller;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        LookToTarget();
        MoveToTarget();
    }

    void LookToTarget()
    {

       if(target == null) return; 

       Vector3 lookPosition = target.position - transform.position;
       lookPosition.y = 0;

       transform.rotation = Quaternion.LookRotation(lookPosition);
    }

    void MoveToTarget()
    {
        if(target == null)
        {
            Debug.Log("Target not found!");
            return;
        }

        Vector3 velocity = transform.forward * speed;
        _controller.SimpleMove(velocity);
    }
}
