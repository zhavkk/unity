using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.SceneManagement;

/// <summary>
/// Автоматическая настройка сцены одной кнопкой в Unity Editor.
/// Найдите в меню: Tools → Auto Scene Setup → Setup Game Scene
/// </summary>
public class AutoSceneSetupEditor : EditorWindow
{
    private bool showProgress = false;
    private string progressMessage = "";
    private float progress = 0f;

    [MenuItem("Tools/Auto Scene Setup/Setup Game Scene")]
    public static void ShowWindow()
    {
        GetWindow<AutoSceneSetupEditor>("Auto Scene Setup");
    }

    void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("🎮 Auto Scene Setup - Simple Slasher", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.HelpBox(
            "Эта кнопка автоматически настроит всю сцену:\n" +
            "• Создаст слой Enemy\n" +
            "• Создаст игрока со всеми компонентами\n" +
            "• Создаст префаб врага\n" +
            "• Создаст WaveManager\n" +
            "• Создаст окружение (Ground, Camera, Light)\n" +
            "• Настроит все связи и параметры\n\n" +
            "⚠️ Убедитесь, что сцена SampleScene.unity открыта!",
            MessageType.Info
        );

        EditorGUILayout.Space();

        if (GUILayout.Button("🚀 НАСТРОИТЬ СЦЕНУ", GUILayout.Height(50)))
        {
            SetupScene();
        }

        EditorGUILayout.Space();

        if (showProgress)
        {
            Rect progressRect = EditorGUILayout.GetControlRect(false, 20);
            EditorGUI.ProgressBar(progressRect, progress, progressMessage);
            EditorGUILayout.Space();
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("📋 Шаги настройки:", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox(
            "1. Откройте SampleScene.unity\n" +
            "2. Нажмите кнопку 'НАСТРОИТЬ СЦЕНУ'\n" +
            "3. Дождитесь завершения (100%)\n" +
            "4. Сохраните сцену (Ctrl+S)\n" +
            "5. Нажмите Play и играйте!",
            MessageType.None
        );
    }

    private void SetupScene()
    {
        showProgress = true;
        progress = 0f;
        progressMessage = "Начинаем настройку...";

        EditorUtility.DisplayProgressBar(
            "Auto Scene Setup",
            "Настройка сцены...",
            0f
        );

        try
        {
            // Step 1: Create Enemy Layer
            UpdateProgress(0.1f, "Создаём слой Enemy...");
            CreateEnemyLayer();

            // Step 2: Create Player
            UpdateProgress(0.2f, "Создаём игрока...");
            GameObject player = CreatePlayer();

            // Step 3: Create Enemy Prefab
            UpdateProgress(0.4f, "Создаём префаб врага...");
            GameObject enemyPrefab = CreateEnemyPrefab();

            // Step 4: Create Wave Manager
            UpdateProgress(0.6f, "Создаём WaveManager...");
            GameObject waveManager = CreateWaveManager(player, enemyPrefab);

            // Step 5: Create Environment
            UpdateProgress(0.7f, "Создаём окружение...");
            CreateEnvironment();

            // Step 6: Setup Camera
            UpdateProgress(0.8f, "Настраиваем камеру...");
            SetupCamera();

            // Step 7: Create Light
            UpdateProgress(0.9f, "Создаём освещение...");
            CreateLight();

            // Step 8: Finalize
            UpdateProgress(1.0f, "Завершаем настройку...");
            FinalizeSetup();

            EditorUtility.DisplayDialog(
                "✅ Настройка завершена!",
                "Сцена успешно настроена!\n\n" +
                "Далее:\n" +
                "1. Сохраните сцену (Ctrl+S)\n" +
                "2. Нажмите Play и играйте!",
                "OK"
            );

            Debug.Log("✅ Auto Scene Setup: Сцена успешно настроена!");
        }
        catch (System.Exception e)
        {
            EditorUtility.DisplayDialog(
                "❌ Ошибка настройки",
                "Произошла ошибка при настройке:\n" + e.Message + "\n\n" +
                "Проверьте консоль Unity для деталей.",
                "OK"
            );
            Debug.LogError("❌ Auto Scene Setup Error: " + e.Message);
        }
        finally
        {
            EditorUtility.ClearProgressBar();
            showProgress = false;
        }

        Repaint();
    }

    private void UpdateProgress(float value, string message)
    {
        progress = value;
        progressMessage = message;
        EditorUtility.DisplayProgressBar(
            "Auto Scene Setup",
            message,
            value
        );
    }

    private void CreateEnemyLayer()
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);

        // Create Enemy Tag
        SerializedProperty tagsProp = tagManager.FindProperty("tags");
        bool enemyTagExists = false;
        for (int i = 0; i < tagsProp.arraySize; i++)
        {
            SerializedProperty tagProp = tagsProp.GetArrayElementAtIndex(i);
            if (tagProp.stringValue == "Enemy")
            {
                enemyTagExists = true;
                break;
            }
        }

        if (!enemyTagExists)
        {
            tagsProp.arraySize++;
            SerializedProperty newTagProp = tagsProp.GetArrayElementAtIndex(tagsProp.arraySize - 1);
            newTagProp.stringValue = "Enemy";
            tagManager.ApplyModifiedProperties();
            Debug.Log("✅ Created Enemy tag");
        }
        else
        {
            Debug.Log("ℹ️ Enemy tag already exists");
        }

        // Create Enemy Layer
        SerializedProperty layersProp = tagManager.FindProperty("layers");

        bool enemyLayerExists = false;
        for (int i = 0; i < 32; i++)
        {
            SerializedProperty layerProp = layersProp.GetArrayElementAtIndex(i);
            if (layerProp.stringValue == "Enemy")
            {
                enemyLayerExists = true;
                break;
            }
        }

        if (!enemyLayerExists)
        {
            for (int i = 8; i < 32; i++)
            {
                SerializedProperty layerProp = layersProp.GetArrayElementAtIndex(i);
                if (string.IsNullOrEmpty(layerProp.stringValue))
                {
                    layerProp.stringValue = "Enemy";
                    tagManager.ApplyModifiedProperties();
                    Debug.Log("✅ Created Enemy layer at index " + i);
                    break;
                }
            }
        }
        else
        {
            Debug.Log("ℹ️ Enemy layer already exists");
        }
    }

    private GameObject CreatePlayer()
    {
        // Check if player already exists
        GameObject existingPlayer = GameObject.FindWithTag("Player");
        if (existingPlayer != null)
        {
            Debug.Log("ℹ️ Player already exists");
            return existingPlayer;
        }

        // Create player container
        GameObject player = new GameObject("Player");
        player.name = "Player";
        player.tag = "Player";
        player.layer = LayerMask.NameToLayer("Default");
        player.transform.position = new Vector3(0, 1, 0);

        // Add detailed player model
        GameObject playerModel = ModelGenerator.CreatePlayerModel();
        playerModel.transform.SetParent(player.transform);
        playerModel.transform.localPosition = Vector3.zero;

        // Add Character Controller
        CharacterController charController = player.AddComponent<CharacterController>();
        charController.height = 2f;
        charController.radius = 0.5f;
        charController.slopeLimit = 45f;
        charController.stepOffset = 0.3f;
        charController.skinWidth = 0.08f;
        charController.center = new Vector3(0, 0, 0);
        charController.minMoveDistance = 0f;

        // Create attack point
        GameObject attackPoint = new GameObject("AttackPoint");
        attackPoint.transform.SetParent(player.transform);
        attackPoint.transform.localPosition = new Vector3(0, 1f, 1.5f);

        // Add components
        EnhancedPlayerController playerController = player.AddComponent<EnhancedPlayerController>();

        // Set EnhancedPlayerController fields via SerializedObject
        SerializedObject playerControllerSO = new SerializedObject(playerController);
        playerControllerSO.FindProperty("attackPoint").objectReferenceValue = attackPoint.transform;
        playerControllerSO.FindProperty("attackRange").floatValue = 2f;
        playerControllerSO.FindProperty("baseDamage").floatValue = 10f;
        playerControllerSO.FindProperty("baseAttackSpeed").floatValue = 1f;
        playerControllerSO.FindProperty("walkSpeed").floatValue = 5f;
        playerControllerSO.FindProperty("sprintSpeed").floatValue = 8f;
        playerControllerSO.FindProperty("jumpForce").floatValue = 8f;
        playerControllerSO.FindProperty("maxHealth").floatValue = 100f;
        playerControllerSO.ApplyModifiedProperties();

        // Add Player Attract
        PlayerAttract playerAttract = player.AddComponent<PlayerAttract>();
        SerializedObject playerAttractSO = new SerializedObject(playerAttract);
        playerAttractSO.FindProperty("enemyLayer").intValue = LayerMask.GetMask("Enemy");
        playerAttractSO.FindProperty("dashSpeed").floatValue = 15f;
        playerAttractSO.FindProperty("dashDuration").floatValue = 0.3f;
        playerAttractSO.FindProperty("dashRange").floatValue = 20f;
        playerAttractSO.ApplyModifiedProperties();

        // Add Rage System
        RageSystem rageSystem = player.AddComponent<RageSystem>();
        SerializedObject rageSystemSO = new SerializedObject(rageSystem);
        rageSystemSO.FindProperty("maxRage").floatValue = 100f;
        rageSystemSO.FindProperty("ragePerAttack").floatValue = 5f;
        rageSystemSO.FindProperty("rageDecayPerSecond").floatValue = 10f;
        rageSystemSO.FindProperty("rageDamageTaken").floatValue = 20f;
        rageSystemSO.FindProperty("inactivityThreshold").floatValue = 3f;
        rageSystemSO.FindProperty("maxDamageMultiplier").floatValue = 3f;
        rageSystemSO.FindProperty("maxAttackSpeedMultiplier").floatValue = 2f;
        rageSystemSO.ApplyModifiedProperties();

        // Add Player Health
        player.AddComponent<PlayerHealth>();

        // Add Game Integrator
        player.AddComponent<GameIntegrator>();

        Debug.Log("✅ Player created successfully");
        return player;
    }

    private GameObject CreateEnemyPrefab()
    {
        // Create enemy object
        GameObject enemy = new GameObject("Enemy");

        // Add detailed enemy model
        GameObject enemyModel = ModelGenerator.CreateEnemyModel();
        enemyModel.transform.SetParent(enemy.transform);
        enemyModel.transform.localPosition = Vector3.zero;

        // Add capsule collider to parent
        CapsuleCollider collider = enemy.AddComponent<CapsuleCollider>();
        collider.height = 1.5f;
        collider.radius = 0.4f;
        collider.center = new Vector3(0, 0.75f, 0);

        // Add Rigidbody
        Rigidbody rb = enemy.AddComponent<Rigidbody>();
        rb.mass = 1f;
        rb.linearDamping = 0f;
        rb.angularDamping = 0.05f;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        // Add Enemy Health
        EnemyHealth enemyHealth = enemy.AddComponent<EnemyHealth>();
        SerializedObject enemyHealthSO = new SerializedObject(enemyHealth);
        enemyHealthSO.FindProperty("maxHealth").floatValue = 30f;
        enemyHealthSO.ApplyModifiedProperties();

        // Add Enemy Controller
        EnemyController enemyController = enemy.AddComponent<EnemyController>();
        SerializedObject enemyControllerSO = new SerializedObject(enemyController);
        enemyControllerSO.FindProperty("maxHealth").floatValue = 30f;
        enemyControllerSO.FindProperty("damage").floatValue = 10f;
        enemyControllerSO.FindProperty("moveSpeed").floatValue = 2f;
        enemyControllerSO.FindProperty("attackRange").floatValue = 1.5f;
        enemyControllerSO.FindProperty("attackCooldown").floatValue = 1f;
        enemyControllerSO.ApplyModifiedProperties();

        // Set enemy tag and layer
        enemy.tag = "Enemy";
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        if (enemyLayer == -1)
        {
            enemyLayer = 6; // Try Layer 6
        }
        enemy.layer = enemyLayer;

        // Save as prefab
        string prefabPath = "Assets/Scripts/Enemy.prefab";
        PrefabUtility.SaveAsPrefabAsset(enemy, prefabPath);

        // Destroy from scene
        DestroyImmediate(enemy);

        // Load prefab and return it
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        Debug.Log("✅ Enemy prefab created at: " + prefabPath);
        return prefab;
    }

    private GameObject CreateWaveManager(GameObject player, GameObject enemyPrefab)
    {
        // Check if WaveManager already exists
        WaveManager existingManager = Object.FindAnyObjectByType<WaveManager>();
        if (existingManager != null)
        {
            Debug.Log("ℹ️ WaveManager already exists");
            return existingManager.gameObject;
        }

        // Create Wave Manager
        GameObject waveManagerObj = new GameObject("WaveManager");
        WaveManager waveManager = waveManagerObj.AddComponent<WaveManager>();

        // Set parameters via SerializedObject
        SerializedObject waveManagerSO = new SerializedObject(waveManager);

        // Set player transform
        SerializedProperty playerTransformProp = waveManagerSO.FindProperty("playerTransform");
        if (playerTransformProp != null)
        {
            playerTransformProp.objectReferenceValue = player.transform;
        }

        // Set enemy prefab
        SerializedProperty enemyPrefabProp = waveManagerSO.FindProperty("enemyPrefab");
        if (enemyPrefabProp != null)
        {
            enemyPrefabProp.objectReferenceValue = enemyPrefab;
        }

        // Set wave parameters
        SerializedProperty startingEnemiesProp = waveManagerSO.FindProperty("startingEnemies");
        if (startingEnemiesProp != null)
        {
            startingEnemiesProp.intValue = 3;
        }

        SerializedProperty enemiesPerWaveIncreaseProp = waveManagerSO.FindProperty("enemiesPerWaveIncrease");
        if (enemiesPerWaveIncreaseProp != null)
        {
            enemiesPerWaveIncreaseProp.intValue = 2;
        }

        SerializedProperty waveDelayProp = waveManagerSO.FindProperty("waveDelay");
        if (waveDelayProp != null)
        {
            waveDelayProp.floatValue = 5f;
        }

        SerializedProperty minSpawnDistanceProp = waveManagerSO.FindProperty("minSpawnDistance");
        if (minSpawnDistanceProp != null)
        {
            minSpawnDistanceProp.floatValue = 10f;
        }

        SerializedProperty maxSpawnDistanceProp = waveManagerSO.FindProperty("maxSpawnDistance");
        if (maxSpawnDistanceProp != null)
        {
            maxSpawnDistanceProp.floatValue = 20f;
        }

        waveManagerSO.ApplyModifiedProperties();

        // Create UI
        CreateWaveUI(waveManagerObj);

        Debug.Log("✅ WaveManager created successfully");
        return waveManagerObj;
    }

    private void CreateWaveUI(GameObject waveManager)
    {
        // Find existing canvas
        Canvas existingCanvas = Object.FindAnyObjectByType<Canvas>();
        Canvas canvas;

        if (existingCanvas != null)
        {
            canvas = existingCanvas;
            Debug.Log("ℹ️ Canvas already exists");
        }
        else
        {
            // Create Canvas
            GameObject canvasObj = new GameObject("GameCanvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            CanvasScaler scaler = canvasObj.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            canvasObj.AddComponent<UnityEngine.UI.GraphicRaycaster>();
            Debug.Log("✅ Canvas created");
        }

        // Create wave counter text
        GameObject waveCounterObj = new GameObject("WaveCounterText");
        waveCounterObj.transform.SetParent(canvas.transform);
        RectTransform waveCounterRect = waveCounterObj.AddComponent<RectTransform>();
        waveCounterRect.anchoredPosition = new Vector2(-450, 300);
        waveCounterRect.sizeDelta = new Vector2(300, 50);

        UnityEngine.UI.Text waveCounterText = waveCounterObj.AddComponent<UnityEngine.UI.Text>();
        waveCounterText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        waveCounterText.fontSize = 32;
        waveCounterText.alignment = TextAnchor.MiddleCenter;
        waveCounterText.color = Color.white;

        // Create enemies remaining text
        GameObject enemiesRemainingObj = new GameObject("EnemiesRemainingText");
        enemiesRemainingObj.transform.SetParent(canvas.transform);
        RectTransform enemiesRemainingRect = enemiesRemainingObj.AddComponent<RectTransform>();
        enemiesRemainingRect.anchoredPosition = new Vector2(450, 300);
        enemiesRemainingRect.sizeDelta = new Vector2(300, 50);

        UnityEngine.UI.Text enemiesRemainingText = enemiesRemainingObj.AddComponent<UnityEngine.UI.Text>();
        enemiesRemainingText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        enemiesRemainingText.fontSize = 32;
        enemiesRemainingText.alignment = TextAnchor.MiddleCenter;
        enemiesRemainingText.color = Color.white;

        // Assign text to WaveManager
        SerializedObject waveManagerSO = new SerializedObject(waveManager.GetComponent<WaveManager>());

        SerializedProperty waveCounterTextProp = waveManagerSO.FindProperty("waveCounterText");
        if (waveCounterTextProp != null)
        {
            waveCounterTextProp.objectReferenceValue = waveCounterText;
        }

        SerializedProperty enemiesRemainingTextProp = waveManagerSO.FindProperty("enemiesRemainingText");
        if (enemiesRemainingTextProp != null)
        {
            enemiesRemainingTextProp.objectReferenceValue = enemiesRemainingText;
        }

        waveManagerSO.ApplyModifiedProperties();
        Debug.Log("✅ Wave UI created");
    }

    private void CreateEnvironment()
    {
        // Check if ground already exists
        GameObject existingGround = GameObject.Find("Ground");
        if (existingGround != null)
        {
            Debug.Log("ℹ️ Ground already exists");
            return;
        }

        // Create ground
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.position = Vector3.zero;
        ground.transform.localScale = new Vector3(20, 1, 20);

        // Set ground color
        Renderer renderer = ground.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material mat = new Material(Shader.Find("Standard"));
            mat.color = new Color(0.3f, 0.3f, 0.3f);
            renderer.material = mat;
        }

        Debug.Log("✅ Ground created successfully");
    }

    private void SetupCamera()
    {
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        if (mainCamera == null)
        {
            mainCamera = Camera.main?.gameObject;
        }

        if (mainCamera == null)
        {
            // Create new camera
            mainCamera = new GameObject("MainCamera");
            mainCamera.tag = "MainCamera";
            Camera cam = mainCamera.AddComponent<Camera>();
            cam.clearFlags = CameraClearFlags.Skybox;
            mainCamera.AddComponent<AudioListener>();
            Debug.Log("✅ MainCamera created");
        }
        else
        {
            Debug.Log("ℹ️ MainCamera already exists");
        }

        // Setup camera
        mainCamera.transform.position = new Vector3(0, 5, -10);
        mainCamera.transform.rotation = Quaternion.Euler(15, 0, 0);
    }

    private void CreateLight()
    {
        // Check if light already exists
        Light existingLight = Object.FindAnyObjectByType<Light>();
        if (existingLight != null)
        {
            Debug.Log("ℹ️ Light already exists");
            return;
        }

        // Create directional light
        GameObject lightObj = new GameObject("DirectionalLight");
        lightObj.transform.position = new Vector3(10, 10, 0);
        lightObj.transform.rotation = Quaternion.Euler(50, -30, 0);

        Light light = lightObj.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1f;
        light.shadows = LightShadows.Soft;

        Debug.Log("✅ Directional Light created successfully");
    }

    private void FinalizeSetup()
    {
        // Force save scene
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}