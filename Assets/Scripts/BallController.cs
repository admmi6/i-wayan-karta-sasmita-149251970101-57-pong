using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public bool isRight;
    public bool hasSpeedUp = false;

    public Vector2 speed;
    public Vector2 resetPosition;
    private Rigidbody2D rig;

    public float durationSpeedUpBall = 5f;
    private float timerSpeedUpBall;

    public float newMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
        timerSpeedUpBall = 0;
    }

    // Update is called once per frame
    void Update()
    {
      if(hasSpeedUp == true)
        {
            timerSpeedUpBall += Time.deltaTime;
            if(timerSpeedUpBall > durationSpeedUpBall)
            {
                ResetSpeed(newMagnitude);
                hasSpeedUp = false;
                timerSpeedUpBall = 0;
            }
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Paddle Kanan")
        {
            isRight = true;
        }
        if(collision.gameObject.tag == "Paddle Kiri")
        {
            isRight = false;
        }
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }

    public void ActiveSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
        hasSpeedUp = true;
        newMagnitude = magnitude;
    }

    public void ResetSpeed(float magnitude)
    {
        rig.velocity /= magnitude;
        hasSpeedUp = false;
    }
}
