using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public string Scene;
    public void LoadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Scene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
