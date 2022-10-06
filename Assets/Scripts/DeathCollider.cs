using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollider : MonoBehaviour
{

    public IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1f);
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void OnTriggerEnter2D(Collider2D death)
    {
        if (death.gameObject.GetComponent<PlayerController>() != null)
          Debug.Log("Player Died, respawning");
        StartCoroutine(WaitForSceneLoad());
    }
}
