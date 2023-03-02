using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _targetPlayer;

    public event UnityAction<Enemy> Died;

    public int Reward => _reward;
    public Player TargetPlayer => _targetPlayer;

    public void Init(Player player)
    {
        _targetPlayer = player;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }

    public Player GetTargetPlayer()
    {
        return _targetPlayer;
    }
}
