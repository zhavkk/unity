using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(-1000)]
public class SimpleMVPSetup : MonoBehaviour
{
    [Header("Bootstrap")]
    [SerializeField] private bool autoSetup = true;
    [SerializeField] private bool fixErrorShaderMaterials = true;

    [Header("Colors")]
    [SerializeField] private Color groundColor = new Color(0.45f, 0.45f, 0.45f, 1f);
    [SerializeField] private Color playerColor = new Color(0.2f, 0.6f, 1f, 1f);
    [SerializeField] private Color enemyColor = new Color(1f, 0.2f, 0.2f, 1f);
    [SerializeField] private Color swordColor = new Color(0.8f, 0.8f, 0.9f, 1f);

    [Header("Model Prefabs")]
    [SerializeField] private GameObject playerModelPrefab;
    [SerializeField] private GameObject enemyModelPrefab;
    [SerializeField] private GameObject swordModelPrefab;

    [Header("Environment")]
    [SerializeField] private float groundSize = 30f;

    private Material groundMaterial;
    private Material playerMaterial;
    private Material enemyMaterial;
    private Material swordMaterial;
    private Material fallbackMaterial;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void EnsureBootstrap()
    {
        if (Object.FindAnyObjectByType<SimpleMVPSetup>() != null)
        {
            return;
        }

        GameObject bootstrap = new GameObject("MVP_Bootstrap");
        bootstrap.AddComponent<SimpleMVPSetup>();
    }

    private void Awake()
    {
        groundMaterial = MvpMaterialUtility.CreateLitMaterial(groundColor);
        playerMaterial = MvpMaterialUtility.CreateLitMaterial(playerColor);
        enemyMaterial = MvpMaterialUtility.CreateLitMaterial(enemyColor);
        swordMaterial = MvpMaterialUtility.CreateLitMaterial(swordColor);
        fallbackMaterial = MvpMaterialUtility.CreateLitMaterial(new Color(0.4f, 0.4f, 0.4f, 1f));
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        TryAutoAssignRpgHeroAssets();
    }

    private void TryAutoAssignRpgHeroAssets()
    {
        if (playerModelPrefab == null)
        {
            playerModelPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/RPGHero/Prefabs/RPGHeroPBR.prefab");
        }

        if (enemyModelPrefab == null)
        {
            enemyModelPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/RPGHero/Prefabs/RPGHeroPolyart.prefab");
        }

        if (swordModelPrefab == null)
        {
            swordModelPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/RPGHero/Meshes/Sword.fbx");
        }
    }
#endif

    private void Start()
    {
        if (!autoSetup)
        {
            return;
        }

        SetupScene();

        if (fixErrorShaderMaterials)
        {
            FixErrorShaderMaterials();
        }

        enabled = false;
    }

    private void SetupScene()
    {
        EnsureGround();
        GameObject player = EnsurePlayer();
        EnsureEnemySpawner(player);
        EnsureCamera(player);
        EnsureLight();
        EnsureUI(player);
    }

    private void EnsureGround()
    {
        GameObject ground = GameObject.Find("Ground");
        if (ground == null)
        {
            ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.position = Vector3.zero;

            float planeScale = groundSize / 10f;
            ground.transform.localScale = new Vector3(planeScale, 1f, planeScale);
        }

        Renderer renderer = ground.GetComponent<Renderer>();
        if (renderer != null && groundMaterial != null)
        {
            renderer.sharedMaterial = groundMaterial;
        }
    }

    private GameObject EnsurePlayer()
    {
        GameObject player = FindExistingPlayer();
        if (player == null)
        {
            player = new GameObject("Player");
            player.transform.position = new Vector3(0f, 1f, 0f);
        }

        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller == null)
        {
            controller = player.AddComponent<CharacterController>();
        }
        controller.height = 2f;
        controller.radius = 0.5f;
        controller.center = new Vector3(0f, 1f, 0f);

        EnsurePlayerModel(player);

        MvpRageSystem rage = player.GetComponent<MvpRageSystem>();
        if (rage == null)
        {
            rage = player.AddComponent<MvpRageSystem>();
        }

        MvpPlayerHealth health = player.GetComponent<MvpPlayerHealth>();
        if (health == null)
        {
            health = player.AddComponent<MvpPlayerHealth>();
        }
        health.Initialize(rage);

        MvpPlayerCombat combat = player.GetComponent<MvpPlayerCombat>();
        if (combat == null)
        {
            combat = player.AddComponent<MvpPlayerCombat>();
        }

        Transform attackPoint = EnsureAttackPoint(player);
        MvpSwordSwing swordSwing = EnsureSword(player);
        combat.Initialize(rage, attackPoint, health, swordSwing);

        MvpPlayerController movement = player.GetComponent<MvpPlayerController>();
        if (movement == null)
        {
            movement = player.AddComponent<MvpPlayerController>();
        }
        movement.Initialize(rage, combat, health);

        return player;
    }

    private static GameObject FindExistingPlayer()
    {
        MvpPlayerController existingController = Object.FindAnyObjectByType<MvpPlayerController>();
        if (existingController != null)
        {
            return existingController.gameObject;
        }

        return GameObject.Find("Player");
    }

    private void EnsurePlayerModel(GameObject player)
    {
        Transform existingModel = player.transform.Find("Model");
        Transform existingVisualRoot = FindExistingVisualRoot(player.transform);

        if (playerModelPrefab != null)
        {
            if (existingVisualRoot != null)
            {
                Destroy(existingVisualRoot.gameObject);
            }

            GameObject model = Instantiate(playerModelPrefab, player.transform);
            model.name = "Model";
            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
            RemoveChildColliders(model.transform);
            return;
        }

        if (existingModel != null)
        {
            return;
        }

        if (existingVisualRoot != null)
        {
            existingVisualRoot.name = "Model";
            return;
        }

        GameObject fallback = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        fallback.name = "Model";
        fallback.transform.SetParent(player.transform);
        fallback.transform.localPosition = new Vector3(0f, 1f, 0f);
        fallback.transform.localScale = new Vector3(0.5f, 1f, 0.5f);

        if (playerMaterial != null)
        {
            Renderer renderer = fallback.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial = playerMaterial;
            }
        }

        Collider fallbackCollider = fallback.GetComponent<Collider>();
        if (fallbackCollider != null)
        {
            Destroy(fallbackCollider);
        }
    }

    private Transform EnsureAttackPoint(GameObject player)
    {
        Transform attackPoint = player.transform.Find("AttackPoint");
        if (attackPoint == null)
        {
            GameObject attackPointObj = new GameObject("AttackPoint");
            attackPointObj.transform.SetParent(player.transform);
            attackPointObj.transform.localPosition = new Vector3(0f, 1f, 1f);
            attackPoint = attackPointObj.transform;
        }

        return attackPoint;
    }

    private void EnsureEnemySpawner(GameObject player)
    {
        MvpEnemySpawner spawner = Object.FindAnyObjectByType<MvpEnemySpawner>();
        if (spawner == null)
        {
            GameObject spawnerObj = new GameObject("EnemySpawner");
            spawner = spawnerObj.AddComponent<MvpEnemySpawner>();
        }

        MvpPlayerHealth playerHealth = player.GetComponent<MvpPlayerHealth>();
        spawner.Initialize(player.transform, playerHealth, enemyMaterial, enemyModelPrefab);
    }

    private void EnsureCamera(GameObject player)
    {
        Camera camera = Camera.main;
        if (camera == null)
        {
            GameObject cameraObj = new GameObject("MainCamera");
            cameraObj.tag = "MainCamera";
            camera = cameraObj.AddComponent<Camera>();
            cameraObj.AddComponent<AudioListener>();
        }

        MvpCameraFollow follow = camera.GetComponent<MvpCameraFollow>();
        if (follow == null)
        {
            follow = camera.gameObject.AddComponent<MvpCameraFollow>();
        }

        follow.Initialize(player.transform);
    }

    private void EnsureLight()
    {
        Light existingLight = Object.FindAnyObjectByType<Light>();
        if (existingLight != null)
        {
            return;
        }

        GameObject lightObj = new GameObject("Directional Light");
        Light light = lightObj.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.1f;
        lightObj.transform.rotation = Quaternion.Euler(50f, -30f, 0f);
    }

    private void EnsureUI(GameObject player)
    {
        Canvas canvas = Object.FindAnyObjectByType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObj = new GameObject("GameCanvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
        }

        MvpRageSystem rage = player.GetComponent<MvpRageSystem>();
        MvpPlayerHealth health = player.GetComponent<MvpPlayerHealth>();

        Image rageFill;
        Transform ragePanel = canvas.transform.Find("RagePanel");
        if (ragePanel == null)
        {
            ragePanel = CreateRagePanel(canvas.transform, out rageFill);
        }
        else
        {
            rageFill = ragePanel.Find("RageFill")?.GetComponent<Image>();
        }

        if (rageFill != null)
        {
            MvpRageBarUI rageUi = ragePanel.GetComponent<MvpRageBarUI>();
            if (rageUi == null)
            {
                rageUi = ragePanel.gameObject.AddComponent<MvpRageBarUI>();
            }
            rageUi.Initialize(rageFill, rage);
        }

        Image healthFill;
        Transform healthPanel = canvas.transform.Find("HealthPanel");
        if (healthPanel == null)
        {
            healthPanel = CreateHealthPanel(canvas.transform, out healthFill);
        }
        else
        {
            healthFill = healthPanel.Find("HealthFill")?.GetComponent<Image>();
        }

        Text healthText = null;
        if (healthPanel != null)
        {
            healthText = healthPanel.Find("HealthText")?.GetComponent<Text>();
        }

        if (healthFill != null)
        {
            MvpHealthBarUI healthUi = healthPanel.GetComponent<MvpHealthBarUI>();
            if (healthUi == null)
            {
                healthUi = healthPanel.gameObject.AddComponent<MvpHealthBarUI>();
            }
            healthUi.Initialize(healthFill, healthText, health);
        }

        Text gameOverText;
        Transform gameOver = canvas.transform.Find("GameOverText");
        if (gameOver == null)
        {
            gameOver = CreateGameOverText(canvas.transform, out gameOverText);
        }
        else
        {
            gameOverText = gameOver.GetComponent<Text>();
        }

        if (gameOverText != null)
        {
            MvpGameOverUI gameOverUi = gameOver.GetComponent<MvpGameOverUI>();
            if (gameOverUi == null)
            {
                gameOverUi = gameOver.gameObject.AddComponent<MvpGameOverUI>();
            }
            gameOverUi.Initialize(gameOverText, health);
        }
    }

    private Transform CreateRagePanel(Transform parent, out Image fillImage)
    {
        GameObject panelObj = new GameObject("RagePanel");
        panelObj.transform.SetParent(parent);

        RectTransform panelRect = panelObj.AddComponent<RectTransform>();
        panelRect.anchorMin = new Vector2(0f, 0f);
        panelRect.anchorMax = new Vector2(0f, 0f);
        panelRect.pivot = new Vector2(0f, 0f);
        panelRect.anchoredPosition = new Vector2(20f, 20f);
        panelRect.sizeDelta = new Vector2(220f, 28f);

        Image background = panelObj.AddComponent<Image>();
        background.color = new Color(0f, 0f, 0f, 0.5f);

        GameObject fillObj = new GameObject("RageFill");
        fillObj.transform.SetParent(panelObj.transform);

        RectTransform fillRect = fillObj.AddComponent<RectTransform>();
        fillRect.anchorMin = new Vector2(0.25f, 0.2f);
        fillRect.anchorMax = new Vector2(0.95f, 0.8f);
        fillRect.offsetMin = Vector2.zero;
        fillRect.offsetMax = Vector2.zero;

        fillImage = fillObj.AddComponent<Image>();
        fillImage.color = Color.red;
        fillImage.type = Image.Type.Filled;
        fillImage.fillMethod = Image.FillMethod.Horizontal;
        fillImage.fillAmount = 0f;

        GameObject labelObj = new GameObject("RageLabel");
        labelObj.transform.SetParent(panelObj.transform);

        RectTransform labelRect = labelObj.AddComponent<RectTransform>();
        labelRect.anchorMin = Vector2.zero;
        labelRect.anchorMax = Vector2.one;
        labelRect.offsetMin = Vector2.zero;
        labelRect.offsetMax = Vector2.zero;

        Text label = labelObj.AddComponent<Text>();
        label.text = "RAGE";
        label.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        label.fontSize = 14;
        label.color = Color.red;
        label.alignment = TextAnchor.MiddleLeft;

        return panelObj.transform;
    }

    private Transform CreateHealthPanel(Transform parent, out Image fillImage)
    {
        GameObject panelObj = new GameObject("HealthPanel");
        panelObj.transform.SetParent(parent);

        RectTransform panelRect = panelObj.AddComponent<RectTransform>();
        panelRect.anchorMin = new Vector2(0f, 0f);
        panelRect.anchorMax = new Vector2(0f, 0f);
        panelRect.pivot = new Vector2(0f, 0f);
        panelRect.anchoredPosition = new Vector2(20f, 60f);
        panelRect.sizeDelta = new Vector2(220f, 28f);

        Image background = panelObj.AddComponent<Image>();
        background.color = new Color(0f, 0f, 0f, 0.5f);

        GameObject fillObj = new GameObject("HealthFill");
        fillObj.transform.SetParent(panelObj.transform);

        RectTransform fillRect = fillObj.AddComponent<RectTransform>();
        fillRect.anchorMin = new Vector2(0.25f, 0.2f);
        fillRect.anchorMax = new Vector2(0.95f, 0.8f);
        fillRect.offsetMin = Vector2.zero;
        fillRect.offsetMax = Vector2.zero;

        fillImage = fillObj.AddComponent<Image>();
        fillImage.color = new Color(0.2f, 0.9f, 0.2f, 1f);
        fillImage.type = Image.Type.Filled;
        fillImage.fillMethod = Image.FillMethod.Horizontal;
        fillImage.fillAmount = 1f;

        GameObject labelObj = new GameObject("HealthLabel");
        labelObj.transform.SetParent(panelObj.transform);

        RectTransform labelRect = labelObj.AddComponent<RectTransform>();
        labelRect.anchorMin = Vector2.zero;
        labelRect.anchorMax = Vector2.one;
        labelRect.offsetMin = Vector2.zero;
        labelRect.offsetMax = Vector2.zero;

        Text label = labelObj.AddComponent<Text>();
        label.text = "HP";
        label.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        label.fontSize = 14;
        label.color = new Color(0.2f, 0.9f, 0.2f, 1f);
        label.alignment = TextAnchor.MiddleLeft;

        GameObject valueObj = new GameObject("HealthText");
        valueObj.transform.SetParent(panelObj.transform);

        RectTransform valueRect = valueObj.AddComponent<RectTransform>();
        valueRect.anchorMin = Vector2.zero;
        valueRect.anchorMax = Vector2.one;
        valueRect.offsetMin = Vector2.zero;
        valueRect.offsetMax = Vector2.zero;

        Text valueText = valueObj.AddComponent<Text>();
        valueText.text = "HP 100/100";
        valueText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        valueText.fontSize = 14;
        valueText.color = Color.white;
        valueText.alignment = TextAnchor.MiddleRight;

        return panelObj.transform;
    }

    private Transform CreateGameOverText(Transform parent, out Text text)
    {
        GameObject textObj = new GameObject("GameOverText");
        textObj.transform.SetParent(parent);

        RectTransform rect = textObj.AddComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = Vector2.zero;
        rect.sizeDelta = new Vector2(600f, 120f);

        text = textObj.AddComponent<Text>();
        text.text = "GAME OVER";
        text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        text.fontSize = 48;
        text.color = new Color(1f, 0.2f, 0.2f, 1f);
        text.alignment = TextAnchor.MiddleCenter;

        return textObj.transform;
    }

    private MvpSwordSwing EnsureSword(GameObject player)
    {
        Transform model = FindModelRoot(player.transform);
        if (model == null)
        {
            return null;
        }

        Transform existingSword = FindExistingSword(model);
        if (existingSword != null)
        {
            MvpSwordSwing existingSwing = existingSword.GetComponent<MvpSwordSwing>();
            if (existingSwing == null)
            {
                existingSwing = existingSword.gameObject.AddComponent<MvpSwordSwing>();
            }
            return existingSwing;
        }

        if (swordModelPrefab == null && playerModelPrefab != null)
        {
            return null;
        }

        Transform pivot = model.Find("SwordPivot");
        if (pivot == null)
        {
            GameObject pivotObj = new GameObject("SwordPivot");
            pivotObj.transform.SetParent(model);
            pivotObj.transform.localPosition = new Vector3(0.35f, 1.1f, 0.4f);
            pivotObj.transform.localRotation = Quaternion.Euler(0f, -20f, 0f);
            pivot = pivotObj.transform;
        }

        Transform sword = pivot.Find("Sword");
        if (sword == null)
        {
            if (swordModelPrefab != null)
            {
                GameObject swordObj = Instantiate(swordModelPrefab, pivot);
                swordObj.name = "Sword";
                swordObj.transform.localPosition = Vector3.zero;
                swordObj.transform.localRotation = Quaternion.identity;
                swordObj.transform.localScale = Vector3.one;
                sword = swordObj.transform;
                RemoveChildColliders(swordObj.transform);
            }
            else
            {
                GameObject swordObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                swordObj.name = "Sword";
                swordObj.transform.SetParent(pivot);
                swordObj.transform.localPosition = new Vector3(0f, 0f, 0.45f);
                swordObj.transform.localRotation = Quaternion.identity;
                swordObj.transform.localScale = new Vector3(0.08f, 0.08f, 0.9f);
                sword = swordObj.transform;

                Renderer renderer = swordObj.GetComponent<Renderer>();
                if (renderer != null && swordMaterial != null)
                {
                    renderer.sharedMaterial = swordMaterial;
                }

                Collider collider = swordObj.GetComponent<Collider>();
                if (collider != null)
                {
                    Destroy(collider);
                }
            }
        }

        MvpSwordSwing swing = pivot.GetComponent<MvpSwordSwing>();
        if (swing == null)
        {
            swing = pivot.gameObject.AddComponent<MvpSwordSwing>();
        }

        return swing;
    }

    private static Transform FindExistingSword(Transform root)
    {
        Transform[] children = root.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in children)
        {
            string lowerName = child.name.ToLowerInvariant();
            if (lowerName.Contains("sword") || lowerName.Contains("weapon"))
            {
                return child;
            }
        }

        return null;
    }

    private static Transform FindModelRoot(Transform playerRoot)
    {
        Transform model = playerRoot.Find("Model");
        if (model != null)
        {
            return model;
        }

        return FindExistingVisualRoot(playerRoot);
    }

    private static Transform FindExistingVisualRoot(Transform root)
    {
        Renderer[] renderers = root.GetComponentsInChildren<Renderer>(true);
        Transform candidate = null;
        foreach (Renderer renderer in renderers)
        {
            if (renderer.transform == root)
            {
                continue;
            }

            candidate = renderer.transform;
            break;
        }

        if (candidate == null)
        {
            return null;
        }

        while (candidate.parent != null && candidate.parent != root)
        {
            candidate = candidate.parent;
        }

        return candidate;
    }

    private static void RemoveChildColliders(Transform root)
    {
        Collider[] colliders = root.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            Destroy(collider);
        }
    }

    private void FixErrorShaderMaterials()
    {
        if (fallbackMaterial == null)
        {
            return;
        }

        Renderer[] renderers = Object.FindObjectsByType<Renderer>(FindObjectsSortMode.None);
        foreach (Renderer renderer in renderers)
        {
            if (renderer == null)
            {
                continue;
            }

            Material[] materials = renderer.sharedMaterials;
            bool changed = false;

            for (int i = 0; i < materials.Length; i++)
            {
                Material material = materials[i];
                if (material == null)
                {
                    continue;
                }

                if (MvpMaterialUtility.NeedsUrpUpgrade(material))
                {
                    materials[i] = MvpMaterialUtility.GetOrCreateUrpLit(material, fallbackMaterial);
                    changed = true;
                }
            }

            if (changed)
            {
                renderer.sharedMaterials = materials;
            }
        }
    }
}
