using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float moveSpeed;

    private void Update()
    {
        //do math to get location enemy needs to go
    }

    private void FixedUpdate()
    {
        //move enemy
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Enemy hit something, check to see if something was player
        //if player, run hit animation
        
    }
}
