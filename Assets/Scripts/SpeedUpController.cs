using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpController : MonoBehaviour
{
    
    public float magnitude;
    public Collider2D bola;
    public PowerUpManager manager;
    public BallController bolaSpeed;
    public Rigidbody2D bolaRig;

    // Start is called before the first frame update
    void Start()
    {
        // STARTIING POINT RESET ALL SPAWN DISINI
        if(bolaRig.velocity.x > bolaSpeed.speed.x || bolaRig.velocity.x < -bolaSpeed.speed.x)
        {
            bola.GetComponent<BallController>().ResetSpeed(magnitude);
        }
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
