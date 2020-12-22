using UnityEngine;

public class SoundManager : MonoBehaviour {
  private static SoundManager _instance;
  [SerializeField]
  private AudioSource _soundFX;
  [SerializeField]
  private AudioClip _landClip,
                               _deathClip,
                               _iceBreakClip, 
                               _gameOverClip;
  void Awake() {
        if (_instance == null)
        {
            _instance = this;
        }
  }

    public static SoundManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SoundManager();
        }
        return _instance;
    }
  // name of method should be verb, not noun
  public void PlayLandingSound() {
    _soundFX.clip = _landClip;
    _soundFX.Play();
  }

  public void PlayIceBreakSound() {
    _soundFX.clip = _iceBreakClip;
    _soundFX.Play();
  }

  public void PlayDeathSound() {
    _soundFX.clip = _deathClip;
    _soundFX.Play();
  }

  public void PlayGameOverSound() {
    _soundFX.clip = _gameOverClip;
    _soundFX.Play();
  }
}
