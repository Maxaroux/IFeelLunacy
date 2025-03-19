using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{    
    public void loadScene(String sceneName)
    {
        Debug.Log("sceneName to load: " + sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}