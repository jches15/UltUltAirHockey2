using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float MaxMovementSpeed;
  private Rigidbody2D rb;
  private Vector2 startingPosition;
  public Rigidbody2D Puck;
  public Transform thePuck;

  private Vector2 targetPosition; 
  private Vector2 backoff;
 // public Transform PlayerBoundaryHolder; 
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        //startingPosition = rb.position;
        startingPosition = transform.position;
        //GetComponent<Collider>().material.bounciness = 0f;

    }

    public void FixedUpdate(){
        float movementSpeed;

        movementSpeed = MaxMovementSpeed * Random.Range(0.3f, 0.6f);
        //movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
        //rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));

        targetPosition.x = thePuck.position.x;
        targetPosition.y = thePuck.position.y;
        //Debug.Log(targetPosition.x - transform.position.x);
        if(targetPosition.x - transform.position.x < -8){ 
            backoff.x = Random.Range(9f, 11f);
            backoff.y = Random.Range(0f, -1f);
            //Debug.Log(backoff.x);
            //Debug.Log(backoff.y);
            transform.position = Vector2.MoveTowards(transform.position, backoff, movementSpeed * Time.fixedDeltaTime);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
    }
    public void Goal(){
        rb.velocity = new Vector2(0,0);
    }
}
