using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Управляет меню паузы, Game Over и другими UI меню
/// </summary>
public class GameMenuManager : MonoBehaviour
{
    public static GameMenuManager Instance { get; private set; }

    [Header("Menus")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject upgradeMenu;

    [Header("Pause Menu UI")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    [Header("Game Over Menu UI")]
    [SerializeField] private Text finalScoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text wavesSurvivedText;
    [SerializeField] private Text maxComboText;
    [SerializeField] private Button restartButton2;
    [SerializeField] private Button quitButton2;

    [Header("Upgrade Menu UI")]
    [SerializeField] private Button[] upgradeButtons;
    [SerializeField] private Text upgradePointsText;

    // State
    private bool isPaused = false;
    private bool gameOver = false;

    // Events
    public event Action OnGamePaused;
    public event Action OnGameResumed;
    public event Action OnGameRestarted;
    public event Action OnGameQuit;

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
        CreateMenus();
        HideAllMenus();
    }

    private void Update()
    {
        // ESC pause temporarily disabled due to Input System conflict
        // Use UI buttons instead for now
        // TODO: Implement proper Input System integration
    }

    private void CreateMenus()
    {
        Canvas canvas = FindAnyObjectByType<Canvas>();
        if (canvas == null)
        {
            Debug.LogWarning("GameMenuManager: No Canvas found!");
            return;
        }

        if (pauseMenu == null)
        {
            pauseMenu = CreatePauseMenu(canvas);
        }

        if (gameOverMenu == null)
        {
            gameOverMenu = CreateGameOverMenu(canvas);
        }

        if (upgradeMenu == null)
        {
            upgradeMenu = CreateUpgradeMenu(canvas);
        }
    }

    private GameObject CreatePauseMenu(Canvas canvas)
    {
        GameObject menu = new GameObject("PauseMenu");
        menu.transform.SetParent(canvas.transform);

        RectTransform rect = menu.AddComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.sizeDelta = Vector2.zero;

        // Background
        Image background = menu.AddComponent<Image>();
        background.color = new Color(0, 0, 0, 0.7f);

        // Title
        GameObject titleObj = CreateTextElement(menu.transform, "PAUSED", 48, TextAnchor.MiddleCenter);
        RectTransform titleRect = titleObj.GetComponent<RectTransform>();
        titleRect.anchoredPosition = new Vector2(0, 150);

        // Resume Button
        GameObject resumeObj = CreateButtonElement(menu.transform, "Resume", 24);
        RectTransform resumeRect = resumeObj.GetComponent<RectTransform>();
        resumeRect.anchoredPosition = new Vector2(0, 50);
        resumeButton = resumeObj.GetComponent<Button>();
        resumeButton.onClick.AddListener(ResumeGame);

        // Restart Button
        GameObject restartObj = CreateButtonElement(menu.transform, "Restart", 24);
        RectTransform restartRect = restartObj.GetComponent<RectTransform>();
        restartRect.anchoredPosition = new Vector2(0, -20);
        restartButton = restartObj.GetComponent<Button>();
        restartButton.onClick.AddListener(RestartGame);

        // Quit Button
        GameObject quitObj = CreateButtonElement(menu.transform, "Quit", 24);
        RectTransform quitRect = quitObj.GetComponent<RectTransform>();
        quitRect.anchoredPosition = new Vector2(0, -90);
        quitButton = quitObj.GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);

        return menu;
    }

    private GameObject CreateGameOverMenu(Canvas canvas)
    {
        GameObject menu = new GameObject("GameOverMenu");
        menu.transform.SetParent(canvas.transform);

        RectTransform rect = menu.AddComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.sizeDelta = Vector2.zero;

        // Background
        Image background = menu.AddComponent<Image>();
        background.color = new Color(0.1f, 0, 0, 0.85f);

        // Title
        GameObject titleObj = CreateTextElement(menu.transform, "GAME OVER", 60, TextAnchor.MiddleCenter);
        RectTransform titleRect = titleObj.GetComponent<RectTransform>();
        titleRect.anchoredPosition = new Vector2(0, 200);
        Text titleText = titleObj.GetComponent<Text>();
        titleText.color = Color.red;

        // Final Score
        GameObject scoreObj = CreateTextElement(menu.transform, "Final Score: 0", 32, TextAnchor.MiddleCenter);
        RectTransform scoreRect = scoreObj.GetComponent<RectTransform>();
        scoreRect.anchoredPosition = new Vector2(0, 100);
        finalScoreText = scoreObj.GetComponent<Text>();

        // High Score
        GameObject highScoreObj = CreateTextElement(menu.transform, "High Score: 0", 24, TextAnchor.MiddleCenter);
        RectTransform highScoreRect = highScoreObj.GetComponent<RectTransform>();
        highScoreRect.anchoredPosition = new Vector2(0, 50);
        highScoreText = highScoreObj.GetComponent<Text>();
        highScoreText.color = Color.yellow;

        // Waves Survived
        GameObject wavesObj = CreateTextElement(menu.transform, "Waves Survived: 0", 24, TextAnchor.MiddleCenter);
        RectTransform wavesRect = wavesObj.GetComponent<RectTransform>();
        wavesRect.anchoredPosition = new Vector2(0, 0);
        wavesSurvivedText = wavesObj.GetComponent<Text>();

        // Max Combo
        GameObject comboObj = CreateTextElement(menu.transform, "Max Combo: 0", 20, TextAnchor.MiddleCenter);
        RectTransform comboRect = comboObj.GetComponent<RectTransform>();
        comboRect.anchoredPosition = new Vector2(0, -40);
        maxComboText = comboObj.GetComponent<Text>();
        maxComboText.color = Color.cyan;

        // Restart Button
        GameObject restartObj = CreateButtonElement(menu.transform, "Play Again", 28);
        RectTransform restartRect = restartObj.GetComponent<RectTransform>();
        restartRect.anchoredPosition = new Vector2(0, -100);
        restartButton2 = restartObj.GetComponent<Button>();
        restartButton2.onClick.AddListener(RestartGame);

        // Quit Button
        GameObject quitObj = CreateButtonElement(menu.transform, "Quit to Desktop", 24);
        RectTransform quitRect = quitObj.GetComponent<RectTransform>();
        quitRect.anchoredPosition = new Vector2(0, -160);
        quitButton2 = quitObj.GetComponent<Button>();
        quitButton2.onClick.AddListener(QuitGame);

        return menu;
    }

    private GameObject CreateUpgradeMenu(Canvas canvas)
    {
        GameObject menu = new GameObject("UpgradeMenu");
        menu.transform.SetParent(canvas.transform);

        RectTransform rect = menu.AddComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.sizeDelta = Vector2.zero;

        // Background
        Image background = menu.AddComponent<Image>();
        background.color = new Color(0, 0, 0.2f, 0.9f);

        // Title
        GameObject titleObj = CreateTextElement(menu.transform, "WAVE COMPLETE - CHOOSE UPGRADE", 36, TextAnchor.MiddleCenter);
        RectTransform titleRect = titleObj.GetComponent<RectTransform>();
        titleRect.anchoredPosition = new Vector2(0, 200);

        // Upgrade points text
        GameObject pointsObj = CreateTextElement(menu.transform, "Upgrade Points: 1", 24, TextAnchor.MiddleCenter);
        RectTransform pointsRect = pointsObj.GetComponent<RectTransform>();
        pointsRect.anchoredPosition = new Vector2(0, 140);
        upgradePointsText = pointsObj.GetComponent<Text>();
        upgradePointsText.color = Color.yellow;

        // Create upgrade buttons (will be configured by UpgradeSystem)
        upgradeButtons = new Button[3];

        string[] upgradeNames = { "Increase Damage", "Increase Speed", "Increase Health" };
        string[] upgradeDescriptions = { "+20% Damage", "+15% Speed", "+25% Max Health" };

        for (int i = 0; i < 3; i++)
        {
            GameObject buttonObj = CreateButtonElement(menu.transform, upgradeNames[i], 20);
            RectTransform buttonRect = buttonObj.GetComponent<RectTransform>();
            buttonRect.anchoredPosition = new Vector2(0, 60 - i * 70);
            buttonRect.sizeDelta = new Vector2(400, 60);

            upgradeButtons[i] = buttonObj.GetComponent<Button>();

            // Add description
            GameObject descObj = CreateTextElement(buttonObj.transform, upgradeDescriptions[i], 14, TextAnchor.MiddleCenter);
            RectTransform descRect = descObj.GetComponent<RectTransform>();
            descRect.anchoredPosition = new Vector2(0, -15);
            descRect.sizeDelta = new Vector2(-20, 30);
        }

        return menu;
    }

    private GameObject CreateTextElement(Transform parent, string text, int fontSize, TextAnchor alignment)
    {
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(parent);

        RectTransform rect = textObj.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(500, 60);

        Text textComponent = textObj.AddComponent<Text>();
        textComponent.text = text;
        textComponent.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        textComponent.fontSize = fontSize;
        textComponent.alignment = alignment;
        textComponent.color = Color.white;

        Outline outline = textObj.AddComponent<Outline>();
        outline.effectColor = Color.black;
        outline.effectDistance = new Vector2(2, -2);

        return textObj;
    }

    private GameObject CreateButtonElement(Transform parent, string text, int fontSize)
    {
        GameObject buttonObj = new GameObject("Button");
        buttonObj.transform.SetParent(parent);

        RectTransform rect = buttonObj.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(300, 50);

        Image image = buttonObj.AddComponent<Image>();
        image.color = new Color(0.2f, 0.2f, 0.2f);

        Button button = buttonObj.AddComponent<Button>();

        // Create text child
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(buttonObj.transform);

        RectTransform textRect = textObj.AddComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.sizeDelta = Vector2.zero;

        Text textComponent = textObj.AddComponent<Text>();
        textComponent.text = text;
        textComponent.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        textComponent.fontSize = fontSize;
        textComponent.alignment = TextAnchor.MiddleCenter;
        textComponent.color = Color.white;

        return buttonObj;
    }

    public void PauseGame()
    {
        if (gameOver) return;

        isPaused = true;
        Time.timeScale = 0f;

        ShowPauseMenu();
        OnGamePaused?.Invoke();

        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        HideAllMenus();
        OnGameResumed?.Invoke();

        Debug.Log("Game Resumed");
    }

    public void ShowGameOverMenu(int score, int highScore, int waves, int maxCombo)
    {
        gameOver = true;
        isPaused = false;
        Time.timeScale = 0f;

        if (finalScoreText != null)
        {
            finalScoreText.text = $"Final Score: {score}";
        }

        if (highScoreText != null)
        {
            highScoreText.text = $"High Score: {highScore}";
        }

        if (wavesSurvivedText != null)
        {
            wavesSurvivedText.text = $"Waves Survived: {waves}";
        }

        if (maxComboText != null)
        {
            maxComboText.text = $"Max Combo: {maxCombo}x";
        }

        gameOverMenu.SetActive(true);
        Debug.Log("Game Over - Showing menu");
    }

    public void ShowUpgradeMenu()
    {
        isPaused = true;
        Time.timeScale = 0f;

        upgradeMenu.SetActive(true);
        Debug.Log("Showing Upgrade Menu");
    }

    public void HideUpgradeMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;

        upgradeMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameOver = false;
        isPaused = false;

        HideAllMenus();

        // Reset game systems
        if (ComboSystem.Instance != null)
        {
            ComboSystem.Instance.ResetScore();
        }

        OnGameRestarted?.Invoke();

        Debug.Log("Game Restarted");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;

        OnGameQuit?.Invoke();

        Debug.Log("Quitting Game");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private void ShowPauseMenu()
    {
        HideAllMenus();
        pauseMenu.SetActive(true);
    }

    private void HideAllMenus()
    {
        if (pauseMenu != null) pauseMenu.SetActive(false);
        if (gameOverMenu != null) gameOverMenu.SetActive(false);
        if (upgradeMenu != null) upgradeMenu.SetActive(false);
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}
