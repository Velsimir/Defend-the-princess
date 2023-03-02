using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _moneyBalanceText;
    [SerializeField] Player _player;

    private void OnEnable()
    {
        _moneyBalanceText.text = _player.Money.ToString();
        _player.OnMoneyChanged += PlayerOnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.OnMoneyChanged -= PlayerOnMoneyChanged;
    }

    private void PlayerOnMoneyChanged(int money)
    {
        _moneyBalanceText.text = _player.Money.ToString();
    }
}
