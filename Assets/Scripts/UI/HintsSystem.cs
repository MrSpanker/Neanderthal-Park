using DG.Tweening;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HintsSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hintText;
    [SerializeField] private Image _hintImage;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private List<Hint> _hintsActive = new List<Hint>();
    [SerializeField] private List<Hint> _hintsInactive = new List<Hint>();
    int _numberHint = 0;

    private void Start()
    {
        OpenHints();
        _nextButton.onClick.AddListener(NextHints);
        _previousButton.onClick.AddListener(PreviousHints);
    }
    [ContextMenu("Add")]
    public void AddHints()
    {
        _numberHint = _hintsActive.Count - 1;
        OpenHints();
        _hintsActive.Add(_hintsInactive[0]);
        _hintsInactive.Remove(_hintsInactive[0]);
        NextHints();
    }
    public void OpenHints()
    {
        _hintImage.gameObject.SetActive(true);
        _hintText.text = _hintsActive[_numberHint].HintText;
        _hintImage.DOFade(0.5f, 5f);
    }
    public void NextHints()
    {
        if (_numberHint < _hintsActive.Count - 1)
        {
            _numberHint++;
            _hintText.text = _hintsActive[_numberHint].HintText;
        }

    }
    public void PreviousHints()
    {
        if (_numberHint > 0)
        {
            _numberHint--;
            _hintText.text = _hintsActive[_numberHint].HintText;
        }
    }

}
