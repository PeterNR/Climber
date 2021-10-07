using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretBehaviour : MonoBehaviour
{

    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private float _shootingInterval;
    private float _shootingTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot(_projectile);
    }

    private void Shoot(GameObject projectile)
    {
        _shootingTimer -= Time.deltaTime;
        if (_shootingTimer<0)
        {
            _shootingTimer = _shootingInterval;

            Instantiate(projectile, transform.position, transform.rotation);
        }

    }
}
