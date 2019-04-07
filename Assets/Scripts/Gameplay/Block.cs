using UnityEngine;
using System.Collections;
/// <summary>
/// for block behaviors
/// </summary>
public class Block : MonoBehaviour
{
    private const string BallTag = "Ball";
    protected int score;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy the block if hit by the ball
        bool isBall = collision.gameObject.CompareTag(BallTag);
        if (isBall)
        {
            HUD.AddScore(score);
            Destroy(gameObject);
        }
    }
}
