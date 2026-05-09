using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    [Header("Wave Settings")]
    public int startingEnemies = 3;
    public int enemiesPerWaveIncrease = 2;
    public float waveDelay = 5f;

    [Header("Spawning")]
    public float minSpawnDistance = 10f;
    public float maxSpawnDistance = 20f;
    public GameObject enemyPrefab;

    [Header("UI References")]
    public Text waveCounterText;
    public Text enemiesRemainingText;

    private int currentWave = 1;
    private int enemiesInWave;
    private int enemiesRemaining;
    private List<GameObject> activeEnemies = new List<GameObject>();
    private bool isWaveActive = false;
    private bool gameOver = false;

    private Transform playerTransform;

    void Start()
    {
        // Find player (may not exist yet if setup is in progress)
        TryFindPlayer();

        // Don't start waves immediately - wait for player to be ready
        // The waves will be started manually when everything is set up
    }

    private bool TryFindPlayer()
    {
        if (playerTransform != null)
        {
            return true; // Already have player
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            Debug.Log("WaveManager: Player found successfully");
            return true;
        }
        else
        {
            // Player might not be created yet - that's okay
            // CompleteGameSetup will set playerTransform via reflection
            return false;
        }
    }

    // Public method to start waves when everything is ready
    public void StartWaves()
    {
        if (playerTransform == null)
        {
            TryFindPlayer();
        }

        if (playerTransform != null)
        {
            StartCoroutine(StartNextWave());
        }
        else
        {
            Debug.LogError("WaveManager: Cannot start waves - player not found!");
        }
    }

    void Update()
    {
        if (gameOver) return;

        // Check if wave is complete
        if (isWaveActive && activeEnemies.Count == 0)
        {
            isWaveActive = false;
            StartCoroutine(StartNextWave());
        }

        // Check for dead enemies and remove them
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            if (activeEnemies[i] == null)
            {
                activeEnemies.RemoveAt(i);
                enemiesRemaining--;
                UpdateUI();
            }
        }

        // Check game over condition
        if (playerTransform != null)
        {
            PlayerHealth playerHealth = playerTransform.GetComponent<PlayerHealth>();
            if (playerHealth != null && playerHealth.GetCurrentHealth() <= 0)
            {
                GameOver();
            }
        }
    }

    IEnumerator StartNextWave()
    {
        if (gameOver) yield break;

        // Calculate enemies for this wave
        enemiesInWave = startingEnemies + (currentWave - 1) * enemiesPerWaveIncrease;
        enemiesRemaining = enemiesInWave;

        Debug.Log($"Wave {currentWave} starting with {enemiesInWave} enemies");

        // Wait for wave delay
        yield return new WaitForSeconds(waveDelay);

        // Spawn enemies
        SpawnWave();

        isWaveActive = true;
        UpdateUI();
    }

    void SpawnWave()
    {
        for (int i = 0; i < enemiesInWave; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();

            // Determine enemy type based on wave and random
            EnemyFactory.EnemyType enemyType = DetermineEnemyType(i);

            GameObject enemy = EnemyFactory.CreateEnemy(enemyType, spawnPosition);

            if (enemy == null)
            {
                Debug.LogWarning("WaveManager: Failed to spawn enemy!");
                continue;
            }

            enemy.name = $"Enemy_{currentWave}_{i + 1}";
            activeEnemies.Add(enemy);

            Debug.Log($"WaveManager: Spawned {enemyType} enemy at wave {currentWave}");
        }
    }

    private EnemyFactory.EnemyType DetermineEnemyType(int enemyIndex)
    {
        // Start with normal enemies, add variety as waves progress
        if (currentWave < 3)
        {
            return EnemyFactory.EnemyType.Normal;
        }
        else if (currentWave < 5)
        {
            // Mix of normal and fast
            return Random.value > 0.7f ? EnemyFactory.EnemyType.Fast : EnemyFactory.EnemyType.Normal;
        }
        else if (currentWave < 8)
        {
            // All three types
            float rand = Random.value;
            if (rand < 0.5f) return EnemyFactory.EnemyType.Normal;
            if (rand < 0.8f) return EnemyFactory.EnemyType.Fast;
            return EnemyFactory.EnemyType.Tank;
        }
        else
        {
            // All types including ranged
            float rand = Random.value;
            if (rand < 0.3f) return EnemyFactory.EnemyType.Normal;
            if (rand < 0.5f) return EnemyFactory.EnemyType.Fast;
            if (rand < 0.8f) return EnemyFactory.EnemyType.Tank;
            return EnemyFactory.EnemyType.Ranged;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        if (playerTransform == null)
        {
            return Vector3.zero;
        }

        // Get random angle
        float angle = Random.Range(0f, 360f);
        float radians = angle * Mathf.Deg2Rad;

        // Get random distance within range
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);

        // Calculate position
        float x = playerTransform.position.x + Mathf.Cos(radians) * distance;
        float z = playerTransform.position.z + Mathf.Sin(radians) * distance;

        return new Vector3(x, 0f, z);
    }

    void UpdateUI()
    {
        if (waveCounterText != null)
        {
            waveCounterText.text = $"Wave: {currentWave}";
        }

        if (enemiesRemainingText != null)
        {
            enemiesRemainingText.text = $"Enemies: {enemiesRemaining}";
        }
    }

    void GameOver()
    {
        if (gameOver) return;

        gameOver = true;
        isWaveActive = false;

        Debug.Log($"Game Over! You survived {currentWave - 1} waves.");

        if (waveCounterText != null)
        {
            waveCounterText.text = "GAME OVER";
        }

        if (enemiesRemainingText != null)
        {
            enemiesRemainingText.text = $"Waves Survived: {currentWave - 1}";
        }
    }

    GameObject CreateSimpleEnemyPrefab()
    {
        GameObject enemy = new GameObject("SimpleEnemy");

        // Add capsule collider
        CapsuleCollider collider = enemy.AddComponent<CapsuleCollider>();
        collider.height = 3.5f; // Увеличено для больших моделей
        collider.radius = 0.8f; // Увеличено для больших моделей
        collider.center = new Vector3(0f, 1.75f, 0f); // Увеличено для больших моделей

        // Add Rigidbody
        Rigidbody rb = enemy.AddComponent<Rigidbody>();
        rb.mass = 1f;
        rb.linearDamping = 0f;
        rb.angularDamping = 0.05f;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // Add EnemyHealth component
        EnemyHealth enemyHealth = enemy.AddComponent<EnemyHealth>();
        enemyHealth.maxHealth = 30; // Set enemy max health
        // currentHealth will be set in Start() automatically

        // Add simple enemy movement (create this if needed)
        SimpleEnemyAI enemyAI = enemy.AddComponent<SimpleEnemyAI>();

        // Add visual component (red capsule) - УВЕЛИЧЕНО
        // Note: This creates a visual representation, but you should create a proper prefab in Unity Editor
        GameObject visual = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        visual.transform.SetParent(enemy.transform);
        visual.transform.localPosition = new Vector3(0f, 1.75f, 0f); // Увеличено для больших моделей
        visual.transform.localScale = new Vector3(2f, 2f, 2f); // Увеличено в 2 раза

        // Set visual color to red (requires Material)
        Renderer renderer = visual.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material mat = new Material(Shader.Find("Standard"));
            mat.color = Color.red;
            renderer.material = mat;
        }

        // Remove collider from visual since parent has one
        Destroy(visual.GetComponent<Collider>());

        return enemy;
    }

    // Public method to get current wave info
    public int GetCurrentWave() => currentWave;

    public int GetEnemiesRemaining() => enemiesRemaining;

    public bool IsGameOver() => gameOver;

    // Public method to stop the game (for GameIntegrator)
    public void StopGame()
    {
        gameOver = true;
        isWaveActive = false;
        Debug.Log("WaveManager: Game stopped by GameIntegrator");

        // Stop all enemy AI
        foreach (GameObject enemy in activeEnemies)
        {
            if (enemy != null)
            {
                SimpleEnemyAI enemyAI = enemy.GetComponent<SimpleEnemyAI>();
                if (enemyAI != null)
                {
                    enemyAI.enabled = false;
                }
            }
        }

        if (waveCounterText != null)
        {
            waveCounterText.text = "GAME OVER";
        }

        if (enemiesRemainingText != null)
        {
            enemiesRemainingText.text = $"Waves Survived: {currentWave - 1}";
        }
    }
}

// Simple enemy AI component (basic follow player behavior)
public class SimpleEnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 1.5f;
    public int damage = 10;
    public float attackCooldown = 1f;

    private Transform playerTransform;
    private float lastAttackTime;

    void Start()
    {
        // Only search for player if transform wasn't set during creation
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // Move towards player
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0f; // Keep on ground plane
        direction.Normalize();

        transform.position += direction * moveSpeed * Time.deltaTime;

        // Look at player
        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));

        // Attack if in range
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        lastAttackTime = Time.time;

        PlayerHealth playerHealth = playerTransform.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}

// Simple Health component
public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetMaxHealth(int value)
    {
        maxHealth = value;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
