using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{

    public float _minX = -2.6f, _maxX = 2.6f, _minY = -8f;
    private bool out_Of_Bounds ;
    // Update is called once per frame
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > _maxX)
        {
            temp.x = _maxX;
        }

        if (temp.x < _minX)
        {
            temp.x = _minX;
        }

        transform.position = temp;

        if (temp.y <= _minX)
        {
            if (out_Of_Bounds == false)
            {
                out_Of_Bounds = true;

                SoundManager.Instance.PlayDeathSound();
                GameManager.Instance.RestartGame();
            }
        }
    } //check bounds

        void OnTriggerEnter2D(Collider2D target)
        {
             if (target.tag == "TopSpike")
             {
                transform.position = new Vector2(1000f, 1000f);
                SoundManager.Instance.PlayDeathSound();
                GameManager.Instance.RestartGame(); 
             }
        }





}//class
