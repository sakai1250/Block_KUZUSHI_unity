using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 initialVelocity = new Vector2(0f, -5f); // 初期速度
    private Vector2 previousVelocity; // 前フレームの速度

    public float bounceForce = 10f; // 反発力の大きさ

    private Rigidbody2D rb;
    private Vector2 initialPosition;

    private bool shouldResetBall; // リセットフラグ

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void Start()
    {
        ResetBall();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldResetBall = true;
        }
    }

    private void FixedUpdate()
    {
        previousVelocity = rb.velocity;

        if (shouldResetBall)
        {
            ResetBall();
            shouldResetBall = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bar"))
        {
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            Bounce(direction);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 reflection = Vector2.Reflect(previousVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = reflection.normalized * previousVelocity.magnitude;
        }
    }

    private void ResetBall()
    {
        transform.position = initialPosition;
        rb.velocity = initialVelocity;
        rb.angularVelocity = 0f;
    }

    private void Bounce(Vector2 direction)
    {
        rb.velocity = direction * previousVelocity.magnitude;
    }
}

