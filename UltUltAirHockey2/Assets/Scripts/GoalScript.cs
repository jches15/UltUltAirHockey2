using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public Transform puck;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(puck.GetComponent<CircleCollider2D>(), transform.GetComponent<BoxCollider2D>());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
