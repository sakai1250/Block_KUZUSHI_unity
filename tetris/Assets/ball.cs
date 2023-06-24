using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float bounceForce = 10f; // 反発力の大きさ

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bar"))
        {
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * bounceForce;
        }
    }
}


