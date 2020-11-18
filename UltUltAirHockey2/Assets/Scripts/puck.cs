 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puck : MonoBehaviour
{
    Rigidbody2D rb;
    //GameObject puckk;
    float speed = 55;
    public Transform player;
    public Transform enemy;
    public float ydirPuck;


    public Score ScoreInstance;
    public static bool WasGoal {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = transform.position - enemy.position;
        //Debug.Log(dir.x);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!WasGoal)
        {
            if(other.tag == "AIGoal")
            {
                ScoreInstance.Increment(Score.Scores.PlayerScore);
                WasGoal = true;
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreInstance.Increment(Score.Scores.AiScore);
                WasGoal = true;
              
            }
        }

    }
    
    //player and enemy hitting mechanics
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "player"){
                Vector2 dir = player.position - transform.position;
                if(dir.y > 0){ //ball is below player
                    ydirPuck = Random.Range(-1, -20);
                    Debug.Log(ydirPuck);
                    rb.AddForce(new Vector2(speed, ydirPuck), ForceMode2D.Impulse);
                }
                else if(dir.y == 0){ //if puck is right in front of player (unlikely)
                    rb.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
                }
                else{ //ball is above player
                    ydirPuck = Random.Range(1, 20);
                    Debug.Log(ydirPuck);
                    rb.AddForce(new Vector2(speed, ydirPuck), ForceMode2D.Impulse);
                }
                //rb.AddForce(new Vector2(speed, 10), ForceMode2D.Impulse);
        }
        else if(col.gameObject.tag == "enemy"){
            Vector2 dir = transform.position - enemy.position;
                if(dir.y > 0){ //ball is below player
                    ydirPuck = Random.Range(-1, -20);
                    Debug.Log(ydirPuck);
                    rb.AddForce(new Vector2(-speed, ydirPuck), ForceMode2D.Impulse);
                }
                else if(dir.y == 0){ //if puck is right in front of player (unlikely)
                    rb.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
                }
                else{ //ball is above player
                    ydirPuck = Random.Range(1, 20);
                    Debug.Log(ydirPuck);
                    rb.AddForce(new Vector2(-speed, ydirPuck), ForceMode2D.Impulse);
                }
                //rb.AddForce(new Vector2(speed, 10), ForceMode2D.Impulse);
        }

    }

    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0,0);
    }
}
