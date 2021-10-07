using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{

    [SerializeField]
    private GameObject _targetObj;
    [SerializeField]
    private float _rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetDir = _targetObj.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 10, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);


    }

    // Update is called once per frame
    void Update()
    {
        //finding vector towards target
        Vector3 targetDir = _targetObj.transform.position - transform.position;
        //setting next step to rotate towards target
        float step = _rotationSpeed * Time.deltaTime;
        
        //rotating       
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
