using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HintsSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hintText;
    [SerializeField] private Image _hintImage;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private Hint[] _hints;
    int _numberHint = 0;

    private void Start()
    {
        OpenHints();
        _nextButton.onClick.AddListener(NextHints);
        _previousButton.onClick.AddListener(PreviousHints);
    }
    public void OpenHints()
    {
        _hintImage.gameObject.SetActive(true);
        _hintText.text = _hints[_numberHint].HintText;
        _hintImage.DOFade(0.5f, 5f);
    }
    public void NextHints()
    {
        if (_numberHint < _hints.Length - 1)
        {
            _numberHint++;
            _hintText.text = _hints[_numberHint].HintText;
        }

    }
    public void PreviousHints()
    {
        if (_numberHint > 0)
        {
            _numberHint--;
            _hintText.text = _hints[_numberHint].HintText;
        }
    }

}
