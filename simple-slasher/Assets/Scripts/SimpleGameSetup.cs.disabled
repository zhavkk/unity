using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Master game setup script that creates and configures all necessary game objects.
/// This is the "one script to rule them all" - add this to any scene and it will
/// create a fully playable game with all systems properly connected.
/// </summary>
public class SimpleGameSetup : MonoBehaviour
{
    [Header("UI Colors")]
    [SerializeField] private Color waveTextColor = Color.white;
    [SerializeField] private Color rageTextColor = Color.red;
    [SerializeField] private Color healthBarColor = Color.green;
    [SerializeField] private Color healthBarBackground = Color.red;

    [Header("Canvas Settings")]
    [SerializeField] private Vector2 canvasSize = new Vector2(1920, 1080);
    [SerializeField] private float uiScale = 1f;

    void Awake()
    {
        Debug.Log("[SimpleGameSetup] Setting up game...");

        // Setup scene first (lighting, ground, camera)
        SetupScene();

        // Setup player with all components
        GameObject player = SetupPlayer();

        // Setup enemy spawner
        GameObject enemySpawner = SetupEnemySpawner(player);

        // Setup wave manager
        SetupWaveManager(player, enemySpawner);

        // Setup UI
        SetupUI(player);

        Debug.Log("[SimpleGameSetup] Game setup complete!");
    }

    private void SetupScene()
    {
        // Check if scene setup already exists
        SimpleSceneSetup existingSetup = FindAnyObjectByType<SimpleSceneSetup>();
        if (existingSetup != null)
        {
            Debug.Log("[SimpleGameSetup] Scene setup already exists, skipping.");
            return;
        }

        // Create scene setup object
        GameObject sceneSetupObj = new GameObject("SceneSetup");
        SimpleSceneSetup sceneSetup = sceneSetupObj.AddComponent<SimpleSceneSetup>();
        sceneSetup.runSetup = true;

        Debug.Log("[SimpleGameSetup] Scene setup created.");
    }

    private GameObject SetupPlayer()
    {
        // Check if player already exists
        SimplePlayerController existingPlayer = FindAnyObjectByType<SimplePlayerController>();
        if (existingPlayer != null)
        {
            // Ensure player has all required components
            EnsurePlayerComponents(existingPlayer.gameObject);
            Debug.Log("[SimpleGameSetup] Player already exists, ensuring components are present.");
            return existingPlayer.gameObject;
        }

        // Create player object
        GameObject player = new GameObject("Player");
        player.tag = "Player";

        // Position player above ground
        player.transform.position = new Vector3(0f, 1f, 0f);

        // Add required components
        EnsurePlayerComponents(player);

        Debug.Log("[SimpleGameSetup] Player created with all components.");

        return player;
    }

    private void EnsurePlayerComponents(GameObject player)
    {
        // Add SimplePlayerController if missing
        if (player.GetComponent<SimplePlayerController>() == null)
        {
            player.AddComponent<SimplePlayerController>();
        }

        // Add SimpleRageSystem if missing
        SimpleRageSystem rageSystem = player.GetComponent<SimpleRageSystem>();
        if (rageSystem == null)
        {
            rageSystem = player.AddComponent<SimpleRageSystem>();
        }

        // Add SimpleAttractSystem if missing
        if (player.GetComponent<SimpleAttractSystem>() == null)
        {
            player.AddComponent<SimpleAttractSystem>();
        }

        // Ensure player has a visual model
        if (player.GetComponentInChildren<Renderer>() == null)
        {
            CreatePlayerModel(player);
        }

        // Configure rage system visual reference
        if (rageSystem.playerRenderer == null)
        {
            Renderer playerRenderer = player.GetComponentInChildren<Renderer>();
            if (playerRenderer != null)
            {
                rageSystem.playerRenderer = playerRenderer;
            }
        }
    }

    private void CreatePlayerModel(GameObject player)
    {
        GameObject model = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        model.name = "PlayerModel";
        model.transform.SetParent(player.transform);
        model.transform.localPosition = new Vector3(0f, 1f, 0f);
        model.transform.localScale = new Vector3(0.5f, 1f, 0.5f);

        // Set blue color to distinguish from enemies
        model.GetComponent<Renderer>().material.color = Color.blue;

        // Remove collider since we have CharacterController
        Collider collider = model.GetComponent<Collider>();
        if (collider != null)
        {
            Destroy(collider);
        }
    }

    private GameObject SetupEnemySpawner(GameObject player)
    {
        // Check if enemy spawner already exists
        SimpleEnemySpawner existingSpawner = FindAnyObjectByType<SimpleEnemySpawner>();
        if (existingSpawner != null)
        {
            Debug.Log("[SimpleGameSetup] Enemy spawner already exists, skipping.");
            return existingSpawner.gameObject;
        }

        // Create enemy spawner object
        GameObject enemySpawnerObj = new GameObject("EnemySpawner");
        SimpleEnemySpawner enemySpawner = enemySpawnerObj.AddComponent<SimpleEnemySpawner>();

        // Configure spawner settings
        enemySpawner.spawnRate = 2f;
        enemySpawner.maxEnemies = 15;
        enemySpawner.spawnRadius = 20f;
        enemySpawner.minDistanceFromPlayer = 5f;

        // Disable wave system in spawner (we'll use WaveManager instead)
        enemySpawner.useWaveSystem = false;

        Debug.Log("[SimpleGameSetup] Enemy spawner created.");

        return enemySpawnerObj;
    }

    private void SetupWaveManager(GameObject player, GameObject enemySpawner)
    {
        // Check if wave manager already exists
        SimpleWaveManager existingWaveManager = FindAnyObjectByType<SimpleWaveManager>();
        if (existingWaveManager != null)
        {
            Debug.Log("[SimpleGameSetup] Wave manager already exists, skipping.");
            return;
        }

        // Create wave manager object
        GameObject waveManagerObj = new GameObject("WaveManager");
        SimpleWaveManager waveManager = waveManagerObj.AddComponent<SimpleWaveManager>();

        // Configure wave settings
        waveManager.currentWave = 1;
        waveManager.enemiesPerWaveMultiplier = 3;
        waveManager.startDelay = 2f;
        waveManager.waveTransitionDelay = 3f;
        waveManager.healthScaleMultiplier = 1.1f;
        waveManager.damageScaleMultiplier = 1.05f;
        waveManager.spawnRadius = 20f;
        waveManager.minDistanceFromPlayer = 5f;

        // Connect rage system
        SimpleRageSystem rageSystem = player.GetComponent<SimpleRageSystem>();
        if (rageSystem != null)
        {
            waveManager.rageSystem = rageSystem;
            waveManager.rageOnWaveComplete = 20f;
        }

        // Note: UI references will be set in SetupUI

        Debug.Log("[SimpleGameSetup] Wave manager created and configured.");
    }

    private void SetupUI(GameObject player)
    {
        // Check if canvas already exists
        Canvas existingCanvas = FindAnyObjectByType<Canvas>();
        if (existingCanvas != null)
        {
            Debug.Log("[SimpleGameSetup] Canvas already exists, checking for UI elements...");
            ConfigureExistingUI(existingCanvas, player);
            return;
        }

        // Create canvas
        GameObject canvasObj = new GameObject("GameCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Add canvas scaler
        CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = canvasSize;

        // Add graphic raycaster for UI interactions
        canvasObj.AddComponent<GraphicRaycaster>();

        // Create UI elements
        CreateWaveText(canvasObj.transform);
        Text rageText = CreateRageText(canvasObj.transform);
        CreateHealthBar(canvasObj.transform, player);

        // Configure wave manager with UI references
        SimpleWaveManager waveManager = FindAnyObjectByType<SimpleWaveManager>();
        if (waveManager != null)
        {
            waveManager.waveText = canvasObj.GetComponentInChildren<Text>();
            // Note: waveMessageText could be added if needed
        }

        // Configure rage system with UI reference
        SimpleRageSystem rageSystem = player.GetComponent<SimpleRageSystem>();
        if (rageSystem != null)
        {
            rageSystem.rageText = rageText;
        }

        Debug.Log("[SimpleGameSetup] UI created and configured.");
    }

    private void ConfigureExistingUI(Canvas canvas, GameObject player)
    {
        // Try to find existing UI elements and connect them
        Text[] textElements = canvas.GetComponentsInChildren<Text>();

        SimpleWaveManager waveManager = FindAnyObjectByType<SimpleWaveManager>();
        SimpleRageSystem rageSystem = player.GetComponent<SimpleRageSystem>();

        foreach (Text text in textElements)
        {
            if (text.name.Contains("Wave") && waveManager != null)
            {
                waveManager.waveText = text;
                Debug.Log("[SimpleGameSetup] Connected existing Wave Text to WaveManager.");
            }
            else if (text.name.Contains("Rage") && rageSystem != null)
            {
                rageSystem.rageText = text;
                Debug.Log("[SimpleGameSetup] Connected existing Rage Text to RageSystem.");
            }
        }
    }

    private Text CreateWaveText(Transform parent)
    {
        GameObject textObj = new GameObject("WaveText");
        textObj.transform.SetParent(parent);

        RectTransform rectTransform = textObj.AddComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 1f);
        rectTransform.anchorMax = new Vector2(0.5f, 1f);
        rectTransform.pivot = new Vector2(0.5f, 1f);
        rectTransform.anchoredPosition = new Vector2(0f, -20f);
        rectTransform.sizeDelta = new Vector2(400f, 50f);

        Text text = textObj.AddComponent<Text>();
        text.text = "Wave: 1";
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.fontSize = 36;
        text.fontStyle = FontStyle.Bold;
        text.color = waveTextColor;
        text.alignment = TextAnchor.MiddleCenter;

        return text;
    }

    private Text CreateRageText(Transform parent)
    {
        GameObject textObj = new GameObject("RageText");
        textObj.transform.SetParent(parent);

        RectTransform rectTransform = textObj.AddComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(1f, 1f);
        rectTransform.anchorMax = new Vector2(1f, 1f);
        rectTransform.pivot = new Vector2(1f, 1f);
        rectTransform.anchoredPosition = new Vector2(-20f, -20f);
        rectTransform.sizeDelta = new Vector2(300f, 50f);

        Text text = textObj.AddComponent<Text>();
        text.text = "RAGE: 0/100";
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.fontSize = 28;
        text.fontStyle = FontStyle.Bold;
        text.color = rageTextColor;
        text.alignment = TextAnchor.MiddleRight;

        return text;
    }

    private void CreateHealthBar(Transform parent, GameObject player)
    {
        // Create health bar background
        GameObject healthBarBg = new GameObject("HealthBarBackground");
        healthBarBg.transform.SetParent(parent);

        RectTransform bgRect = healthBarBg.AddComponent<RectTransform>();
        bgRect.anchorMin = new Vector2(0.5f, 0f);
        bgRect.anchorMax = new Vector2(0.5f, 0f);
        bgRect.pivot = new Vector2(0.5f, 0f);
        bgRect.anchoredPosition = new Vector2(0f, 20f);
        bgRect.sizeDelta = new Vector2(400f, 30f);

        Image bgImage = healthBarBg.AddComponent<Image>();
        bgImage.color = healthBarBackground;

        // Create health bar fill
        GameObject healthBarFill = new GameObject("HealthBarFill");
        healthBarFill.transform.SetParent(healthBarBg.transform);

        RectTransform fillRect = healthBarFill.AddComponent<RectTransform>();
        fillRect.anchorMin = Vector2.zero;
        fillRect.anchorMax = new Vector2(1f, 1f);
        fillRect.pivot = new Vector2(0f, 0.5f);
        fillRect.anchoredPosition = Vector2.zero;
        fillRect.sizeDelta = new Vector2(0f, 0f);

        Image fillImage = healthBarFill.AddComponent<Image>();
        fillImage.color = healthBarColor;
        fillImage.type = Image.Type.Filled;
        fillImage.fillMethod = Image.FillMethod.Horizontal;
        fillImage.fillAmount = 1f;

        // Create health monitor component to update the bar
        SimpleHealthMonitor healthMonitor = healthBarBg.AddComponent<SimpleHealthMonitor>();
        healthMonitor.player = player.GetComponent<SimplePlayerController>();
        healthMonitor.healthBarFill = fillImage;
    }

    /// <summary>
    /// Small helper component to monitor player health and update the health bar.
    /// </summary>
    private class SimpleHealthMonitor : MonoBehaviour
    {
        public SimplePlayerController player;
        public Image healthBarFill;

        private float maxHealth;
        private bool initialized = false;

        void Update()
        {
            if (player == null || healthBarFill == null)
                return;

            if (!initialized)
            {
                // Get max health from player (using reflection since it's private)
                var healthField = typeof(SimplePlayerController).GetField("health",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (healthField != null)
                {
                    // Store initial health as max
                    maxHealth = (float)healthField.GetValue(player);
                    initialized = true;
                }
            }
            else
            {
                // Get current health
                var healthField = typeof(SimplePlayerController).GetField("health",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (healthField != null)
                {
                    float currentHealth = (float)healthField.GetValue(player);
                    healthBarFill.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
                }
            }
        }
    }
}
