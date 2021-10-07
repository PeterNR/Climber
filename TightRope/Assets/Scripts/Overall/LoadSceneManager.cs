using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public void LoadSceneWithName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadSceneWithIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
