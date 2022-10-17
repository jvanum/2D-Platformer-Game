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
                Debug.Log("Level Locked");
                break;
            case LevelStatus.UNLOCKED:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.COMPLETED:
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
