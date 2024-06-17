using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private string _sceneName;
    [SerializeField] private Image _pausePanel;
    [SerializeField] private Button _pusePanelButtonContinie;
    [SerializeField] private Button _pusePanelButtonExitMenu;

    private void Start()
    {
        _restartButton.onClick.AddListener(RestartGame);
        _pusePanelButtonContinie.onClick.AddListener(PauseEnd);
        _pusePanelButtonExitMenu.onClick.AddListener(ExitToMenu);
    }
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            _pausePanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneName);
    }
    public void PauseEnd()
    {
        _pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
