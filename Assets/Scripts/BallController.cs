using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;

    private Rigidbody2D rig;

    public Vector2 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // bole bergerak ke kanan
        // transform.position = transform.position + new Vector3(.1f, 0, 0) * Time.deltaTime;
        // bole berpindah posisi
        // transform.Translate(new Vector3(1f, 1f, 0) * Time.deltaTime);

        //ubah variabel speed vector2 menjadi vector2
        //transform.Translate(speed * Time.deltaTime);
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }
}
