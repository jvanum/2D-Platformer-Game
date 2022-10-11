using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Button buttonQuit;

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadGame);
        buttonQuit.onClick.AddListener(ExitGame);
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ExitGame()
    {
        Debug.Log("Quit Game");
    }
}
