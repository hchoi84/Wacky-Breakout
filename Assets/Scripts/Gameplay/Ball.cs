using UnityEngine;
/// <summary>
/// For moving the ball
/// </summary>
public class Ball : MonoBehaviour
{
    private float moveAngle = 20f;
    private float waitToMoveTime = 1f;
    private float waitedToMoveTime = 0f;
    private bool ballMoved = false;

    private Rigidbody2D myRigidbody2D = default;
    private Timer timer = default;
    BallSpawner ballSpawner = default;

    private void Start()
    {
        // initial ball velocity when the game starts
        myRigidbody2D = GetComponent<Rigidbody2D>();

        ballSpawner = FindObjectOfType<BallSpawner>();

        // setting ball lifetime
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = ConfigurationUtils.BallLifetime;
        timer.Run();
    }

    // from paddle.cs
    public void SetDirection(Vector2 dir)
    {
        // direction of the ball based on where it hit the paddle
        myRigidbody2D.velocity = myRigidbody2D.velocity.magnitude * dir;
    }

    private void Update()
    {
        MoveBall();
        DestroySelf();
    }

    private void MoveBall()
    {
        waitedToMoveTime += Time.deltaTime;
        bool moveBall = waitedToMoveTime >= waitToMoveTime;
        if (moveBall && !ballMoved)
        {
            Vector2 velocity = new Vector2(Mathf.Cos(moveAngle), Mathf.Sin(moveAngle));
            myRigidbody2D.AddForce(velocity * ConfigurationUtils.BallImpulseForce);
            ballMoved = true;
        }
    }

    private void DestroySelf()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }

        if(transform.position.y < (ScreenUtils.ScreenBottom - 2))
        {
            HUD.BallLeftScreen();
            ballSpawner.SpawnNewBall();
            Destroy(gameObject);
        }
    }
}
