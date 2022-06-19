using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;

    public bool hasScaleUp;
    public bool hasSpeedUp;

    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    public Collider2D bola;
    public PowerUpManager manager;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = GetInput();
        MoveObject(movement);
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
    }
    public void ScaleDownPaddle()
    {
        Vector3 newScale = transform.localScale;
        newScale.y /= 2f;
        transform.localScale = newScale;
    }

    // SPEED UP DOWN PADDLE
    public void SpeedUpPaddle()
    {
        int newSPD = speed * 2;
        speed = newSPD;
    }
    public void SpeedDownPaddle()
    {
        int newSPD = speed / 2;
        speed = newSPD;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == bola)
        {
            manager.paddleLastHit = this;
            this.hasScaleUp = true;
            this.hasSpeedUp = true;

            Debug.Log("hasAll true");
        }
    }

}
