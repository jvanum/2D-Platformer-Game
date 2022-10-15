using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollider : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController = collision.GetComponent<PlayerController>();

        if (playerController != null)
        Debug.Log("Player fell from platform, respawning");
        playerController.KillPlayer();
    }
}
