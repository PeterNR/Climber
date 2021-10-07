using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private Vector3 _direction, _originalPos;
    private float _directionX, _directionY;
    private bool _positiveDirection = true;
    private List<GameObject> _hooks = new List<GameObject>();
    private Rope _ropeManager;

    public float MovingDistance, MovingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _direction = Random.insideUnitCircle.normalized;
        _originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveMeteor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hook")
        {
            _hooks.Add(collision.transform.parent.gameObject);
            if(_ropeManager == null)
            {
                _ropeManager = _hooks[0].GetComponent<Hook>().RopeManager;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Hook")
        {
            _hooks.Remove(collision.transform.parent.gameObject);
        }
    }

    private void MoveMeteor()
    {
        //setting direction
        var movementVector = Vector3.zero;
        if (_positiveDirection)
        {
            movementVector = _direction ;
        }
        else
        {
            movementVector = -_direction ;
        }
        //setting target position
        Vector3 target = _originalPos + movementVector * MovingDistance/2;
        float step = MovingSpeed*Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        //checking if it needs to turn
        float distanceFromCenter = Vector3.Distance(_originalPos, transform.position);
        if (distanceFromCenter >= MovingDistance/2.01)
        {
            _positiveDirection = !_positiveDirection;
            transform.position = target;
        }

        MoveHooks(target, step);
    }

    private void MoveHooks(Vector3 target, float step)
    {
        if(_hooks.Count > 0 && !_ropeManager.IsShooting)
        {
            foreach (GameObject hook in _hooks)
            {
                hook.transform.position = Vector3.MoveTowards(transform.position, target, step) ;
            }
        }
    }
}
