using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromScript : MonoBehaviour {
    public float move_Speed = 2f;
    public float bound_Y = 6f;

    public bool is_Moving_Platfrom_Left,
    is_Moving_Platfrom_Right,
    is_Breakable_Platfrom,
    is_Spike_Platfrom,
    is_Platfrom;

    private Animator anim;

    void Awake () {
        if (is_Breakable_Platfrom == true) {
            anim = GetComponent<Animator> ();
        }
    }

    // Update is called once per frame
    void Update () {
        Move ();
    }

    void Move () {
        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_Y) {
            gameObject.SetActive (false);
        }
    } // move


    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);
    }


    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (is_Spike_Platfrom)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }
    } // 


    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (is_Breakable_Platfrom)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");

            }
            if (is_Platfrom)
            {
                SoundManager.instance.LandSound();

            }
        }
    }//

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (is_Moving_Platfrom_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if (is_Moving_Platfrom_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }




}//class