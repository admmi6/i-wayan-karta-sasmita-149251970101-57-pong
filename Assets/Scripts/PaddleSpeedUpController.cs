using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpeedUpController : MonoBehaviour
{
    [Header("CATATAN")]

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
        if (collision == bola)
        {
            if (bola.GetComponent<BallController>().isRight == true)
            {
                padKanan.GetComponent<PaddleController>().SpeedUpPaddle();
            }
            if (bola.GetComponent<BallController>().isRight == false)
            {
                padKiri.GetComponent<PaddleController>().SpeedUpPaddle();
            }

            manager.RemoveSpeedUpPaddle(gameObject);
        }
    }


}
