using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromScript : MonoBehaviour {
  public float move_Speed = 2f;
  public float bound_Y = 6f;

  public bool is_Moving_Platfrom_Left, is_Moving_Platfrom_Right,
      is_Breakable_Platfrom, is_Spike_Platfrom, is_Platfrom;

  private Animator anim;

  void Awake() {
    if (is_Breakable_Platfrom == true) {
      anim = GetComponent<Animator>();
    }
  }

  // Update is called once per frame
  void Update() { Move(); }
  // moving every single platform is not a good idea. 100 platforms - 100 calls
  // to update - performance not efficient. better having a single object that is
  // moving and it has platform objs as children
  void Move() {
    Vector2 temp = transform.position;
    temp.y += move_Speed * Time.deltaTime;
    transform.position = temp;

    if (temp.y >= bound_Y) {
      gameObject.SetActive(false);
    }
  } // move

  void BreakableDeactivate() {
    Invoke("DeactivateGameObject", 0.3f); // magic strings is bad idea, if you
                                          // rename method - will not work
  }

  void DeactivateGameObject() {
    SoundManager.Instance
        .PlayIceBreakSound(); // singletons used in that way is also not good for
                          // architecture - makes your components strongly
                          // dependant from each other
    gameObject.SetActive(false);
  }

  void OnTriggerEnter2D(Collider2D target) {
    if (target.tag == "Player") {
      if (is_Spike_Platfrom) {
        target.transform.position = new Vector2(1000f, 1000f);
        SoundManager.Instance.PlayGameOverSound();
        GameManager.instance.RestartGame();
      }
    }
  } //

  void OnCollisionEnter2D(Collision2D target) {
    if (target.gameObject.tag == "Player") {
      if (is_Breakable_Platfrom) {
        SoundManager.Instance.PlayLandingSound();
        anim.Play("Break");
      }
      if (is_Platfrom) {
        SoundManager.Instance.PlayLandingSound();
      }
    }
  } //

  void OnCollisionStay2D(Collision2D target) {
    if (target.gameObject.tag == "Player") {
      if (is_Moving_Platfrom_Left) {
        target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
      }
      if (is_Moving_Platfrom_Right) {
        target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
      }
    }
  }

  // many responsibilities in a single script

} // class
