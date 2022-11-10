
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //singleton Level Manager
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public string[] levelNames;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);  
        }
    }

    private void Start()
    {
        if (GetLevelStatus(levelNames[0]) == LevelStatus.LOCKED)
        {
             SetLevelStatus(levelNames[0], LevelStatus.UNLOCKED);
        }
    }

    public LevelStatus GetLevelStatus(string levelName)
    {
        return (LevelStatus)PlayerPrefs.GetInt(levelName,0);
    }
    public void SetLevelStatus(string levelName, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(levelName,(int)levelStatus);
    }

    public void LevelCompleted()
    {
        SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.COMPLETED);
        UnlockNextLevel();
    }

    private void UnlockNextLevel()
    {
        int currentLevelIndex = Array.FindIndex(levelNames,x => x == SceneManager.GetActiveScene().name);
        int nextLevelIndex = currentLevelIndex + 1;
        if(nextLevelIndex < levelNames.Length)
        {
            if (GetLevelStatus(levelNames[nextLevelIndex]) == LevelStatus.LOCKED)
            {
                SetLevelStatus(levelNames[nextLevelIndex], LevelStatus.UNLOCKED);
            }
        }
    }
}
