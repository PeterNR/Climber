using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Rope RopeManager;
    public bool IsHooked { get; set; }
    private int collisions = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Meteor")
        {
            collisions++;
            if(RopeManager!=null)
            {
                //RopeManager._centreReached = true;
                RopeManager.StopHook();
                //Debug.Log($"{RopeManager} and {collisions}");
            }
            
        }
    }
}
