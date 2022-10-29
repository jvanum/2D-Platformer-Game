using UnityEngine;

// reached teleporter and proceed to next level
public class LevelOver : MonoBehaviour
{
    [SerializeField] private LevelOverPanelController levelOverPanelController;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController playerController))
        {
            SoundManager.Instance.Play(SoundTypes.PLAYERTELEPORT);
            LevelManager.Instance.LevelCompleted();
            levelOverPanelController.gameObject.SetActive(true);
        }
    }

}