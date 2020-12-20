using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    //why all these are public? why such naming convention?
    public GameObject platform_Prefab;
    public GameObject spike_Platform_Prefab;
    public GameObject[] moving_Platforms;
    public GameObject breakable_Platform;

    public float platform_Spawn_Timer = 1.8f;
    private float current_Platform_Spawn_Timer;

    private int platform_Spawn_Count;

    public float min_X = -2f, max_X = 2f;

    // Start is called before the first frame update
    void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }
    //too big mentod. can be split into separate ones to follow SRP
    //also script can be further split as here I see - Calculation when to spawn, what to spawn and spawn itelf - 3 responsibilities in a single script
    void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;

        if (current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            //Randomize based on platform spawn count
            platform_Spawn_Count++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;
            if (platform_Spawn_Count < 2)
            {
                //spawn regular platform
                newPlatform = Instantiate(platform_Prefab, temp, Quaternion.identity);

            }
            else if (platform_Spawn_Count == 2)
            {
                //randomize
                if (Random.Range(0,2)> 0)
                {
                    //generate regular platform
                    newPlatform = Instantiate(platform_Prefab, temp, Quaternion.identity);
                }
                else
                {
                    //or new moving platfrom
                    newPlatform = Instantiate(
                                      moving_Platforms[Random.Range(0, moving_Platforms.Length)],
                                      temp,
                                      Quaternion.identity
                                  );
                }
            }
            else if (platform_Spawn_Count == 3)
            {
                //randomize
                if (Random.Range(0, 2) > 0)
                {
                    //generate regular platform
                    newPlatform = Instantiate(platform_Prefab, temp, Quaternion.identity); //same as line 47, 56 and 92 - repetetive code - not DRY
                }
                else
                {
                    //or new spike platform
                    newPlatform = Instantiate(
                                      spike_Platform_Prefab,
                                      temp,
                                      Quaternion.identity
                                  );
                }
            }
            else if (platform_Spawn_Count == 4)
            {
                //randomize
                if (Random.Range(0, 2) > 0)
                {
                    //generate regular platform
                    newPlatform = Instantiate(platform_Prefab, temp, Quaternion.identity);
                }
                else
                {
                    //or new spike platform
                    newPlatform = Instantiate(
                                      breakable_Platform,
                                      temp,
                                      Quaternion.identity
                                  );
                }
                //reset the count to 0
                platform_Spawn_Count = 0;
            }
            if (newPlatform)
            {
                newPlatform.transform.parent = transform;

            }
            current_Platform_Spawn_Timer = 0;

        }

    } // spawn platform





} // class
