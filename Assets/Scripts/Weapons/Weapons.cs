using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _isBuyed = false;

    [SerializeField] protected Bullet _bullet;

    abstract public void Shoot(Transform shootPosition);
}
