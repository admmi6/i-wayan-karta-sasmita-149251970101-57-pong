using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;

    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //set default paddle speed - ketika tombol ditwkan akan berjalan dan berhenti ketika dilepas
        // Vector3 movement = Vector3.zero;
        // mengambil input keyboard
        // if (Input.GetKey(KeyCode.W)) { movement = Vector3.up * speed; }
        // if (Input.GetKey(KeyCode.S)) { movement = Vector3.down * speed; }
        // transform.Translate(movement * Time.deltaTime);

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
        rig.velocity = movement;
    }
}
