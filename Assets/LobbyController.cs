using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonQuit;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(EnterGame);
        buttonQuit.onClick.AddListener(ExitGame);
    }

    private void EnterGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        Debug.Log("Quit Game");
    }

}
