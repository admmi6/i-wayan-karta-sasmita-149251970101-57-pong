using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public Collider2D bola;
    public bool isRight;
    public ScoreManagerController manager;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == bola)
        {
            if (isRight)
            {
                manager.AddRightScore(1);
            } 
            else
            {
                manager.AddLeftScore(1);
            }
        }
    }
}
