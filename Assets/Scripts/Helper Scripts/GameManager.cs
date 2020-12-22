using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void RestartGame()
    {
        Invoke("RestartAfterTime", 3f);
    }


    void RestartAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");

    }

















}//class
