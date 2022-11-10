using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// reached teleporter and proceed to next level
public class LevelOverController : MonoBehaviour
{
    static int totalScenes = 6;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level complete");
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            sceneIndex++;
            if (sceneIndex == totalScenes)
            {
                sceneIndex = 0;
            }

            SceneManager.LoadScene(sceneIndex);
        }
    }


}