using UnityEngine;
using UnityEngine.UI;

public class MvpGameOverUI : MonoBehaviour
{
    [SerializeField] private Text gameOverText;

    private MvpPlayerHealth playerHealth;

    public void Initialize(Text text, MvpPlayerHealth health)
    {
        gameOverText = text;
        playerHealth = health;

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }

        if (playerHealth != null)
        {
            playerHealth.OnDied += HandlePlayerDied;
        }
    }

    private void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnDied -= HandlePlayerDied;
        }
    }

    private void HandlePlayerDied()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
}
