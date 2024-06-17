using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exisButton;
    [SerializeField] private string _sceneName;

    private void Start()
    {
        _startButton.onClick.AddListener(StartGame);
        _exisButton.onClick.AddListener(ExitGame);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(_sceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
