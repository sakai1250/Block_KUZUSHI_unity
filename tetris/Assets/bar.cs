using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector3 initialPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void ResetBar()
    {
        transform.position = initialPosition;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f) * moveSpeed;
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetBar();
        }

    }
}
