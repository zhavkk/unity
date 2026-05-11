using UnityEngine;
using UnityEngine.UI;

/// <summary>
    /// Simple rage system that provides damage and speed bonuses when rage is high enough.
    /// Rage builds up from actions (e.g., killing enemies) and decays over time when idle.
    /// </summary>
    public class SimpleRageSystem : MonoBehaviour
    {
        [Header("Rage Settings")]
        [Tooltip("Current rage value (0-100)")]
        [Range(0f, 100f)]
        public float currentRage = 0f;

        [Tooltip("Maximum rage value")]
        public float maxRage = 100f;

        [Tooltip("Rate at which rage decays per second when not being added to")]
        public float rageDecayRate = 5f;

        [Tooltip("Rage threshold for activating bonuses")]
        public float rageThreshold = 50f;

        [Tooltip("Damage multiplier when rage is active (>= threshold)")]
        public float rageDamageMultiplier = 1.5f;

        [Tooltip("Speed multiplier when rage is active (>= threshold)")]
        public float rageSpeedMultiplier = 1.3f;

        [Header("Visual Settings")]
        [Tooltip("Optional: Renderer to change color when rage is active")]
        public Renderer playerRenderer;

        [Tooltip("Color to apply when rage is active")]
        public Color rageColor = Color.red;

        [Tooltip("Original color to restore when rage is not active")]
        public Color normalColor = Color.white;

        [Header("UI Settings")]
        [Tooltip("Optional: UI Text to display rage value")]
        public Text rageText;

        [Tooltip("Show debug logs for rage events")]
        public bool showDebugLogs = true;

        private bool isRageActive = false;
        private bool hasRenderer = false;
        private float timeSinceLastRageAdd = 0f;
        private const float RAGE_DECAY_DELAY = 0.5f; // Small delay before rage starts decaying

        private void Awake()
        {
            // Check if we have a renderer to modify
            if (playerRenderer != null)
            {
                hasRenderer = true;
                normalColor = playerRenderer.material.color;
            }
        }

        private void Start()
        {
            UpdateUI();
        }

        private void Update()
        {
            // Track time since last rage addition
            timeSinceLastRageAdd += Time.deltaTime;

            // Decay rage after a small delay
            if (timeSinceLastRageAdd > RAGE_DECAY_DELAY && currentRage > 0f)
            {
                currentRage -= rageDecayRate * Time.deltaTime;
                currentRage = Mathf.Clamp(currentRage, 0f, maxRage);
                UpdateUI();
            }

            // Check if rage state changed
            CheckRageState();
        }

        /// <summary>
        /// Add rage to the current value.
        /// </summary>
        /// <param name="amount">Amount of rage to add (will be clamped to max)</param>
        public void AddRage(float amount)
        {
            currentRage += amount;
            currentRage = Mathf.Clamp(currentRage, 0f, maxRage);
            timeSinceLastRageAdd = 0f; // Reset decay timer

            if (showDebugLogs)
            {
                Debug.Log($"[RageSystem] Added {amount} rage. Current: {currentRage:F1}/{maxRage}");
            }

            UpdateUI();
            CheckRageState();
        }

        /// <summary>
        /// Get the current damage multiplier based on rage level.
        /// </summary>
        /// <returns>1.5x when rage >= 50, else 1x</returns>
        public float GetDamageMultiplier()
        {
            return isRageActive ? rageDamageMultiplier : 1f;
        }

        /// <summary>
        /// Get the current speed multiplier based on rage level.
        /// </summary>
        /// <returns>1.3x when rage >= 50, else 1x</returns>
        public float GetSpeedMultiplier()
        {
            return isRageActive ? rageSpeedMultiplier : 1f;
        }

        /// <summary>
        /// Get the current rage percentage (0-1).
        /// </summary>
        public float GetRagePercentage()
        {
            return currentRage / maxRage;
        }

        /// <summary>
        /// Check and update rage active state.
        /// </summary>
        private void CheckRageState()
        {
            bool wasActive = isRageActive;
            isRageActive = currentRage >= rageThreshold;

            // Only log and update visuals when state changes
            if (wasActive != isRageActive)
            {
                if (showDebugLogs)
                {
                    Debug.Log($"[RageSystem] Rage {(isRageActive ? "ACTIVATED" : "DEACTIVATED")} at {currentRage:F1}");
                }

                UpdateVisuals();
            }
        }

        /// <summary>
        /// Update visual effects based on rage state.
        /// </summary>
        private void UpdateVisuals()
        {
            if (hasRenderer && playerRenderer != null)
            {
                if (isRageActive)
                {
                    playerRenderer.material.color = rageColor;
                }
                else
                {
                    playerRenderer.material.color = normalColor;
                }
            }
        }

        /// <summary>
        /// Update UI text if available.
        /// </summary>
        private void UpdateUI()
        {
            if (rageText != null)
            {
                rageText.text = $"RAGE: {currentRage:F0}/{maxRage:F0}";
            }
        }

        /// <summary>
        /// Reset rage to zero (e.g., on death or level change).
        /// </summary>
        public void ResetRage()
        {
            currentRage = 0f;
            timeSinceLastRageAdd = 0f;
            UpdateUI();
            CheckRageState();

            if (showDebugLogs)
            {
                Debug.Log("[RageSystem] Rage reset to 0");
            }
        }

        /// <summary>
        /// For debugging in editor: visualize rage state.
        /// </summary>
        private void OnDrawGizmos()
        {
            if (isRageActive)
            {
                Gizmos.color = rageColor;
                Gizmos.DrawWireSphere(transform.position, 1f);
            }
        }
    }
