using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 moveDir;
    private Vector3 dir;
    private float distToPlayer;
    private enum State
    {
        IDLE,
        CHASE
    }
    private State state;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        state = State.IDLE;
    }
    private void Update()
    {
        distToPlayer = Vector3.Distance(player.position, transform.position);
        //do math to get location enemy needs to go
        switch (state)
        {
            case State.IDLE:
                if(distToPlayer <= 4) state = State.CHASE;
                break;
            case State.CHASE:
                dir = player.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
                dir.Normalize();
                moveDir = dir;
                if (distToPlayer >= 10) state = State.IDLE;
                break;
            default:
                if (distToPlayer <= 4) state = State.CHASE;
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.IDLE:
                break;
            case State.CHASE:
                rb.MovePosition(transform.position + (dir * moveSpeed * Time.deltaTime));
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Enemy hit something, check to see if something was player
        //if player, run hit animation
        
    }
}
