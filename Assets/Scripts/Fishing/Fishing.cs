using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fishing : MonoBehaviour
{
    [SerializeField] private Spear _spear;
    [SerializeField] private GameObject _fishingCanvas;
    [SerializeField] private GameObject _winningPanel;

    private bool _isFishCaught = false;

    public bool IsFishCaught => _isFishCaught;
    public UnityEvent OnFishingEnded;

    private void Start()
    {
        CloseWinningPanel();
    }

    private void OnEnable()
    {
        _spear.OnFishPearced.AddListener(MakeWinningAction);
    }

    private void OnDisable()
    {
        _spear.OnFishPearced.RemoveListener(MakeWinningAction);
    }

    private void MakeWinningAction()
    {
        _isFishCaught = true;
        _winningPanel.SetActive(true);
    }

    private void CloseWinningPanel()
    {
        _winningPanel.SetActive(false);
    }

    public void StartFishing()
    {
        _fishingCanvas.SetActive(true);
    }

    public void Close()
    {
        _winningPanel.SetActive(false);
        _fishingCanvas.SetActive(false);  // do not delete (this method on button)
        OnFishingEnded?.Invoke();
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Close();
        //}
    }
}
