using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _myBody;

    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void PlatformMove(float x)
    {
        _myBody.velocity = new Vector2(x, _myBody.velocity.y);
    }
}// class





















