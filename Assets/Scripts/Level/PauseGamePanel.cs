using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGamePanel : MonoBehaviour
{   
    [SerializeField]
    private ResumeGamePanel rgPanel;
    [SerializeField] private Button buttonPause;

    private void Awake()
    {  
         buttonPause.onClick.AddListener(PauseGame);
    }
    private void PauseGame ()
    {
        SoundManager.Instance.Play(SoundTypes.BUTTONCLICK);
        Time.timeScale = 0;
        AudioListener.pause = true;
        rgPanel.gameObject.SetActive(true);
    }

}