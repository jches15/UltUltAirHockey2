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
 // public Transform PlayerBoundaryHolder; 
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        //startingPosition = rb.position;
        startingPosition = transform.position;
        //GetComponent<Collider>().material.bounciness = 0f;

    }

    private void FixedUpdate(){
        float movementSpeed;

        movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
        //movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
        //rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));

        targetPosition.x = thePuck.position.x;
        targetPosition.y = thePuck.position.y;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
        /*
        if(transform.position.x == 5.40){
            targetPosition.x = 3;
            targetPosition.y = thePuck.position.y;
            while(transform.position.x > 3){
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
            }
        }*/
    }
}
