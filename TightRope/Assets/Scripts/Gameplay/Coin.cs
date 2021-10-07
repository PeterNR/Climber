using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private  int _value;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            PlayerShip player = collision.GetComponentInParent<PlayerShip>();
            player.GatherMoney(_value);
            Destroy(gameObject);
        }
    }
}
