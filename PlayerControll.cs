using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 30.0f; // Adjust the speed as needed.
    public float jumpForce = 30.0f; // Adjust the jump force as needed.

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Disable rotation of the rigidbody to prevent rolling.
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Get input from the player.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Restrict diagonal movement by setting one input to zero when moving in a cardinal direction.
        if (Mathf.Abs(horizontalInput) > 0 && Mathf.Abs(verticalInput) > 0)
        {
            if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
            {
                verticalInput = 0;
            }
            else
            {
                horizontalInput = 0;
            }
        }

        // Calculate the movement direction.
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Normalize the movement vector to ensure consistent speed regardless of direction.
        movement.Normalize();

        // Apply the movement to the player's Rigidbody.
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        // Check for the spacebar to jump.
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Detect if the player is grounded to allow jumping.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) // You should tag your ground objects.
        {
            isGrounded = true;
        }
    }
}
