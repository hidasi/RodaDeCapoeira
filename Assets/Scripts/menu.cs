using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    

    public void single()
    {
        SceneManager.LoadScene("GameSingle");
    }
    public void multi()
    {
        SceneManager.LoadScene("Loading");
    }
}
