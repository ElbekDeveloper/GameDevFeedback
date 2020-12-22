using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _myBody;
    private float _moveSpeed = 2f;

    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
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
            _myBody.velocity = new Vector2(_moveSpeed, _myBody.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            _myBody.velocity = new Vector2(-_moveSpeed, _myBody.velocity.y);
        }



    }//Move




    public void PlatformMove(float x)
    {
        _myBody.velocity = new Vector2(x, _myBody.velocity.y);
    }
}// class





















