using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
    /// Simple wave manager that handles wave progression, enemy spawning, and difficulty scaling.
    /// Integrates with SimpleEnemySpawner, SimpleRageSystem, and SimplePlayerController.
    /// </summary>
    public class SimpleWaveManager : MonoBehaviour
    {
        [Header("Wave Settings")]
        [Tooltip("Current wave number (starts at 1)")]
        public int currentWave = 1;

        [Tooltip("Base number of enemies per wave (wave number × enemiesPerWaveMultiplier)")]
        public int enemiesPerWaveMultiplier = 5;

        [Tooltip("Delay in seconds before starting the first wave")]
        public float startDelay = 3f;

        [Tooltip("Delay in seconds between waves")]
        public float waveTransitionDelay = 5f;

        [Header("Difficulty Scaling")]
        [Tooltip("Enemy health multiplier per wave (e.g., 1.1 = 10% increase each wave)")]
        public float healthScaleMultiplier = 1.1f;

        [Tooltip("Enemy damage multiplier per wave (e.g., 1.05 = 5% increase each wave)")]
        public float damageScaleMultiplier = 1.05f;

        [Header("Spawn Settings")]
        [Tooltip("Radius around player to spawn enemies")]
        public float spawnRadius = 20f;

        [Tooltip("Minimum distance from player to spawn enemies")]
        public float minDistanceFromPlayer = 5f;

        [Header("Rage System Integration")]
        [Tooltip("Reference to SimpleRageSystem to add rage on wave complete")]
        public SimpleRageSystem rageSystem;

        [Tooltip("Amount of rage to add when wave is completed")]
        public float rageOnWaveComplete = 25f;

        [Header("UI Settings")]
        [Tooltip("UI Text to display current wave")]
        public Text waveText;

        [Tooltip("UI Text to show wave transition messages")]
        public Text waveMessageText;

        [Tooltip("Duration in seconds to show wave transition messages")]
        public float messageDisplayDuration = 3f;

        [Header("Enemy Prefab")]
        [Tooltip("Optional: Prefab to use for spawning enemies. If null, creates enemy dynamically.")]
        public GameObject enemyPrefab;

        [Header("Debug Settings")]
        [Tooltip("Show debug logs for wave events")]
        public bool showDebugLogs = true;

        // Private state
        private List<GameObject> activeEnemies = new List<GameObject>();
        private bool isWaveActive = false;
        private bool isTransitioning = false;
        private float waveTimer = 0f;
        private float messageTimer = 0f;
        private SimplePlayerController player;

        void Start()
        {
            // Find player reference
            player = FindAnyObjectByType<SimplePlayerController>();
            if (player == null && showDebugLogs)
            {
                Debug.LogWarning("[WaveManager] No SimplePlayerController found in scene.");
            }

            // Start first wave after delay
            Invoke(nameof(StartFirstWave), startDelay);

            // Update UI
            UpdateWaveUI();

            if (showDebugLogs)
            {
                Debug.Log("[WaveManager] Wave Manager initialized. First wave starting in " + startDelay + " seconds.");
            }
        }

        void Update()
        {
            // Handle wave completion check
            if (isWaveActive && !isTransitioning)
            {
                CheckWaveCompletion();
            }

            // Handle message timer
            if (messageTimer > 0f)
            {
                messageTimer -= Time.deltaTime;
                if (messageTimer <= 0f && waveMessageText != null)
                {
                    waveMessageText.text = "";
                }
            }

            // Cleanup dead enemies periodically
            if (Time.frameCount % 30 == 0) // Check every 30 frames
            {
                CleanupDeadEnemies();
            }
        }

        /// <summary>
        /// Start the first wave.
        /// </summary>
        void StartFirstWave()
        {
            StartWave();
        }

        /// <summary>
        /// Start a new wave with scaled difficulty.
        /// </summary>
        public void StartWave()
        {
            if (isTransitioning)
            {
                Debug.LogWarning("[WaveManager] Cannot start wave while transitioning.");
                return;
            }

            isWaveActive = true;
            isTransitioning = false;

            // Calculate enemies for this wave: wave number × multiplier
            int enemiesToSpawn = currentWave * enemiesPerWaveMultiplier;

            // Show wave start message
            ShowWaveMessage($"Wave {currentWave} Starting!");

            if (showDebugLogs)
            {
                Debug.Log($"[WaveManager] Starting Wave {currentWave}. Spawning {enemiesToSpawn} enemies.");
            }

            // Spawn enemies with scaled stats
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
            }

            // Update UI
            UpdateWaveUI();
        }

        /// <summary>
        /// Spawn a single enemy with wave-scaled stats.
        /// </summary>
        void SpawnEnemy()
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject enemy;

            if (enemyPrefab != null)
            {
                // Use prefab
                enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                // Create enemy dynamically
                enemy = new GameObject("Enemy");
                enemy.transform.position = spawnPosition;
                enemy.tag = "Enemy";

                // Add SimpleEnemy component
                SimpleEnemy enemyScript = enemy.AddComponent<SimpleEnemy>();

                // Add collider
                BoxCollider collider = enemy.AddComponent<BoxCollider>();
                collider.size = new Vector3(1f, 2f, 1f);
                collider.center = new Vector3(0, 1f, 0);
            }

            // Scale enemy stats based on current wave
            ScaleEnemyStats(enemy);

            activeEnemies.Add(enemy);

            if (showDebugLogs)
            {
                Debug.Log($"[WaveManager] Spawned enemy at: {spawnPosition}");
            }
        }

        /// <summary>
        /// Scale enemy health and damage based on current wave.
        /// </summary>
        void ScaleEnemyStats(GameObject enemy)
        {
            SimpleEnemy enemyScript = enemy.GetComponent<SimpleEnemy>();
            if (enemyScript == null)
            {
                return;
            }

            // Calculate multipliers based on wave number
            // Wave 1: 1.0x, Wave 2: 1.1x, Wave 3: 1.21x, etc.
            float healthMultiplier = Mathf.Pow(healthScaleMultiplier, currentWave - 1);
            float damageMultiplier = Mathf.Pow(damageScaleMultiplier, currentWave - 1);

            // Apply scaled stats
            enemyScript.maxHealth *= healthMultiplier;

            // Reset current health to match new max health
            // We need to do this after maxHealth is set
            // Use reflection or wait for Awake to run first
            StartCoroutine(ResetEnemyHealthAfterAwake(enemyScript, healthMultiplier));

            // Scale damage
            enemyScript.damage *= damageMultiplier;

            if (showDebugLogs)
            {
                Debug.Log($"[WaveManager] Scaled enemy stats - Health: {enemyScript.maxHealth:F1}x{healthMultiplier:F2}, Damage: {enemyScript.damage:F1}x{damageMultiplier:F2}");
            }
        }

        System.Collections.IEnumerator ResetEnemyHealthAfterAwake(SimpleEnemy enemyScript, float healthMultiplier)
        {
            yield return new WaitForEndOfFrame(); // Wait for Awake to complete
            // Enemy's Awake sets currentHealth to maxHealth, so we're good
        }

        /// <summary>
        /// Get a random spawn position around the player.
        /// </summary>
        Vector3 GetRandomSpawnPosition()
        {
            Vector3 playerPosition = Vector3.zero;

            // Try to find player if null
            if (player == null)
            {
                player = FindAnyObjectByType<SimplePlayerController>();
            }

            if (player != null)
            {
                playerPosition = player.transform.position;
            }
            else
            {
                // Fallback to origin if no player found
                Debug.LogWarning("SimpleWaveManager: No player found, spawning at origin");
            }

            Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
            randomDirection.y = 0;

            Vector3 spawnPosition = playerPosition + randomDirection;

            // Ensure minimum distance from player
            float distance = Vector3.Distance(spawnPosition, playerPosition);
            if (distance < minDistanceFromPlayer)
            {
                spawnPosition = (spawnPosition - playerPosition).normalized * minDistanceFromPlayer + playerPosition;
            }

            return spawnPosition;
        }

        /// <summary>
        /// Check if all enemies in the current wave have been defeated.
        /// </summary>
        void CheckWaveCompletion()
        {
            CleanupDeadEnemies();

            if (activeEnemies.Count == 0)
            {
                CompleteWave();
            }
        }

        /// <summary>
        /// Handle wave completion.
        /// </summary>
        void CompleteWave()
        {
            isWaveActive = false;
            isTransitioning = true;

            if (showDebugLogs)
            {
                Debug.Log($"[WaveManager] Wave {currentWave} completed!");
            }

            // Show completion message
            ShowWaveMessage($"Wave {currentWave} Complete!");

            // Add rage if rage system is available
            if (rageSystem != null)
            {
                rageSystem.AddRage(rageOnWaveComplete);
                if (showDebugLogs)
                {
                    Debug.Log($"[WaveManager] Added {rageOnWaveComplete} rage to player.");
                }
            }

            // Increment wave number
            currentWave++;

            // Update UI
            UpdateWaveUI();

            // Schedule next wave
            Invoke(nameof(StartNextWave), waveTransitionDelay);
        }

        /// <summary>
        /// Start the next wave after transition delay.
        /// </summary>
        void StartNextWave()
        {
            isTransitioning = false;
            StartWave();
        }

        /// <summary>
        /// Clean up destroyed enemies from the active list.
        /// </summary>
        void CleanupDeadEnemies()
        {
            for (int i = activeEnemies.Count - 1; i >= 0; i--)
            {
                if (activeEnemies[i] == null)
                {
                    activeEnemies.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Update the wave UI text.
        /// </summary>
        void UpdateWaveUI()
        {
            if (waveText != null)
            {
                waveText.text = $"Wave: {currentWave}";
            }
        }

        /// <summary>
        /// Show a temporary message on the wave message UI.
        /// </summary>
        void ShowWaveMessage(string message)
        {
            if (waveMessageText != null)
            {
                waveMessageText.text = message;
                messageTimer = messageDisplayDuration;
            }
            else if (showDebugLogs)
            {
                Debug.Log($"[WaveManager] {message}");
            }
        }

        /// <summary>
        /// Get the current wave number.
        /// </summary>
        public int GetCurrentWave()
        {
            return currentWave;
        }

        /// <summary>
        /// Get the number of active enemies.
        /// </summary>
        public int GetActiveEnemyCount()
        {
            CleanupDeadEnemies();
            return activeEnemies.Count;
        }

        /// <summary>
        /// Check if a wave is currently active.
        /// </summary>
        public bool IsWaveActive()
        {
            return isWaveActive;
        }

        /// <summary>
        /// Reset the wave manager to initial state.
        /// </summary>
        public void ResetWaves()
        {
            // Cancel any pending invokes
            CancelInvoke();

            // Destroy all active enemies
            foreach (GameObject enemy in activeEnemies)
            {
                if (enemy != null)
                {
                    Destroy(enemy);
                }
            }
            activeEnemies.Clear();

            // Reset state
            currentWave = 1;
            isWaveActive = false;
            isTransitioning = false;
            messageTimer = 0f;

            // Update UI
            UpdateWaveUI();

            // Reset rage if available
            if (rageSystem != null)
            {
                rageSystem.ResetRage();
            }

            if (showDebugLogs)
            {
                Debug.Log("[WaveManager] Wave manager reset.");
            }

            // Start first wave after delay
            Invoke(nameof(StartFirstWave), startDelay);
        }

        /// <summary>
        /// For debugging: draw spawn radius in editor.
        /// </summary>
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Vector3 center = transform.position;

            if (player != null)
            {
                center = player.transform.position;
            }
            else
            {
                SimplePlayerController playerRef = FindAnyObjectByType<SimplePlayerController>();
                if (playerRef != null)
                {
                    center = playerRef.transform.position;
                }
            }

            Gizmos.DrawWireSphere(center, spawnRadius);

            // Draw minimum distance from player
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(center, minDistanceFromPlayer);
        }
    }
