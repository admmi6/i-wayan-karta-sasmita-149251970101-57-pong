using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpeedUpController : MonoBehaviour
{
    [Header("CATATAN")]

    public PowerUpManager manager;
    public Collider2D bola;

    //public int newSpeedPaddleValue;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Paddle speed up");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == bola)
        {
            if (manager.paddleLastHit)
            {
                manager.paddleLastHit.SpeedUpPaddle();
            }
            manager.RemoveSpeedUpPaddle(gameObject);
        }
    }


}
