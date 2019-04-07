using UnityEngine;
/// <summary>
/// Controls the paddle from users input
/// </summary>

public class Paddle : MonoBehaviour
{
    #region fields
    private Rigidbody2D myRigidbody2D = default;
    private BoxCollider2D myBoxCollider2D = default;
    private float paddleColliderHalfWidth = 0;

    private const string Horizontal = "Horizontal";
    private const string BallTag = "Ball";
    private const float BounceAngleHalfRange = Mathf.Deg2Rad * 60;

    #endregion

    #region methods
    private void Start()
    {
        // cache components
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();

        // stores half the size of collider for clamping 
        paddleColliderHalfWidth = myBoxCollider2D.size.x / 2;
    }

    private void Update()
    {
        ClampPaddle();
    }

    private void FixedUpdate()
    {
        // move the paddle using Rigidbody2D based on users Horizontal input
        float inputHor = Input.GetAxis(Horizontal);
        if(inputHor != 0)
        {
            Vector2 input = new Vector2(inputHor, 0) * ConfigurationUtils.PaddleMoveUnitsPerSecond;
            myRigidbody2D.MovePosition(myRigidbody2D.position + input * Time.fixedDeltaTime);
        }
    }

    private void ClampPaddle()
    {
        // clamp the paddle to prevent going out of the screen
        Vector2 paddlePos = transform.position;
        float xClamp = Mathf.Clamp(paddlePos.x, ScreenUtils.ScreenLeft + paddleColliderHalfWidth, ScreenUtils.ScreenRight - paddleColliderHalfWidth);
        transform.position = new Vector2(xClamp, paddlePos.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: prevent ball from bouncing off of bottom
        // sets the ball direction based on where it hit the paddle
        BallHitPaddlePos(collision);
    }

    private void BallHitPaddlePos(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            // detect if the ball hit top of the paddle
            bool ballHitTop = ball.transform.position.y > transform.position.y - 0.05f;
            if (ballHitTop)
            {
                float ballOffsetFromPaddle = (transform.position.x - ball.transform.position.x) / paddleColliderHalfWidth;
                float angleOffset = ballOffsetFromPaddle * BounceAngleHalfRange;
                float angle = Mathf.PI / 2 + angleOffset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                ball.SetDirection(direction);
            }
        }
    }
    #endregion
}
