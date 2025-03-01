using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preload : MonoBehaviour
{

    public float waitTime;


    private void Start()
    {

        Invoke("WaitStartLoadGame", waitTime);

    }

    private void WaitStartLoadGame()
    {
        SceneManager.LoadScene(1);
    }

}
