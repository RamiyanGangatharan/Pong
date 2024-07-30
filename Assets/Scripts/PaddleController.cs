using UnityEngine;

/*
 * PaddleController class is responsible for controlling the movement of the paddles 
 * in the Pong game. It takes input from the player and moves the paddle accordingly.
 */
public class PaddleController : MonoBehaviour
{
    public float paddleSpeed = 20f; // Paddle movement paddleSpeed
    public string inputAxis;  // Input axis for controlling the paddle (e.g., "Vertical" or "Vertical2")
    public string playerTag;  // Tag to differentiate between Player1 and Player2

    private bool isCollidingWithTopWall = false;
    private bool isCollidingWithBottomWall = false;

    // Update is called once per frame
    void Update() { HandleMovement(); }

    // Handles the paddle movement based on player input
    private void HandleMovement()
    {
        Vector3 move = Vector3.zero;

        // Check which player this script is controlling based on the playerTag
        if (playerTag == "Player1")
        {
            // Update the move vector based on arrow key inputs for Player1
            if (Input.GetKey(KeyCode.UpArrow)) { move += Vector3.up; }
            if (Input.GetKey(KeyCode.DownArrow)) { move += Vector3.down; }
        }
        if (playerTag == "Player2")
        {
            // Update the move vector based on WASD key inputs for Player2
            if (Input.GetKey(KeyCode.W)) { move += Vector3.up; }
            if (Input.GetKey(KeyCode.S)) { move += Vector3.down; }
        }

        // Prevent movement if colliding with top or bottom wall and apply the movement to the paddle's transform
        if ((isCollidingWithTopWall && move.y > 0) || (isCollidingWithBottomWall && move.y < 0)) { move = Vector3.zero; }
        transform.Translate(move * paddleSpeed * Time.deltaTime);
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
