using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpController : MonoBehaviour
{
    public Collider2D bola;
    public float magnitude;
    public PowerUpManager manager;
    public BallController bolaSpeed;

    public Rigidbody2D bolarig;

    // Start is called before the first frame update
    void Start()
    {
        // point disini
        Debug.Log(bolarig.velocity);
        if(bolarig.velocity.x > bolaSpeed.speed.x || bolarig.velocity.x < -bolaSpeed.speed.x)
        {
            bola.GetComponent<BallController>().ResetSpeed(magnitude);
        }
        //Debug.Log("Bola speed:" + bolaSpeed.speed);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == bola)
        {
            bola.GetComponent<BallController>().ActiveSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }

}
