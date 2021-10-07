using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int Damage;

    private Ship _mainShip;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerShip player = collision.GetComponentInParent<PlayerShip>();
            player.LoseHealth(Damage);
        }
    }
}
