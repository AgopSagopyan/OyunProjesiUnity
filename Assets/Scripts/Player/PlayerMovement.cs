using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float move_speed = 5f;
    public float rotation_smooth_time = 0.12f;
    public float _target_rotation = 0f;
    public float _rotation_velocity;

    public float gravity = -9.81f;
    public float jump_height = 1.2f;
    private Vector3 _vertical_velocity;

    public CharacterController controller;
    public Transform main_camera;

    private Vector2 _move_input;
    private bool _jump_triggered;

    void Update() {


    }

    private void Move() {
        Vector3 input_direction = new Vector3(_move_input.x, 0f,_move_input.y).normalized;
         

    }

}
