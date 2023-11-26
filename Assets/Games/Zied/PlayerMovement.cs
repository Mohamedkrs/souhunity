using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;  // Adjust the speed as needed
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input from the player
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector2 movement = new Vector2(moveX, moveY);

        // Normalize the vector to prevent faster diagonal movement
        movement.Normalize();

        // Apply the movement to the rigidbody
        rb.velocity = movement * moveSpeed;
    }
}