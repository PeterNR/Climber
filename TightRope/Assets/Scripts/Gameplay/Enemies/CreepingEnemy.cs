using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepingEnemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * _speed*Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerShip player = collision.GetComponentInParent<PlayerShip>();
            player.LoseHealth(_damage);
        }
    }
}
