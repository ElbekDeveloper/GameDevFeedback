using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }
        return _instance;
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
