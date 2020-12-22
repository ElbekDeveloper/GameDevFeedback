using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _myBody;
    private float _moveSpeed = 2f;

    public void Move(float horizontalPosition)
    {
        if (horizontalPosition > 0f)
        {
            _myBody.velocity = new Vector2(_moveSpeed, _myBody.velocity.y);
        }

        if (horizontalPosition < 0f)
        {
            _myBody.velocity = new Vector2(-_moveSpeed, _myBody.velocity.y);
        }
    }
}