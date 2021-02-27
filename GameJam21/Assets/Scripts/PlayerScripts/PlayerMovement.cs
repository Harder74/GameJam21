using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    private Vector2 moveDir;

    private bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Move();

        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY);

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        if(moveDir.x > 0)
        {
            rb.transform.localScale = new Vector3(-.3f, rb.transform.localScale.y, 1);
        }
        else if(moveDir.x < 0)
        {
            rb.transform.localScale = new Vector3(.3f, rb.transform.localScale.y, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().EndGame();
            canMove = false;
        }
    }
}