using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapons
{
    [SerializeField] private Transform _shootPosition;

    public override void Shoot(Transform shootPosition)
    {
        Instantiate(_bullet,shootPosition.position,Quaternion.identity);
    }
}
