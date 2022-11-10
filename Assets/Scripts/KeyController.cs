using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.PickKey();
            Destroy(gameObject);
            Debug.Log("Key destroyed");
        }
    }
}
