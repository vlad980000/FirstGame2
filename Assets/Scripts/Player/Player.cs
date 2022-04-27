using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    private int _coinsCounter = 0;
    private CircleCollider2D _boxCollider;

    public event UnityAction<int> CoinCountChanged;
    public event UnityAction Gameover;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Gameover?.Invoke();
            gameObject.SetActive(false);
        }
        if(collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            _coinsCounter++;
            CoinCountChanged?.Invoke(_coinsCounter);
            collision.gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        _coinsCounter = 0;
        CoinCountChanged?.Invoke(_coinsCounter);
    }
}
