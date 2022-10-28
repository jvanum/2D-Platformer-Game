using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    public Button button;
    public string levelName;

    public void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);

        switch (levelStatus)
        {
            case LevelStatus.LOCKED:
                SoundManager.Instance.Play(SoundTypes.LEVELLOCKED);
                break;
            case LevelStatus.UNLOCKED:
                SoundManager.Instance.Play(SoundTypes.LEVELLOAD);
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.COMPLETED:
                SoundManager.Instance.Play(SoundTypes.LEVELLOAD);
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
