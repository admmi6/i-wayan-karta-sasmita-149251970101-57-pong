using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;

    public bool hasScaleUp = false;
    public bool hasSpeedUp = false;

    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    public Collider2D bola;
    public PowerUpManager manager;

    private float durationPaddle = 5f;
    private float timerPaddle;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        timerPaddle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = GetInput();
        MoveObject(movement);

        if(hasScaleUp == true)
        {
            timerPaddle += Time.deltaTime;
            Debug.Log("Timer Scale: " + timerPaddle);
            if(timerPaddle > durationPaddle)
            {
                hasScaleUp = false;
                ScaleDownPaddle();
                timerPaddle = 0;
            }
        }

        if(hasSpeedUp == true)
        {
            timerPaddle += Time.deltaTime;
            if(timerPaddle > durationPaddle)
            {
                hasSpeedUp = false;
                SpeedDownPaddle();
                timerPaddle = 0;
            }
        }
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey)) 
        { 
            return Vector2.up * speed; 
        }
        else if (Input.GetKey(downKey)) 
        {
            return Vector2.down * speed; 
        }
        return Vector2.zero;
    }
    private void MoveObject(Vector2 movement)
    {
        // transform.Translate(movement * Time.deltaTime);
        // Debug.Log("Tes: " + movement);
        rig.velocity = movement;
    }


    // SCALE UP DOWN PADDLE
    public void ScaleUpPaddle()
    {
        Vector3 newScale = transform.localScale;
        newScale.y *= 2f;
        transform.localScale = newScale;
        hasScaleUp = true;
    }
    public void ScaleDownPaddle()
    {
        Vector3 newScale = transform.localScale;
        newScale.y /= 2f;
        transform.localScale = newScale;
        hasScaleUp = false;
    }

    // SPEED UP DOWN PADDLE
    public void SpeedUpPaddle()
    {
        int newSPD = speed * 2;
        speed = newSPD;
        hasSpeedUp = true;
    }
    public void SpeedDownPaddle()
    {
        int newSPD = speed / 2;
        speed = newSPD;
        hasSpeedUp = false;
    }


}
