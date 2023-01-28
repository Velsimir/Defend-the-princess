using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class MainHero : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapons> _weapons;
    [SerializeField] private Transform _shootPosition;

    private int _currentHealth;
    private Weapons _currentWeapon;
    private Animator _animator;

    public int Money { get; private set; }

    private void Start()
    {
        _currentHealth = _health;
        _currentWeapon = _weapons[0];

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPosition);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnemyDied(int reward)
    {
        Money += reward;
    }
}
