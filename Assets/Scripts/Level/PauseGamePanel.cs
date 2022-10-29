using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGamePanel : MonoBehaviour
{   
    [SerializeField]
    private ResumeGamePanel rgPanel;
  
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    private void PauseGame ()
    {
        SoundManager.Instance.Play(SoundTypes.BUTTONCLICK);
        Time.timeScale = 0;
        AudioListener.pause = true;
        rgPanel.gameObject.SetActive(true);
    }

}