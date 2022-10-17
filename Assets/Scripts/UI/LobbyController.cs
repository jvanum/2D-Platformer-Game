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
        SoundManager.Instance.Play(SoundTypes.BUTTONCLICK);
        LevelScreen.SetActive(true);
    }

    private void ExitGame()
    {
        SoundManager.Instance.Play(SoundTypes.BUTTONCLICK);
        Debug.Log("Quit Game");
        Application.Quit();
    }

    private void CloseLevelPanel()
    {
        SoundManager.Instance.Play(SoundTypes.BUTTONCLICK);
        LevelScreen.SetActive(false);
    }

}
