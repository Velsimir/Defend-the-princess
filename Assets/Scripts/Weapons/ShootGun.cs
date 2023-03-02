using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : Weapon
{
    private Vector3 _bulletPositionTop = new Vector3(0, 0.2f ,0);
    private Vector3 _bulletPositionBottom = new Vector3(0, -0.2f, 0);

    public override void Shoot(Transform shootPosition)
    {
        Instantiate(Bullet, shootPosition.position + _bulletPositionTop, Quaternion.identity);
        Instantiate(Bullet, shootPosition.position + _bulletPositionBottom, Quaternion.identity);
    }
}
