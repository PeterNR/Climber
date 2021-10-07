using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLevel : MonoBehaviour
{
    private GameManager _gm;
    private Ship _ship;
    [SerializeField]


    private void Awake()
    {
        _gm = GetComponent<GameManager>();

        if (_gm.MainShip == null)
        {
            _gm.MainShip = _ship;
        }
    }

}
