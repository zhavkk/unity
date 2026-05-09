using UnityEngine;
using UnityEditor;

public class SceneSetup : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 playerStartPosition = new Vector3(0f, 1f, 0f);

    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int spawnPointCount = 4;
    [SerializeField] private float spawnRadius = 20f;

    [Header("Ground Settings")]
    [SerializeField] private Vector3 groundSize = new Vector3(50f, 1f, 50f);

    [Header("Lighting")]
    [SerializeField] private Light mainLight;
    [SerializeField] private Color ambientColor = new Color(0.5f, 0.5f, 0.5f);

    private void Start()
    {
        // This script can be used for runtime setup if needed
        // For now, it's primarily used as a template for editor setup
    }

    [ContextMenu("Setup Game Scene")]
    public void SetupGameScene()
    {
        #if UNITY_EDITOR
        SetupGround();
        SetupLighting();
        SetupSpawnPoints();
        SetupGameManager();

        Debug.Log("Game scene setup complete!");
        #endif
    }

    private void SetupGround()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.localScale = groundSize;
        ground.tag = "Ground";

        // Add layer
        ground.layer = LayerMask.NameToLayer("Default");
    }

    private void SetupLighting()
    {
        if (mainLight == null)
        {
            GameObject lightObj = new GameObject("Directional Light");
            mainLight = lightObj.AddComponent<Light>();
            mainLight.type = LightType.Directional;
            lightObj.transform.rotation = Quaternion.Euler(50f, -30f, 0f);
        }

        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = ambientColor;
    }

    private void SetupSpawnPoints()
    {
        GameObject spawnPointsParent = new GameObject("SpawnPoints");

        for (int i = 0; i < spawnPointCount; i++)
        {
            float angle = (360f / spawnPointCount) * i;
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius;
            float z = Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius;

            GameObject spawnPoint = new GameObject($"SpawnPoint_{i}");
            spawnPoint.transform.SetParent(spawnPointsParent.transform);
            spawnPoint.transform.position = new Vector3(x, 1f, z);
        }
    }

    private void SetupGameManager()
    {
        GameObject gameManagerObj = new GameObject("GameManager");
        gameManagerObj.AddComponent<GameManager>();
    }

    [ContextMenu("Create Player Prefab")]
    public void CreatePlayerPrefab()
    {
        #if UNITY_EDITOR
        if (playerPrefab == null)
        {
            playerPrefab = new GameObject("Player");
            playerPrefab.tag = "Player";
        }

        // Add required components
        CharacterController controller = playerPrefab.GetComponent<CharacterController>();
        if (controller == null)
        {
            controller = playerPrefab.AddComponent<CharacterController>();
            controller.center = new Vector3(0, 1, 0);
            controller.height = 2f;
        }

        EnhancedPlayerController playerController = playerPrefab.GetComponent<EnhancedPlayerController>();
        if (playerController == null)
        {
            playerController = playerPrefab.AddComponent<EnhancedPlayerController>();
        }

        RageSystem rageSystem = playerPrefab.GetComponent<RageSystem>();
        if (rageSystem == null)
        {
            rageSystem = playerPrefab.AddComponent<RageSystem>();
        }

        // PlayerAttract instead of EnemyAttractionSystem
        PlayerAttract attractionSystem = playerPrefab.GetComponent<PlayerAttract>();
        if (attractionSystem == null)
        {
            attractionSystem = playerPrefab.AddComponent<PlayerAttract>();
        }

        // Add visual placeholder
        GameObject visual = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        visual.name = "PlayerModel";
        visual.transform.SetParent(playerPrefab.transform);
        visual.transform.localPosition = Vector3.zero;

        // Setup attack point
        GameObject attackPointObj = new GameObject("AttackPoint");
        attackPointObj.transform.SetParent(playerPrefab.transform);
        attackPointObj.transform.localPosition = new Vector3(0, 1, 1);

        // Get reference to attack point
        SerializedObject serializedPlayer = new SerializedObject(playerController);
        SerializedProperty attackPointProp = serializedPlayer.FindProperty("attackPoint");
        attackPointProp.objectReferenceValue = attackPointObj.transform;
        serializedPlayer.ApplyModifiedProperties();

        Debug.Log("Player prefab created!");
        #endif
    }

    [ContextMenu("Create Enemy Prefab")]
    public void CreateEnemyPrefab()
    {
        #if UNITY_EDITOR
        if (enemyPrefab == null)
        {
            enemyPrefab = new GameObject("Enemy");
            enemyPrefab.tag = "Enemy";
        }

        // Add required components
        EnemyController enemyController = enemyPrefab.GetComponent<EnemyController>();
        if (enemyController == null)
        {
            enemyController = enemyPrefab.AddComponent<EnemyController>();
        }

        Rigidbody rb = enemyPrefab.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = enemyPrefab.AddComponent<Rigidbody>();
            rb.isKinematic = true;
        }

        CapsuleCollider collider = enemyPrefab.GetComponent<CapsuleCollider>();
        if (collider == null)
        {
            collider = enemyPrefab.AddComponent<CapsuleCollider>();
            collider.center = new Vector3(0, 1, 0);
            collider.height = 2f;
        }

        // Add visual placeholder
        GameObject visual = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        visual.name = "EnemyModel";
        visual.transform.SetParent(enemyPrefab.transform);
        visual.transform.localPosition = Vector3.zero;
        visual.GetComponent<Renderer>().material.color = Color.red;

        Debug.Log("Enemy prefab created!");
        #endif
    }
}
