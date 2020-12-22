using UnityEngine;

public class PlatfromScript : MonoBehaviour {
  private float _moveSpeed = 2f;
  private float _boundY = 6f;

  private bool _isMovingPlatfromLeft, 
                      _isMovingPlatfromRight,
                      _isBreakablePlatfrom, 
                      _isSpikePlatfrom,
                      _isPlatfrom;

  private Animator _animator;

  void Awake() {
    if (_isBreakablePlatfrom == true) {
      _animator = GetComponent<Animator>();
    }
  }

  // Update is called once per frame
  void Update() { Move(); }

  void Move() {
    Vector2 temp = transform.position;
    temp.y += _moveSpeed * Time.deltaTime;
    transform.position = temp;

    if (temp.y >= _boundY) {
      gameObject.SetActive(false);
    }
  } // move

  void DeactivateBreakablePlatform() {
    Invoke("DeactivateGameObject", 0.3f); 
  }

  void DeactivateGameObject() {
    SoundManager.GetInstance().PlayIceBreakSound(); 
    gameObject.SetActive(false);
  }

  void OnTriggerEnter2D(Collider2D target) {
    if (target.tag == TagList.Player) {
      if (_isSpikePlatfrom) {
        target.transform.position = new Vector2(1000f, 1000f);
        SoundManager.GetInstance().PlayGameOverSound();
        GameManager.GetInstance().RestartGame();
      }
    }
  } //

  void OnCollisionEnter2D(Collision2D target) {
    if (target.gameObject.tag == TagList.Player) {
      if (_isBreakablePlatfrom) {
        SoundManager.GetInstance().PlayLandingSound();
        _animator.Play("Break");
      }
      if (_isPlatfrom) {
        SoundManager.GetInstance().PlayLandingSound();
      }
    }
  } // 

  void OnCollisionStay2D(Collision2D target) {
    if (target.gameObject.tag ==TagList.Player) {
      if (_isMovingPlatfromLeft) {
        target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
      }
      if (_isMovingPlatfromRight) {
        target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
      }
    }
  }

  // many responsibilities in a single script

} // class
