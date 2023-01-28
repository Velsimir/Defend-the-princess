using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class StateAttack : State
{
    [SerializeField] private int _damage;
    [SerializeField]  private float _delay;

    private Animator _animator;
    private float _lastAttackTime;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime > _delay)
        {
            Attack(MainHero);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(MainHero mainHero)
    {
        _animator.Play("Attack");
        mainHero.TakeDamage(_damage);
    }
}

