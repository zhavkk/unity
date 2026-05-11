using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Система комбо и очков. Отслеживает последовательные атаки и начисляет множители.
/// </summary>
public class ComboSystem : MonoBehaviour
{
    public static ComboSystem Instance { get; private set; }

    [Header("Combo Settings")]
    [SerializeField] private float comboWindow = 2f;
    [SerializeField] private float maxComboMultiplier = 5f;
    [SerializeField] private float comboMultiplierIncrease = 0.5f;

    [Header("Score Settings")]
    [SerializeField] private int baseKillScore = 100;
    [SerializeField] private int baseHitScore = 10;

    [Header("UI References")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text comboText;
    [SerializeField] private Text multiplierText;
    [SerializeField] private GameObject comboPanel;

    // State
    private int currentScore = 0;
    private int currentCombo = 0;
    private float currentMultiplier = 1f;
    private float lastComboTime;
    private bool isComboActive = false;

    // High score
    private int highScore = 0;
    private int maxCombo = 0;

    // Events
    public event Action<int> OnScoreChanged;
    public event Action<int> OnComboChanged;
    public event Action<float> OnMultiplierChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadHighScore();
        UpdateUI();
    }

    private void Update()
    {
        if (isComboActive)
        {
            float timeSinceLastCombo = Time.time - lastComboTime;

            if (timeSinceLastCombo >= comboWindow)
            {
                ResetCombo();
            }
        }
    }

    /// <summary>
    /// Регистрирует попадание по врагу
    /// </summary>
    public void RegisterHit(bool isKill = false)
    {
        lastComboTime = Time.time;

        if (!isComboActive)
        {
            isComboActive = true;
            currentCombo = 0;
            currentMultiplier = 1f;
        }

        currentCombo++;

        // Increase multiplier
        currentMultiplier = Mathf.Min(1f + (currentCombo - 1) * comboMultiplierIncrease, maxComboMultiplier);

        // Calculate score
        int baseScore = isKill ? baseKillScore : baseHitScore;
        int finalScore = Mathf.RoundToInt(baseScore * currentMultiplier);

        currentScore += finalScore;

        // Update max combo
        if (currentCombo > maxCombo)
        {
            maxCombo = currentCombo;
        }

        // Trigger events
        OnScoreChanged?.Invoke(currentScore);
        OnComboChanged?.Invoke(currentCombo);
        OnMultiplierChanged?.Invoke(currentMultiplier);

        UpdateUI();
        ShowFloatingText(finalScore, isKill);

        Debug.Log($"[ComboSystem] Hit! Combo: {currentCombo}, Multiplier: x{currentMultiplier:F1}, Score: +{finalScore}");
    }

    /// <summary>
    /// Регистрирует убийство врага
    /// </summary>
    public void RegisterKill()
    {
        RegisterHit(true);

        // Check for high score
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
        }
    }

    /// <summary>
    /// Сбрасывает комбо
    /// </summary>
    public void ResetCombo()
    {
        if (isComboActive)
        {
            Debug.Log($"[ComboSystem] Combo lost! Final combo: {currentCombo}");
        }

        isComboActive = false;
        currentCombo = 0;
        currentMultiplier = 1f;

        OnComboChanged?.Invoke(currentCombo);
        OnMultiplierChanged?.Invoke(currentMultiplier);

        UpdateUI();
    }

    /// <summary>
    /// Получает текущий множитель урона на основе комбо
    /// </summary>
    public float GetDamageMultiplier()
    {
        return currentMultiplier;
    }

    /// <summary>
    /// Получает текущий счет
    /// </summary>
    public int GetCurrentScore()
    {
        return currentScore;
    }

    /// <summary>
    /// Получает максимальный комбо за текущую сессию
    /// </summary>
    public int GetMaxCombo()
    {
        return maxCombo;
    }

    /// <summary>
    /// Получает рекордный счет
    /// </summary>
    public int GetHighScore()
    {
        return highScore;
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore}";
        }

        if (comboText != null)
        {
            if (isComboActive && currentCombo > 1)
            {
                comboText.text = $"{currentCombo}x Combo!";
                comboText.gameObject.SetActive(true);
            }
            else
            {
                comboText.gameObject.SetActive(false);
            }
        }

        if (multiplierText != null)
        {
            if (isComboActive && currentMultiplier > 1f)
            {
                multiplierText.text = $"x{currentMultiplier:F1}";
                multiplierText.gameObject.SetActive(true);
            }
            else
            {
                multiplierText.gameObject.SetActive(false);
            }
        }

        if (comboPanel != null)
        {
            comboPanel.SetActive(isComboActive && currentCombo > 1);
        }
    }

    private void ShowFloatingText(int score, bool isKill)
    {
        // Create floating score text
        if (FloatingTextManager.Instance != null)
        {
            Vector3 screenPosition = new Vector2(Screen.width / 2, Screen.height * 0.3f);
            string text = isKill ? $"+{score} KILL!" : $"+{score}";
            Color color = isKill ? Color.yellow : Color.white;
            int size = isKill ? 24 : 18;

            FloatingTextManager.Instance.ShowFloatingText(text, screenPosition, color, size);
        }
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    /// <summary>
    /// Сбрасывает счет (например, при начале новой игры)
    /// </summary>
    public void ResetScore()
    {
        currentScore = 0;
        ResetCombo();
        maxCombo = 0;

        OnScoreChanged?.Invoke(currentScore);
        UpdateUI();
    }

    // For debugging
    void OnGUI()
    {
        GUI.Label(new Rect(10, 70, 200, 20), $"Score: {currentScore}");
        GUI.Label(new Rect(10, 90, 200, 20), $"Combo: {currentCombo}x");
        GUI.Label(new Rect(10, 110, 200, 20), $"Multiplier: x{currentMultiplier:F1}");
        GUI.Label(new Rect(10, 130, 200, 20), $"High Score: {highScore}");
    }
}
