using UnityEngine;

/// <summary>
/// Integrates all game systems and ensures they communicate properly.
/// Attach this to the Player GameObject along with other components.
/// </summary>
public class GameIntegrator : MonoBehaviour
{
    [Header("Component References (Auto-assigned if empty)")]
    [SerializeField] private EnhancedPlayerController playerController;
    [SerializeField] private PlayerAttract playerAttract;
    [SerializeField] private RageSystem rageSystem;
    [SerializeField] private PlayerHealth playerHealth;

    private void Awake()
    {
        // Auto-find components if not assigned
        playerController = GetComponent<EnhancedPlayerController>();
        playerAttract = GetComponent<PlayerAttract>();
        rageSystem = GetComponent<RageSystem>();
        playerHealth = GetComponent<PlayerHealth>();

        Debug.Log("GameIntegrator: All systems connected");
    }

    private void Start()
    {
        // Setup Rage System connections
        if (rageSystem != null && playerController != null)
        {
            rageSystem.SetPlayerController(playerController);
        }

        // Setup connections between systems
        if (playerHealth != null)
        {
            playerHealth.OnPlayerDeath += HandlePlayerDeath;
        }

        // Setup rage system integration with enhanced player controller
        SetupRageIntegration();
    }

    private void SetupRageIntegration()
    {
        if (rageSystem == null || playerController == null) return;

        // Subscribe to player controller events to update rage
        playerController.OnPlayerAttack += () => rageSystem.OnPlayerAttack();

        // Subscribe to player health events for damage-based rage loss
        if (playerHealth != null)
        {
            // Note: PlayerHealth doesn't have a damage event, so we'll handle this differently
            // The enhanced controller has TakeDamage method that we can hook into
        }
    }

    private void OnEnable()
    {
        // Subscribe to PlayerController events
        if (playerController != null)
        {
            playerController.OnPlayerAttack += OnPlayerAttacked;
            playerController.OnPlayerTakeDamage += OnPlayerDamaged;
        }

        Debug.Log("GameIntegrator: Events subscribed");
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        if (playerController != null)
        {
            playerController.OnPlayerAttack -= OnPlayerAttacked;
            playerController.OnPlayerTakeDamage -= OnPlayerDamaged;
        }

        if (playerHealth != null)
        {
            playerHealth.OnPlayerDeath -= HandlePlayerDeath;
        }
    }

    private void OnPlayerAttacked()
    {
        // Notify rage system when player attacks
        if (rageSystem != null)
        {
            rageSystem.OnPlayerAttack();
        }
    }

    private void OnPlayerDamaged(float damage)
    {
        // Notify rage system when player takes damage
        if (rageSystem != null)
        {
            rageSystem.OnPlayerTakeDamage(damage);
        }

        // Apply damage to enhanced player controller
        if (playerController != null)
        {
            playerController.TakeDamage(damage);
        }
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("GameIntegrator: Player died - stopping game");

        // Stop enemy spawning
        WaveManager[] waveManagers = Object.FindObjectsByType<WaveManager>();
        if (waveManagers != null && waveManagers.Length > 0)
        {
            waveManagers[0].StopGame();
        }
        else
        {
            Debug.LogWarning("GameIntegrator: No WaveManager found to stop spawning!");
        }

        // Disable player controls
        if (playerController != null)
        {
            playerController.enabled = false;
        }
        else
        {
            Debug.LogWarning("GameIntegrator: EnhancedPlayerController is null, cannot disable.");
        }

        if (playerAttract != null)
        {
            playerAttract.enabled = false;
        }
        else
        {
            Debug.LogWarning("GameIntegrator: PlayerAttract is null, cannot disable.");
        }

        // Show Game Over menu with stats
        if (GameMenuManager.Instance != null)
        {
            int score = 0;
            int highScore = 0;
            int waves = 1;
            int maxCombo = 0;

            if (ComboSystem.Instance != null)
            {
                score = ComboSystem.Instance.GetCurrentScore();
                highScore = ComboSystem.Instance.GetHighScore();
                maxCombo = ComboSystem.Instance.GetMaxCombo();
            }

            if (waveManagers != null && waveManagers.Length > 0)
            {
                waves = waveManagers[0].GetCurrentWave() - 1;
            }

            GameMenuManager.Instance.ShowGameOverMenu(score, highScore, waves, maxCombo);
        }
    }
}
