using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        playerController.KillPlayer();
    }
}
