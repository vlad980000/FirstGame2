using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _coinDislay;

    private void OnEnable()
    {
        _player.CoinCountChanged += OnCoinCountChanged;
    }

    private void OnDisable()
    {
        _player.CoinCountChanged -= OnCoinCountChanged;
    }

    private void OnCoinCountChanged(int coins)
    {
        _coinDislay.text = coins.ToString();
    }
}
