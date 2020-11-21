using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puck : MonoBehaviour
{
    Rigidbody2D rb;
    Rigidbody2D enemyRb;

    float speed = 55;
    public Transform player;
    public Transform enemy;
    public float ydirPuck;

    public Enemy stop;

    public GameObject EnemyGoalText;
    public GameObject PlayerGoalText;

    public Score ScoreInstance;
    public static bool WasGoal {get; private set;}

    public bool GoalPlayer = false;
    public bool GoalEnemy = false;

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
        //moveAgain.GetComponent<Enemy>().FixedUpdate();
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
        transform.gameObject.SetActive(false);
        //enemy.gameObject.SetActive(false);
        //player.gameObject.SetActive(false);
        EnemyGoalText.SetActive(true);
        GoalEnemy = true;
        stop.Goal();
        Invoke("Deactivate", 2);
    }

    void PlayerGoal(){
        PlayerGoalText.SetActive(true);
        //enemy.gameObject.SetActive(false);
        //player.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
        stop.Goal();
        Invoke("Deactivate",  2);
        GoalPlayer = true;
    }

    private void Deactivate(){
        //enemyRb = enemy.GetComponent<Rigidbody2D>();
        //enemyRb.velocity = new Vector2(0,0);
        transform.gameObject.SetActive(true);
        //enemy.gameObject.SetActive(true);
        //player.gameObject.SetActive(true);
        //player.position = new Vector2(-10, -1.32f);
        //enemy.position = new Vector2(10, -1.32f);
        if(GoalEnemy == true){
            EnemyGoalText.SetActive(false);
            transform.position = new Vector2(-7,-1);
            GoalEnemy = false;
        }
        else{
            PlayerGoalText.SetActive(false);
            transform.position = new Vector2(7,-1);
            GoalPlayer = false;
        }
        //EnemyGoalText.SetActive(false);
        //PlayerGoalText.SetActive(false);
        //Debug.Log("deactivate");
        //puck.SetActive(true);
        //transform.position = new Vector2(0,0);
        stop.FixedUpdate();
        rb.velocity = new Vector2(0,0);
        WasGoal = false;
    }
}
