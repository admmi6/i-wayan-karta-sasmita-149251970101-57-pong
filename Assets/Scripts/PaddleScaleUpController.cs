using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScaleUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public PaddleController padKiri;
    public PaddleController padKanan;
    public Collider2D bola;

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
            if(bola.GetComponent<BallController>().isRight == true)
            {
                padKanan.GetComponent<PaddleController>().ScaleUpPaddle();
            }
            if(bola.GetComponent<BallController>().isRight == false)
            {
                padKiri.GetComponent<PaddleController>().ScaleUpPaddle();
            }

            manager.RemoveScaleUpPaddle(gameObject);
        }
    }

}
