using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public float ballSpeed = 25.0f; // Target Magnitude
    public float ballDead = 0.25f; // X velocity the ball will respawned

    public float BallSpeedDifficulty
    {
        get
        {
            return ballSpeed * difficultyMultiplier;
        }
    }

    private float difficultyMultiplier = 1.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) < ballDead)
            Respawn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        difficultyMultiplier += 0.01f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        float difference = 1.0f - (rb.velocity.magnitude / BallSpeedDifficulty);
        
        if (difference < 0)
            rb.velocity = rb.velocity - (rb.velocity * -difference);
        else
            rb.velocity = rb.velocity + (rb.velocity * difference);
    }

    public void Respawn()
    {
        transform.position = Vector2.zero;
        transform.rotation = Quaternion.identity;

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f;

        difficultyMultiplier = 1.0f;

        int startDirection = Random.Range(0, 2);
        if (startDirection == 0)
            rb.AddForce(Vector3.left * BallSpeedDifficulty, ForceMode2D.Impulse);
        else
            rb.AddForce(Vector3.right * BallSpeedDifficulty, ForceMode2D.Impulse);
    }
}
