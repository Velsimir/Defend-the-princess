using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    [SerializeField] private MainHero _targetMainHero;

    private event UnityAction _died;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _died?.Invoke();
            Destroy(gameObject);
        }
    }

    public MainHero GetTargetMainHero()
    {
        return _targetMainHero;
    }
}
