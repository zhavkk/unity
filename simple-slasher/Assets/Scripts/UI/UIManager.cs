using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("HUD Elements")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider rageBar;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI rageText;

    [Header("Game Over Elements")]
    [SerializeField] private TextMeshProUGUI finalWaveText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    [Header("Colors")]
    [SerializeField] private Color highHealthColor = Color.green;
    [SerializeField] private Color mediumHealthColor = Color.yellow;
    [SerializeField] private Color lowHealthColor = Color.red;
    [SerializeField] private Color rageColor = new Color(1f, 0.3f, 0f);

    private static UIManager instance;
    private int score;
    private int currentWave;

    public static UIManager Instance
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

        // Setup buttons
        if (restartButton != null)
            restartButton.onClick.AddListener(OnRestartClicked);

        if (quitButton != null)
            quitButton.onClick.AddListener(OnQuitClicked);

        // Initialize UI state
        ShowHUD();
        HideGameOver();
    }

    private void Start()
    {
        score = 0;
        currentWave = 1;
        UpdateScoreUI();
    }

    public void UpdateHealth(int current, int max)
    {
        if (healthBar == null) return;

        healthBar.maxValue = max;
        healthBar.value = current;

        // Update color based on health percentage
        float healthPercentage = (float)current / max;
        Image healthFill = healthBar.fillRect?.GetComponent<Image>();

        if (healthFill != null)
        {
            if (healthPercentage > 0.6f)
                healthFill.color = highHealthColor;
            else if (healthPercentage > 0.3f)
                healthFill.color = mediumHealthColor;
            else
                healthFill.color = lowHealthColor;
        }
    }

    public void UpdateRage(float current, float max)
    {
        if (rageBar == null) return;

        rageBar.maxValue = max;
        rageBar.value = current;

        if (rageText != null)
        {
            rageText.text = $"{Mathf.Round(current)} / {max}";
        }

        // Update color based on rage level
        Image rageFill = rageBar.fillRect?.GetComponent<Image>();
        if (rageFill != null)
        {
            float ragePercentage = current / max;
            rageFill.color = Color.Lerp(Color.white, rageColor, ragePercentage);
        }
    }

    public void UpdateWave(int wave)
    {
        currentWave = wave;

        if (waveText != null)
        {
            waveText.text = $"Wave: {wave}";
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    public void ShowGameOver()
    {
        if (hudPanel != null)
            hudPanel.SetActive(false);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (finalWaveText != null)
                finalWaveText.text = $"You reached Wave {currentWave}!";

            if (finalScoreText != null)
                finalScoreText.text = $"Final Score: {score}";
        }
    }

    public void ShowHUD()
    {
        if (hudPanel != null)
            hudPanel.SetActive(true);
    }

    private void HideGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    private void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnQuitClicked()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        UpdateScoreUI();
    }
}
