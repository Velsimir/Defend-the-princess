using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private Transform _shootPosition;

    public override void Shoot(Transform shootPosition)
    {
        Instantiate(Bullet,shootPosition.position,Quaternion.identity);
    }
}
