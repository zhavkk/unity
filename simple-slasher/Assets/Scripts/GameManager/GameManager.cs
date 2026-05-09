using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WaveSpawner waveSpawner;
    [SerializeField] private EnhancedPlayerController playerController;
    [SerializeField] private UIManager uiManager;

    private static GameManager instance;
    private bool isGameOver;

    public static GameManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        isGameOver = false;
    }

    private void Start()
    {
        // Find references if not set
        if (waveSpawner == null)
            waveSpawner = FindAnyObjectByType<WaveSpawner>();

        if (playerController == null)
            playerController = FindAnyObjectByType<EnhancedPlayerController>();

        if (uiManager == null)
            uiManager = UIManager.Instance;
    }

    public void OnEnemyKilled()
    {
        if (isGameOver) return;

        // Notify wave spawner
        if (waveSpawner != null)
        {
            waveSpawner.OnEnemyKilled();
        }

        // Update score
        if (uiManager != null)
        {
            uiManager.UpdateScore(100);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Debug.Log("Game Over!");

        // Show game over UI
        if (uiManager != null)
        {
            uiManager.ShowGameOver();
        }

        // Stop spawning
        if (waveSpawner != null)
        {
            enabled = false;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public WaveSpawner GetWaveSpawner()
    {
        return waveSpawner;
    }

    public EnhancedPlayerController GetPlayerController()
    {
        return playerController;
    }
}
