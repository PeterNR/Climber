using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance;

    public Ship MainShip;
    public LoadSceneManager SceneLoader;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = gameObject.GetComponent<GameManager>();
            DontDestroyOnLoad(Instance);
            MainShip = GetComponent<Ship>();
            SceneLoader = GetComponent<LoadSceneManager>();
        }
        else
        {
            Destroy(gameObject);
        }
        
    }




}
