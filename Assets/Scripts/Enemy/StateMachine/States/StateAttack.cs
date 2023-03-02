using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class StateAttack : State
{
    private const string EnemyAttack = "Enemy_Attack";

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
        if (_lastAttackTime <= 0)
        {
            Attack(Player);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player player)
    {
        _animator.Play(EnemyAttack);
        player.TakeDamage(_damage);
    }
}

