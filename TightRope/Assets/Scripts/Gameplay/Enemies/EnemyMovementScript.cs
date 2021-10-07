using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    [SerializeField]
    private GameObject _playerObject;
    private GameObject _bounceObject;
    private bool _isBouncing = false;

    [SerializeField]
    private float _topFollowSpeed, _followProximity, _bounceTime;
    private float _topBounceSpeed;
    private Coroutine _bouncing;
    // Start is called before the first frame update
    void Start()
    {
        _topBounceSpeed = _topFollowSpeed*2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isBouncing)
        {
            FollowPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag ==  "Meteor")
        {
            if(_bounceObject != null)
            {
                StopCoroutine(_bouncing);
            }

            _bouncing = StartCoroutine(BounceOff(collision.transform, _topBounceSpeed, _bounceTime));
        }
        if(collision.tag == "Player")
        {
            PlayerShip player = collision.GetComponentInParent<PlayerShip>();
            player.LoseHealth(_damage);
        }
    }

    private void FollowPlayer()
    {
        float proximity = Vector3.Distance(transform.position, _playerObject.transform.position);
        if (proximity<_followProximity)
        {
            float step = _topFollowSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _playerObject.transform.position, step);
        }
    }

    private IEnumerator BounceOff(Transform otherObject, float bounceSpeed, float bounceTime)
    {
        _isBouncing = true;
        _bounceObject = otherObject.gameObject;

        Vector3 direction = new Vector3(transform.position.x - otherObject.position.x, transform.position.y - otherObject.position.y, 0).normalized;
        while (bounceTime>0)
        {
            transform.position += direction * bounceSpeed * bounceTime * Time.deltaTime;
            bounceTime -= Time.deltaTime;
            yield return null;
        }
        _isBouncing = false;
    }
}
