using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WoodenSword : MonoBehaviour, IWeapon
{
    public List<BaseStat> Stats { get; set; }

    public void PerformAttack()
    {
        Debug.Log("Sword attack!");
    }
}
