using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private string _sceneName;
    private void Start()
    {
        _restartButton.onClick.AddListener(RestartGame);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
