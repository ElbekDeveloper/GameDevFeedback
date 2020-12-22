using UnityEngine;

public  class Timer : MonoBehaviour
{
    public static void Increment(float timer)
    {
        timer += Time.deltaTime;
    }
    public static void Reset(float timer)
    {
        timer = 0;
    }
}
