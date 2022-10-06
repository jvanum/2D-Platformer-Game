using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChomperController : MonoBehaviour
{



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log("Player enemy collided");
            playerController.KillPlayer();
        }
    }
}
