using UnityEngine;

public class SoundManager : MonoBehaviour {
  public static SoundManager Instance;
  [SerializeField]
  private AudioSource _soundFX;
  [SerializeField]
  private AudioClip _landClip,
                               _deathClip,
                               _iceBreakClip, 
                               _gameOverClip;
  void Awake() {
    if (Instance == null) {
      Instance = this;
    }
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
