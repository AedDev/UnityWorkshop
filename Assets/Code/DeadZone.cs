using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Player scorePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();
        if (ball)
        {
            scorePlayer.score++;
            ball.Respawn();
        }
    }
}
