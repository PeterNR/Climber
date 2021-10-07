using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _damage;

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDir = transform.position+ transform.forward;
        float step = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, movementDir, step);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerShip player = collision.GetComponentInParent<PlayerShip>();
            player.LoseHealth(_damage);
        }
    }
}
