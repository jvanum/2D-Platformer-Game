using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    }

    private void CloseLevelPanel()
    {
        LevelScreen.SetActive(false);
    }

}
