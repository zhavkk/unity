using UnityEngine;
using System;

/// <summary>
/// Система улучшений между волнами. Позволяет игроку выбирать апгрейды.
/// </summary>
public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem Instance { get; private set; }

    [Header("Upgrade Settings")]
    [SerializeField] private int upgradePointsPerWave = 1;
    [SerializeField] private int maxUpgradeLevel = 5;

    [Header("Upgrade Values")]
    [SerializeField] private float damageIncrease = 0.2f;       // +20% damage per level
    [SerializeField] private float speedIncrease = 0.15f;       // +15% speed per level
    [SerializeField] private float healthIncrease = 0.25f;      // +25% health per level
    [SerializeField] private float rageIncrease = 0.3f;         // +30% rage efficiency per level

    // Current upgrade levels
    private int damageLevel = 0;
    private int speedLevel = 0;
    private int healthLevel = 0;
    private int rageLevel = 0;

    private int currentUpgradePoints = 0;

    // Events
    public event Action<int> OnUpgradePointsChanged;
    public event Action OnUpgradesChanged;

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
        // Subscribe to wave manager events
        WaveManager waveManager = FindAnyObjectByType<WaveManager>();
        if (waveManager != null)
        {
            // Note: We'll need to add wave complete event to WaveManager
        }
    }

    /// <summary>
    /// Вызывается при завершении волны для добавления очков улучшений
    /// </summary>
    public void OnWaveComplete(int waveNumber)
    {
        currentUpgradePoints += upgradePointsPerWave;
        OnUpgradePointsChanged?.Invoke(currentUpgradePoints);

        Debug.Log($"Wave {waveNumber} complete! +{upgradePointsPerWave} upgrade points. Total: {currentUpgradePoints}");

        // Show upgrade menu
        if (GameMenuManager.Instance != null)
        {
            GameMenuManager.Instance.ShowUpgradeMenu();
        }

        // Setup upgrade buttons
        SetupUpgradeButtons();
    }

    private void SetupUpgradeButtons()
    {
        if (GameMenuManager.Instance == null) return;

        // Get upgrade buttons from menu
        // This requires access to the menu's buttons, which we'll need to expose
        Debug.Log("SetupUpgradeButtons: Configure upgrade choices here");
    }

    #region Upgrade Methods

    public bool UpgradeDamage()
    {
        if (currentUpgradePoints <= 0 || damageLevel >= maxUpgradeLevel) return false;

        damageLevel++;
        currentUpgradePoints--;

        ApplyDamageUpgrade();
        OnUpgradePointsChanged?.Invoke(currentUpgradePoints);
        OnUpgradesChanged?.Invoke();

        Debug.Log($"Damage upgraded to level {damageLevel}");
        return true;
    }

    public bool UpgradeSpeed()
    {
        if (currentUpgradePoints <= 0 || speedLevel >= maxUpgradeLevel) return false;

        speedLevel++;
        currentUpgradePoints--;

        ApplySpeedUpgrade();
        OnUpgradePointsChanged?.Invoke(currentUpgradePoints);
        OnUpgradesChanged?.Invoke();

        Debug.Log($"Speed upgraded to level {speedLevel}");
        return true;
    }

    public bool UpgradeHealth()
    {
        if (currentUpgradePoints <= 0 || healthLevel >= maxUpgradeLevel) return false;

        healthLevel++;
        currentUpgradePoints--;

        ApplyHealthUpgrade();
        OnUpgradePointsChanged?.Invoke(currentUpgradePoints);
        OnUpgradesChanged?.Invoke();

        Debug.Log($"Health upgraded to level {healthLevel}");
        return true;
    }

    public bool UpgradeRage()
    {
        if (currentUpgradePoints <= 0 || rageLevel >= maxUpgradeLevel) return false;

        rageLevel++;
        currentUpgradePoints--;

        ApplyRageUpgrade();
        OnUpgradePointsChanged?.Invoke(currentUpgradePoints);
        OnUpgradesChanged?.Invoke();

        Debug.Log($"Rage upgraded to level {rageLevel}");
        return true;
    }

    #endregion

    #region Apply Upgrades

    private void ApplyDamageUpgrade()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        EnhancedPlayerController playerController = player.GetComponent<EnhancedPlayerController>();
        if (playerController != null)
        {
            // Use reflection to modify base damage
            var controllerType = typeof(EnhancedPlayerController);
            var baseDamageField = controllerType.GetField("baseDamage",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (baseDamageField != null)
            {
                float currentDamage = (float)baseDamageField.GetValue(playerController);
                float newDamage = currentDamage * (1f + damageIncrease);
                baseDamageField.SetValue(playerController, newDamage);

                Debug.Log($"[UpgradeSystem] Damage increased from {currentDamage} to {newDamage}");
            }
        }
    }

    private void ApplySpeedUpgrade()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        EnhancedPlayerController playerController = player.GetComponent<EnhancedPlayerController>();
        if (playerController != null)
        {
            // Use reflection to modify speed
            var controllerType = typeof(EnhancedPlayerController);
            var walkSpeedField = controllerType.GetField("walkSpeed",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var sprintSpeedField = controllerType.GetField("sprintSpeed",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (walkSpeedField != null && sprintSpeedField != null)
            {
                float currentWalkSpeed = (float)walkSpeedField.GetValue(playerController);
                float currentSprintSpeed = (float)sprintSpeedField.GetValue(playerController);

                float newWalkSpeed = currentWalkSpeed * (1f + speedIncrease);
                float newSprintSpeed = currentSprintSpeed * (1f + speedIncrease);

                walkSpeedField.SetValue(playerController, newWalkSpeed);
                sprintSpeedField.SetValue(playerController, newSprintSpeed);

                Debug.Log($"[UpgradeSystem] Speed increased from {currentWalkSpeed} to {newWalkSpeed}");
            }
        }
    }

    private void ApplyHealthUpgrade()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        EnhancedPlayerController playerController = player.GetComponent<EnhancedPlayerController>();
        if (playerController != null)
        {
            // Use reflection to modify max health
            var controllerType = typeof(EnhancedPlayerController);
            var maxHealthField = controllerType.GetField("maxHealth",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            if (maxHealthField != null)
            {
                float currentMaxHealth = (float)maxHealthField.GetValue(playerController);
                float newMaxHealth = currentMaxHealth * (1f + healthIncrease);
                maxHealthField.SetValue(playerController, newMaxHealth);

                // Also heal player
                playerController.Heal(newMaxHealth - currentMaxHealth);

                Debug.Log($"[UpgradeSystem] Max health increased from {currentMaxHealth} to {newMaxHealth}");
            }
        }
    }

    private void ApplyRageUpgrade()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        RageSystem rageSystem = player.GetComponent<RageSystem>();
        if (rageSystem != null)
        {
            // Increase rage bonuses
            var systemType = typeof(RageSystem);
            var maxDamageMultField = systemType.GetField("maxDamageMultiplier",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var maxSpeedMultField = systemType.GetField("maxAttackSpeedMultiplier",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            if (maxDamageMultField != null && maxSpeedMultField != null)
            {
                float currentDamageMult = (float)maxDamageMultField.GetValue(rageSystem);
                float currentSpeedMult = (float)maxSpeedMultField.GetValue(rageSystem);

                float newDamageMult = currentDamageMult * (1f + rageIncrease);
                float newSpeedMult = currentSpeedMult * (1f + rageIncrease);

                maxDamageMultField.SetValue(rageSystem, newDamageMult);
                maxSpeedMultField.SetValue(rageSystem, newSpeedMult);

                Debug.Log($"[UpgradeSystem] Rage multipliers increased to x{newDamageMult} damage, x{newSpeedMult} speed");
            }
        }
    }

    #endregion

    #region Getters

    public int GetUpgradePoints()
    {
        return currentUpgradePoints;
    }

    public int GetDamageLevel()
    {
        return damageLevel;
    }

    public int GetSpeedLevel()
    {
        return speedLevel;
    }

    public int GetHealthLevel()
    {
        return healthLevel;
    }

    public int GetRageLevel()
    {
        return rageLevel;
    }

    public float GetDamageMultiplier()
    {
        return 1f + (damageLevel * damageIncrease);
    }

    public float GetSpeedMultiplier()
    {
        return 1f + (speedLevel * speedIncrease);
    }

    public float GetHealthMultiplier()
    {
        return 1f + (healthLevel * healthIncrease);
    }

    public float GetRageMultiplier()
    {
        return 1f + (rageLevel * rageIncrease);
    }

    #endregion

    // For debugging
    void OnGUI()
    {
        GUI.Label(new Rect(10, 150, 200, 20), $"Upgrade Points: {currentUpgradePoints}");
        GUI.Label(new Rect(10, 170, 200, 20), $"Damage Lvl: {damageLevel}");
        GUI.Label(new Rect(10, 190, 200, 20), $"Speed Lvl: {speedLevel}");
        GUI.Label(new Rect(10, 210, 200, 20), $"Health Lvl: {healthLevel}");
        GUI.Label(new Rect(10, 230, 200, 20), $"Rage Lvl: {rageLevel}");
    }
}
