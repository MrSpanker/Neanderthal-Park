using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] private int _minCoinsAdded;
    [SerializeField] private int _maxCoinsAdded;
    [SerializeField] private int _minCoinAddTime;
    [SerializeField] private int _maxCoinAddTime;

    [SerializeField] private int _coins = 12;

    private float _time = 0;
    private int _nextCoinsTime = 0;

    public int Coins => _coins;
    public UnityEvent<int> OnCoinsChanged;


    private void Start()
    {
        RefreshNextTimeForCoins();
    }

    private void RefreshNextTimeForCoins()
    {
        _nextCoinsTime = Random.Range(_minCoinAddTime, _maxCoinAddTime);
        OnCoinsChanged?.Invoke(_coins);
    }

    private void AddRandomCoins()
    {
        _coins += Random.Range(_minCoinsAdded, _maxCoinsAdded);
        OnCoinsChanged?.Invoke(_coins);
    }

    private void TryAddRandomCoins()
    {
        _time += Time.deltaTime;

        if (_time > _nextCoinsTime)
        {
            _time = 0;
            RefreshNextTimeForCoins();
            AddRandomCoins();
        }
    }

    public void RemoveCoins(int removeCoins)
    {
        if (_coins < removeCoins)
            return;

        _coins -= removeCoins;
        OnCoinsChanged?.Invoke(_coins);
    }

    public bool IsEnoughCoins(int coins)
    {
        return _coins - coins < 0;
    }

    private void Update()
    {
        TryAddRandomCoins();
    }
}
