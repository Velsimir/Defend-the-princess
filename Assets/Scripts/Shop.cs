using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] List<Weapon> _weapons;
    [SerializeField] Player _player;
    [SerializeField] WeaponView _template;
    [SerializeField] GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddWeapon(_weapons[i]);
        }
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView weaponView)
    {
        TrySellWeapon(weapon, weaponView);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if (weapon.Cost <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            weaponView.OnSellButtonClick -= OnSellButtonClick;
        }
    }

    private void AddWeapon(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.OnSellButtonClick += OnSellButtonClick;
        view.Render(weapon);
    }
}
