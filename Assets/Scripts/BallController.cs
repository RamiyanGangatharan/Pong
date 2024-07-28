using UnityEngine;

/*
 * BallController class is responsible for controlling the behavior of the ball 
 * in the Pong game. It handles the ball's movement and collision with paddles and walls.
 */
public class BallController : MonoBehaviour
{
    public float initialSpeed = 2f; // Initial speed of the ball
    private Rigidbody2D rb;
    private GameController gameController;

    // Define boundary limits
    private float boundaryX = 8f; // Adjust based on your game area

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();

        // Set initial position slightly off-center towards the left
        float screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float ballXPosition = screenHalfWidth * -0.7f;
        transform.position = new Vector3(ballXPosition, 0, 0);
        LaunchBall();
    }

    // Launches the ball with a random y-direction and speed
    void LaunchBall()
    {
        float randomY = Random.Range(-1.0f, 1.0f); // Adjust the range for the initial y-direction
        Vector2 direction = new Vector2(1, randomY).normalized; // Launch direction
        rb.velocity = direction * initialSpeed; // Set initial velocity
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the ball has crossed the boundary
        if (transform.position.x > boundaryX) {gameController.EndGame();}
    }

    // Handles the collision of the ball with other objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            // Adjust the ball's velocity based on the paddle's velocity
            Vector2 velocity = rb.velocity;
            velocity.y = (rb.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb.velocity = velocity;
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            // Reverse the y-velocity to bounce off the wall
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
    }

    // Resets the ball to the initial position and re-launches it
    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        float screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float ballXPosition = screenHalfWidth * -0.7f;
        transform.position = new Vector3(ballXPosition, 0, 0);
        LaunchBall();
    }
}
