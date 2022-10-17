using UnityEngine;
using UnityEngine.UI;
public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonQuit;
    [SerializeField] private Button buttonClose;

    public GameObject LevelScreen;
    public GameObject LobbyScreen;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(EnterGame);
        buttonQuit.onClick.AddListener(ExitGame);
        buttonClose.onClick.AddListener(CloseLevelPanel);
    }

    private void EnterGame()
    {
        LevelScreen.SetActive(true);
    }

    private void ExitGame()
    {

        Debug.Log("Quit Game");
        Application.Quit();
    }

    private void CloseLevelPanel()
    {
        LevelScreen.SetActive(false);
    }

}
