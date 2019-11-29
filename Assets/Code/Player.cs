using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Movement")]
    public KeyCode moveUpKey;
    public KeyCode moveDownKey;

    public float movementSpeed = 1.0f;

    public float maxY;
    public float minY;

    [Header("Gameplay")]
    public int score = 0;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ClampPosition();
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        if (Input.GetKey(moveUpKey))
        {
            rb.velocity = Vector2.up * movementSpeed;
        }
        else if (Input.GetKey(moveDownKey))
        {
            rb.velocity = Vector2.down * movementSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void ClampPosition()
    {
        if (transform.position.y > maxY)
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }

        if (transform.position.y < minY)
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
    }
}
