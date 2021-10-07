using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    private LoadSceneManager _sceneManager;

    private void Awake()
    {
        _sceneManager = GetComponent<LoadSceneManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.SceneLoader.LoadSceneWithName("LevelMenu");
        }
    }
}
