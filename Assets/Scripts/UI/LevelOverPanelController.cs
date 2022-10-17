using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelOverPanelController : MonoBehaviour
{
    static int totalScenes = 6;

    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonMainMenu;
    [SerializeField] private Button buttonQuit;

    private void Awake()
    {
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
        buttonMainMenu.onClick.AddListener(LoadMainMenu);
        buttonQuit.onClick.AddListener(ExitGame);
    }

    private void LoadNextLevel()
    {
         int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            sceneIndex++;
            if (sceneIndex == totalScenes)
            {
                sceneIndex = 0;
            }

            SceneManager.LoadScene(sceneIndex);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }


       
           
}
