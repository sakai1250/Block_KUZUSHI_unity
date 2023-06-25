using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball : MonoBehaviour
{
    public Vector2 initialVelocity = new Vector2(0f, -5f); // 初期速度
    private Vector2 previousVelocity; // 前フレームの速度

    private Rigidbody2D rb;
    private Vector2 initialPosition;

    private bool shouldResetBall = true; // リセットフラグ
    private bool ignore = true; // 最初だけ勝手に死ぬので

    private int ballCount; // ボールの個数
    public int initialballCount = 5; // 初期ボールの個数

    float tolerance = 0.02f; // 以下の時にゲーム中止

    [SerializeField]
    public TextMeshProUGUI ballCountText; // 残りボール個数を表示するUIテキスト
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void Start()
    {
        ballCount = initialballCount;
        UpdateBallCountText(); // 残りボール個数の表示を更新

        ResetBall();
    }

    private void UpdateBallCountText()
    {
        ballCountText.text = "Balls: " + ballCount.ToString();
    }

    private void Update()
    {
        previousVelocity = rb.velocity;

        if (Input.GetKeyDown(KeyCode.Space) || ballCount <= 0)
        {
            shouldResetBall = true;
        }

        else if (!GetComponent<SpriteRenderer>().isVisible || rb.velocity.magnitude <= tolerance)
        {
            if (ignore)
            {
                ignore = false;
            }

            else
            {
                ballCount--;

                ResetBall();
                UpdateBallCountText();
            }
        }
    }

    private void FixedUpdate()
    {
        if (shouldResetBall)
        {
            shouldResetBall = false;
            
            ballCount = initialballCount;
            ResetBall();
            UpdateBallCountText(); // 残りボール個数の表示を更新

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
        else if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject); // ブロックを削除する
            BlockManager.Instance.DecreaseBlockCount(); // ブロックの残り個数を減らす

            Vector2 direction = (transform.position - collision.transform.position).normalized;
            Bounce(direction);

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

