using UnityEngine;

/*
 * BallController class is responsible for controlling the behavior of the ball 
 * in the Pong game. It handles the ball's movement and collision with paddles and walls.
 */
public class BallController : MonoBehaviour
{
    public float initialSpeed = 2f; // Initial speed of the ball

    private Rigidbody2D rigidBody;

    private GameController gameController;

    // Define boundary limits
    private float boundaryRight = 8f;
    private float boundaryLeft = -8f;

    public string gameMode; 

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        gameController = FindObjectOfType<GameController>();

        // Set boundaries based on game mode
        if (gameMode == "Handball")
        {
            boundaryLeft = float.NegativeInfinity; // No left boundary for singleplayer
        }

        // Set initial position at either -5 or 5 on the x-axis
        float ballXPosition = (Random.Range(0, 2) == 0) ? -5.0f : 5.0f;

        transform.position = new Vector3(ballXPosition, 0, 0);

        LaunchBall(ballXPosition);
    }

    // Launches the ball with a random y-direction and speed, in the opposite direction of the starting position
    void LaunchBall(float ballXPosition)
    {
        // Adjust the range for the initial y-direction
        float randomY = Random.Range(-1.0f, 1.0f);

        // Launch direction based on starting position
        float directionX = ballXPosition < 0 ? 1 : -1;

        // Launch direction
        Vector2 direction = new Vector2(directionX, randomY).normalized;

        // Set initial velocity
        rigidBody.velocity = direction * initialSpeed; 
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMode == "Handball")
        {
            if (transform.position.x > boundaryRight || transform.position.x < boundaryLeft)
            {
                gameController.EndGame();
            }
        }
        if (gameMode == "Multiplayer" || gameMode == "Singleplayer")
        {
            if (transform.position.x > boundaryRight || transform.position.x < boundaryLeft)
            {
                gameController.RestartGame();
            }
        }
    }

    // Handles the collision of the ball with other objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            // Adjust the ball's velocity based on the paddle's velocity
            Vector2 velocity = rigidBody.velocity;

            velocity.y = (rigidBody.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);

            rigidBody.velocity = velocity;
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            // Reverse the y-velocity to bounce off the wall
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, -rigidBody.velocity.y);
        }
    }

    // Resets the ball to the initial position and re-launches it
    public void ResetBall()
    {
        rigidBody.velocity = Vector2.zero;

        float ballXPosition = (Random.Range(0, 2) == 0) ? -5.0f : 5.0f;

        transform.position = new Vector3(ballXPosition, 0, 0);

        LaunchBall(ballXPosition);
    }
}
