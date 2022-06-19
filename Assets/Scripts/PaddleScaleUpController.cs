using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScaleUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D bola;

    //public int newScalePaddleValue;

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
        if(collision == bola)
        {
            if (manager.paddleLastHit)
            {
                manager.paddleLastHit.ScaleUpPaddle();
            }
            manager.RemoveScaleUpPaddle(gameObject);
        }
    }

}
