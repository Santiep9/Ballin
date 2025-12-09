using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput input;

    private Rigidbody rb;

    private Vector3 direction;

    private Vector2 inputMovement;

    private bool isJumping = false;

    [Header("Parameters")]

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        inputMovement = input.actions["Move"].ReadValue<Vector2>();

        direction.x = inputMovement.x;
        direction.z = inputMovement.y;
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * speed, ForceMode.Impulse);
    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}