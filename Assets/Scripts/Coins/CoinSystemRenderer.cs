using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinSystemRenderer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private CoinSystem _coinSystem;

    private void OnEnable()
    {
        _coinSystem.OnCoinsChanged.AddListener(ChangeCoinsScore);
    }

    private void OnDisable()
    {
        _coinSystem.OnCoinsChanged.RemoveListener(ChangeCoinsScore);
    }

    private void ChangeCoinsScore(int coins)
    {
        _coinsText.text = coins.ToString();
    }
}
