using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Camera cam;

    public float speed = 10f;
    public float sprintSpeed = 20f;
    Vector2 moveVector;
    Vector3 moveDirection;
    public InputAction moveInput;

    Vector2 mouseVector;
    private float LookSensitivity = 0.2f;
    private float LookAngleLimit = 90f;
    private float lookAngle = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();

        moveInput = InputSystem.actions.FindAction("Move");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = moveInput.ReadValue<Vector2>();
        mouseVector = Mouse.current.delta.ReadValue();

        HandleMovement(moveVector);
        HandleLooking(mouseVector);
        
    }

    private void HandleMovement(Vector2 moveVector)
    {
        // get the forward and right directions relative to the player's current rotation
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // store the current y velocity to preserve it during movement
        float oldY = moveDirection.y;
        // calculate the new move direction based on the input vector and the player's orientation
        moveDirection = (forward * moveVector.y + right * moveVector.x).normalized;
        moveDirection.y = oldY;


        if (Keyboard.current.leftShiftKey.isPressed)
        {
            speed = 20f;
        } else
        {
            speed = 10f;
        }
        // apply the movement to the rigidbody's velocity
        rb.linearVelocity = moveDirection * speed;
    }

    private void HandleLooking(Vector2 mouseDelta)
    {
        // update the look angle based on the mouse input and sensitivity
        lookAngle += -mouseDelta.y * LookSensitivity;
        // clamp the look angle to prevent the camera from flipping over
        lookAngle = Mathf.Clamp(lookAngle, -LookAngleLimit, LookAngleLimit);

        // apply the rotation to the camera
        cam.transform.localRotation = Quaternion.Euler(lookAngle, 0f, 0f);
        // rotate the player object around the y-axis based on the mouse input
        transform.rotation *= Quaternion.Euler(0f, mouseDelta.x * LookSensitivity, 0f);
    }


}
