using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rig;
    public Vector2 resetPosition;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
      
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
    }

    public void ResetSpeed(float magnitude)
    {
        rig.velocity /= magnitude;
    }
}
