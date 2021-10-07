using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnQuitBtn()
    {
        Application.Quit();
    }

    public void EnterLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
