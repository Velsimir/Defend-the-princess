using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _isBuyed;

    [SerializeField] protected Bullet Bullet;

    public string Label => _label;
    public int Cost => _cost;
    public Sprite Sprite => _sprite;
    public bool IsBuyed => _isBuyed;

    abstract public void Shoot(Transform shootPosition);

    public void Buy()
    {
        _isBuyed = true;
    }
}
