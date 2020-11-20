using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puck : MonoBehaviour
{
    Rigidbody2D rb;

    float speed = 55;
    public Transform player;
    public Transform enemy;
    public float ydirPuck;

    public GameObject EnemyGoalText;
    public GameObject PlayerGoalText;

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
                //transform.SetActive(false);
                //puck.SetActive(false);
                EnemyGoal();
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreInstance.Increment(Score.Scores.AiScore);
                WasGoal = true;
                //transform.SetActive(false);
                PlayerGoal();
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

    void EnemyGoal(){
        //Debug.Log("heree");
        EnemyGoalText.SetActive(true);
        //Goal = true;
        Invoke("Deactivate", 2);
    }

    void PlayerGoal(){
        PlayerGoalText.SetActive(true);
        Invoke("Deactivate",  2);
        //Goal = true;
    }

    private void Deactivate(){
        EnemyGoalText.SetActive(false);
        PlayerGoalText.SetActive(false);
        //Debug.Log("deactivate");
        //puck.SetActive(true);
        transform.position = new Vector2(0,0);
        rb.velocity = new Vector2(0,0);
        WasGoal = false;
    }
}
