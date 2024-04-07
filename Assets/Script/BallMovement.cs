
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float initialSpeed = 5f; // Initial speed at which the ball moves towards the tap position
    public float decelerationRate = 2f; // Rate at which the ball decelerates when the tap is released

    private Vector3 targetPosition; // Position where player tapped
    private bool isMoving = false; // Flag to track if the ball is moving
    private Vector3 velocity; // Current velocity of the ball

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for tap/click
        {
            // Get the tap position
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0; // Ensure z-coordinate is 0 (2D)

            // Start moving the ball towards the tap position
            isMoving = true;

            // Calculate initial velocity towards the tap position
            velocity = (targetPosition - transform.position).normalized * initialSpeed;
        }
        else if (Input.GetMouseButtonUp(0)) // Check for release of tap/click
        {
            // Stop the ball immediately when the tap is released
            isMoving = false;
            velocity = Vector3.zero;
        }

        if (isMoving)
        {
            // Move the ball towards the tap position
            transform.position += velocity * Time.deltaTime;

            // Decelerate the ball gradually if the tap is released
            if (!Input.GetMouseButton(0))
            {
                velocity -= velocity.normalized * decelerationRate * Time.deltaTime;

                // Stop the ball when its speed is almost zero
                if (velocity.magnitude < 0.1f)
                {
                    isMoving = false;
                    velocity = Vector3.zero;
                }
            }
        }
    }
}
