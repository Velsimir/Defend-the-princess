using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    private const string Player_Shooting = "Player_Shooting";

    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPosition;

    private int _currentHealth;
    private Weapon _currentWeapon;
    private int _currentWeaponIndex = 0;
    private Animator _animator;

    public event UnityAction<int,int> OnHealthChanged;
    public event UnityAction<int> OnMoneyChanged;

    public int Money { get; private set; }

    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponIndex]);
        _currentHealth = _maxHealth;
        _currentWeapon = _weapons[0];

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Shoot");
            _currentWeapon.Shoot(_shootPosition);
        }
    }

    public void NextWeapon()
    {
        if (_currentWeaponIndex == _weapons.Count - 1)
            _currentWeaponIndex = 0;
        else
            _currentWeaponIndex++;

        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponIndex == 0)
            _currentWeaponIndex = _weapons.Count - 1;
        else
            _currentWeaponIndex--;

        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    public void AddMoney(int money)
    {
        Money += money;
        OnMoneyChanged?.Invoke(Money);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    private void OnEnemyDied(int reward)
    {
        Money += reward;
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Cost;
        _weapons.Add(weapon);
        OnMoneyChanged?.Invoke(Money);
    }
}
