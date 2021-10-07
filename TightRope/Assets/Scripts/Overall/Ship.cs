using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public string Name;
    //values
    public int MaxRopes, MaxHealth, CurrentHealth, Money;
    //indexes
    public int RopeUpgradeIndex, HealthUpgradeIndex;

    public void AssignShip()
    {
        GameManager.Instance.MainShip = this;
    }
}
