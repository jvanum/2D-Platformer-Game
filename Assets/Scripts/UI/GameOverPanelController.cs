using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanelController : MonoBehaviour
{
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Button buttonMainMenu;
    [SerializeField] private Button buttonQuit;

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadGame);
        buttonMainMenu.onClick.AddListener(MainMenu);
        buttonQuit.onClick.AddListener(ExitGame);
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
