using UnityEngine;
using UnityEngine.UI;
public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonControls;
    [SerializeField] private Button buttonQuit;
    [SerializeField] private Button buttonLevelsClose;
    [SerializeField] private Button buttonControlsClose;

    [SerializeField] private GameObject LevelScreen;
    [SerializeField] private GameObject LobbyScreen;
    [SerializeField] private GameObject ControlsScreen;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(EnterGame);
        buttonControls.onClick.AddListener(Controls);
        buttonQuit.onClick.AddListener(ExitGame);
        buttonLevelsClose.onClick.AddListener(CloseLevelPanel);
        buttonControlsClose.onClick.AddListener(CloseControlsPanel);
    }

    private void EnterGame()
    {
        SoundManager.Instance.Play(SoundTypes.BUTTONCLICK);
        LevelScreen.SetActive(true);
    }

     private void Controls()
    {
        SoundManager.Instance.Play(SoundTypes.BUTTONCLICK);
        ControlsScreen.SetActive(true);
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

    private void CloseControlsPanel()
    {
        SoundManager.Instance.Play(SoundTypes.BUTTONCLICK);
        ControlsScreen.SetActive(false);
    }

}
