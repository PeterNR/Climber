using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class Rope : MonoBehaviour
{
    [SerializeField]
    private int _numberOfRopes;
    [SerializeField]
    private Text _ropeText;
    [SerializeField]
    private List<Transform> _hooks;
    private int _hookIndex = 0;
    [SerializeField]
    private float _ropeSpeed, _shipSpeed;
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private List<LineRenderer> _lines;
    [SerializeField]
    private List<GameObject> _indicators;
    [SerializeField]
    private GameObject _leftHook;
    [SerializeField]
    private UnityEvent _gameOver;


    private Vector3 _hookCenter;

    private bool _isShooting = false, _centreReached = true, _obstacleReached;

    public bool IsShooting { get { return _isShooting; } }

    [SerializeField]
    private PlayerShip _player;



    // Start is called before the first frame update
    void Start()
    {
        _numberOfRopes = GameManager.Instance.MainShip.MaxRopes;
        _hookCenter = Vector3.zero;
        _ropeText.text = _numberOfRopes.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")&& _player.CurrentAction == ChosenAction.Rope && _numberOfRopes>0 && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider!=null)
            {
                //Debug.Log(hit.collider.name + " was clicked");
                if (hit.collider.tag == "Meteor")
                {
                    Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
                    ShootRope(mousePos);
                }
            }
        }

        MovePlayerCharacter();
        DrawRopes();
    }

    private void MovePlayerCharacter()
    {
        FindHookCenter();
        bool _isCentered = Vector3.Magnitude(transform.position - _hookCenter) < 0f;
        if (!_isShooting && !_isCentered)
        {
            float step = _shipSpeed * Time.deltaTime;
            transform.parent.position = Vector3.MoveTowards(transform.position, _hookCenter, step);
            
            if (Vector3.Magnitude(transform.position - _hookCenter) < 0.1f)
            {
                if (_numberOfRopes <= 0)
                {
                    _gameOver.Invoke();
                }
            }
        }
    }

    public void ShootRope(Vector3 aimPos)
    {
        //_hooks[_hookIndex].GetComponentInChildren<Hook>().IsHooked = false;
        //_isCentered = false;
        _isShooting = true;
        Transform hook = _hooks[_hookIndex].GetComponent<Transform>();
        hook.position = transform.position;

        StartCoroutine(ShootHook(hook, aimPos));

        _indicators[_hookIndex].SetActive(false);

        _hookIndex++;

        if (_hookIndex>= _hooks.Count)
        {
            _hookIndex = 0;
        }

        _indicators[_hookIndex].SetActive(true);

    }

    private void DrawRopes()
    {
        int index = 0;
        _lines[0].SetPosition(0, transform.position);
        _lines[0].SetPosition(1, transform.position);
        foreach(Transform hook in _hooks)
        {
            Debug.DrawLine(transform.position, hook.transform.position, Color.cyan, 0, true);
            _lines[index].SetPosition(0, transform.position);
            _lines[index].SetPosition(1, hook.transform.position);
            index++;
        }
    }

    private IEnumerator ShootHook(Transform hook, Vector3 target)
    {
        Vector3 distance =  target - transform.position;
        _obstacleReached = false;
        Vector3 dir = Vector3.Normalize(distance);
        while (Vector3.Magnitude(transform.position - hook.position) < distance.magnitude && !_obstacleReached)
        {
            hook.position += dir * _ropeSpeed*Time.deltaTime;
            yield return null;
        }

        FindHookCenter();

        _numberOfRopes--;
        _ropeText.text = _numberOfRopes.ToString();
        //Instantiate(_leftHook, hook.position, Quaternion.identity);

        _isShooting = false;
    }

    public void StopHook()
    {
        _obstacleReached = true;
    }

    private void FindHookCenter()
    {
        _hookCenter = Vector3.zero;
        foreach (Transform h in _hooks)
        {
            _hookCenter += h.transform.position;
        }
        _hookCenter /= _hooks.Count;
    }
}
