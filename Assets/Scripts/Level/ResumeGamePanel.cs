using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResumeGamePanel : MonoBehaviour
{
    [SerializeField] private Button buttonResume;
    [SerializeField] private Button buttonMainMenu;

    private void Awake()
    { 
        buttonResume.onClick.AddListener(ResumeGame);
        buttonMainMenu.onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        AudioListener.pause = false;
        SoundManager.Instance.Play(SoundTypes.BUTTONCLICK);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    private void ResumeGame ()
    {   
        AudioListener.pause = false;
        SoundManager.Instance.Play(SoundTypes.BUTTONCLICK);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

}