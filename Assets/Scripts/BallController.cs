using UnityEngine;

/*
 * BallController class is responsible for controlling the behavior of the ball 
 * in the Pong game. It handles the ball's movement and collision with paddles and walls.
 */
public class BallController : MonoBehaviour
{
    public float speed = 15f; // Increased initial speed of the ball
    private Rigidbody2D rb;
    private GameController gameController;

    // Define boundary limits
    private float boundaryX = 8f; // Adjust based on your game area

    // Start is called before the first frame update.
    // This method initializes the ball's movement.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();

        // Set initial position slightly off-center towards the left
        float screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float ballXPosition = screenHalfWidth * -0.7f;
        transform.position = new Vector3(ballXPosition, 0, 0);

        // Launch the ball
        LaunchBall();
    }

    // Launches the ball to the right with a throw-like feel.
    void LaunchBall()
    {
        // Generate a random y position within a range
        float randomY = UnityEngine.Random.Range(-3.0f, 3.0f); // Adjust the range as needed

        // Generate a random force magnitude (adjust as needed)
        float randomForce = UnityEngine.Random.Range(8.0f, 12.0f); // Adjust the range for force

        // Calculate the launch direction with a slight random deviation
        Vector2 direction = new Vector2(1, randomY).normalized;

        // Apply a random force magnitude to the direction
        Vector2 throwForce = direction * randomForce;

        // Apply the throw force to the Rigidbody velocity
        rb.velocity = throwForce;
    }

    // Update is called once per frame.
    // This method checks if the ball has passed the boundary limits.
    void Update()
    {
        Debug.Log("Ball Position: " + transform.position.x); // Log ball's x position

        if (transform.position.x > boundaryX)
        {
            Debug.Log("Ball has passed the boundary");
            // End the game session
            gameController.EndGame();
        }
    }

    // Handles the collision of the ball with other objects.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            Vector2 vel = rb.velocity;
            vel.y = (rb.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb.velocity = vel;
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            // Reverse the y-velocity to bounce off the wall
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
    }
}
