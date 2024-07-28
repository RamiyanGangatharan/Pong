using UnityEngine;

/*
 * PaddleController class is responsible for controlling the movement of the paddles 
 * in the Pong game. It takes input from the player and moves the paddle accordingly.
 */
public class PaddleController : MonoBehaviour
{
    public float speed = 20f; // Paddle movement speed
    public string inputAxis;  // Input axis for controlling the paddle (e.g., "Vertical" or "Vertical2")

    private bool isCollidingWithTopWall = false;
    private bool isCollidingWithBottomWall = false;

    // Update is called once per frame
    void Update()
    { HandleMovement(); }

    // Handles the paddle movement based on player input
    private void HandleMovement()
    {
        float move = Input.GetAxis(inputAxis) * speed * Time.deltaTime;

        // Prevent movement if colliding with top or bottom wall
        if ((isCollidingWithTopWall && move > 0) || (isCollidingWithBottomWall && move < 0)) { move = 0; }
        transform.Translate(0, move, 0);
    }

    // Detects collisions with walls
    void OnCollisionEnter2D(Collision2D collision) { if (collision.collider.CompareTag("Wall")) { SetWallCollisionState(collision, true); } }

    // Detects when the paddle exits collision with walls
    void OnCollisionExit2D(Collision2D collision) { if (collision.collider.CompareTag("Wall")) { SetWallCollisionState(collision, false); } }

    // Sets the collision state with the walls
    private void SetWallCollisionState(Collision2D collision, bool isColliding)
    {
        if (collision.contacts[0].normal.y > 0) { isCollidingWithBottomWall = isColliding; }
        else if (collision.contacts[0].normal.y < 0) { isCollidingWithTopWall = isColliding; }
    }
}
