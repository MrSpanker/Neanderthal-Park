using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _creatersButton;
    [SerializeField] private Button _exisButton;

    private void Start()
    {
        _startButton.onClick.AddListener(StartGame);
        _creatersButton.onClick.AddListener(Creators);
        _exisButton.onClick.AddListener(ExitGame);
    }
    public void StartGame()
    {

    }
    public void ExitGame()
    {

    }
    public void Creators()
    {

    }
}
