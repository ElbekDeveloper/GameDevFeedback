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
        //float horizontalMovement = GetHorizontalInput();
        //Move(horizontalMovement);
    }

    private float GetHorizontalInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    void Move(float horizontalPosition)
    {
        if (horizontalPosition > 0f)
        {
            _myBody.velocity = new Vector2(_moveSpeed, _myBody.velocity.y);
        }

        if(horizontalPosition < 0f)
        {
            _myBody.velocity = new Vector2(-_moveSpeed, _myBody.velocity.y);
        }

    } //Move




    public void PlatformMove(float x)
    {
        _myBody.velocity = new Vector2(x, _myBody.velocity.y);
    }
}// class





















