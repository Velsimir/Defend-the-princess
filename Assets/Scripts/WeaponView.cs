using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class WeaponView : MonoBehaviour
{
    [SerializeField] TMP_Text _label;
    [SerializeField] TMP_Text _price;
    [SerializeField] Image _icon;
    [SerializeField] Button _sellButton;

    public event UnityAction<Weapon, WeaponView> OnSellButtonClick;

    private Weapon _weapon;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = weapon.Label;
        _price.text = weapon.Cost.ToString();
        _icon.sprite = weapon.Sprite;
    }

    private void TryLockItem()
    {
        if (_weapon.IsBuyed)
            _sellButton.interactable = false;
    }

    private void OnButtonClick()
    {
        OnSellButtonClick?.Invoke(_weapon, this);
    }
}
