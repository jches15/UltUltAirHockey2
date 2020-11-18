using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    public GameObject gameOverText;
    public GameObject player;

    public GameObject puck;
    public Transform ThePuck;

    public GameObject AI;
    public Text PlayerScoreText;
    public Text AIScoreText;
    public GameObject EnemyGoalText;
    public int PlayerScore = 0;
    public int AIScore = 0;

    public bool Goal = false;
    //public GameObject AI; set this later

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        gameOverText.SetActive(false);
        EnemyGoalText.SetActive(false);
        DisplayTime(timeRemaining);
        PlayerScoreText.text = "Player: " + PlayerScore;
        AIScoreText.text = "AI: " + AIScore;
    }

    void Update()
    {
        if(Goal){
            Goal = false;
            EnemyGoalText.SetActive(false);
            Debug.Log("Here");
            Vector2 puckPosition = ThePuck.position;
            puckPosition.x = -7;
            puckPosition.y = -1;
        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                gameOverText.SetActive(true);
                player.SetActive(false);
                AI.SetActive(false);
                puck.SetActive(false); //disable them, but if game goes to OT, then reactivate
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        //if(GameObject.Find("puck").transform.position.x < -13.75){
        Vector2 puckPos = ThePuck.position;
        if(puckPos.x < -13.75){
            //Debug.Log("yup");
            puck.SetActive(false);
            EnemyGoal();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EnemyGoal(){
        EnemyGoalText.SetActive(true);
        Goal = true;
    }
 
    IEnumerator Delay(){ 
        yield return new WaitForSeconds (4f);
    }
    

}
