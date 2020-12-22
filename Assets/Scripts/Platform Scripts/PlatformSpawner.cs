using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
  
    [SerializeField]
    private GameObject _platformPrefab;
    [SerializeField]
    private GameObject _spikyPlatfromPrefab;
    [SerializeField]
    private GameObject[] _movingPlatforms;
    [SerializeField]
    private GameObject _breakablePlatform;

  private float _platformSpawnTimer = 1.8f;
  private float _currentPlatformSpawnTimer;

  private int _platformSpawnCount;

  private float _minX = -2f, _maxX = 2f;

  // Start is called before the first frame update
  void Start() { _currentPlatformSpawnTimer = _platformSpawnTimer; }

  // Update is called once per frame
  void Update() {
        Spawn();
   }
  // too big mentod. can be split into separate ones to follow SRP
  // also script can be further split as here I see - Calculation when to spawn,
  // what to spawn and spawn itelf - 3 responsibilities in a single script
  
   
  protected void IncrementTimer()
    {
        _currentPlatformSpawnTimer += Time.deltaTime;
    }
    protected void ResetTimer()
    {
        _currentPlatformSpawnTimer = 0;
    }
    //Implement facade dp
  void Spawn() {
        IncrementTimer();

    if (_currentPlatformSpawnTimer >= _platformSpawnTimer) {
      // Randomize based on platform spawn count
      _platformSpawnCount++;
      Vector3 temp = transform.position;
      temp.x = Random.Range(_minX, _maxX);

      GameObject newPlatform = null;
      if (_platformSpawnCount < 2) {
        // spawn regular platform
        newPlatform =Spawner.SpawnPlatform(_platformPrefab,temp);

      } else if (_platformSpawnCount == 2) {
        // randomize
        if (Random.Range(0, 2) > 0) {
          // generate regular platform
          newPlatform = Spawner.SpawnPlatform(_platformPrefab,temp);
        } else {
          // or new moving platfrom
          newPlatform =  Spawner.SpawnPlatform(
                        _movingPlatforms[Random.Range(0, _movingPlatforms.Length)],
                        temp);
        }
      } else if (_platformSpawnCount == 3) {
        // randomize
        if (Random.Range(0, 2) > 0) {
                    // generate regular platform
                    newPlatform = Spawner.SpawnPlatform(_platformPrefab, temp);
                } else {
                    // or new spike platform
                    newPlatform = Spawner.SpawnPlatform(_spikyPlatfromPrefab, temp);
                }
      } else if (_platformSpawnCount == 4) {
        // randomize
        if (Random.Range(0, 2) > 0) {
          // generate regular platform
          newPlatform = Spawner.SpawnPlatform(_platformPrefab, temp);
        } else {
          // or new breakable platform
          newPlatform = Spawner.SpawnPlatform(_breakablePlatform, temp);
                }
        // reset the count to 0
        _platformSpawnCount = 0;
      }
      if (newPlatform) {
        newPlatform.transform.parent = transform;
      }
            ResetTimer();
    }

  } // spawn platform

} // class
