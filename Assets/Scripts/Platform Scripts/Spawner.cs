using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static GameObject SpawnPlatform(GameObject platformType, Vector3 tempPosition)
    {
        return Instantiate(platformType, tempPosition, Quaternion.identity);
    }
}
