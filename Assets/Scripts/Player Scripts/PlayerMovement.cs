using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D my_Body;
    public float move_Speed = 2f;

    void Awake()
    {
        my_Body = GetComponent<Rigidbody2D>();
    }
 

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }



    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            my_Body.velocity = new Vector2(move_Speed, my_Body.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            my_Body.velocity = new Vector2(-move_Speed, my_Body.velocity.y);
        }



    }//Move




    public void PlatformMove(float x)
    {
        my_Body.velocity = new Vector2(x, my_Body.velocity.y);
    }
}// class





















