using UnityEngine;
using UnityEngine.UI;

public class RageSystem : MonoBehaviour
{
    [Header("Rage Settings")]
    [SerializeField] public float maxRage = 100f;
    [SerializeField] private float rageDecayRate = 5f;
    [SerializeField] private float passiveDecayDelay = 3f;
    [SerializeField] public float ragePerAttack = 10f;

    [Header("Rage Bonuses")]
    [SerializeField] private float rageDamageThreshold = 50f;
    [SerializeField] private float rageDamageMultiplier = 1.5f;
    [SerializeField] public float maxDamageMultiplier = 2f;
    [SerializeField] private float rageSpeedThreshold = 50f;
    [SerializeField] private float rageSpeedMultiplier = 1.3f;

    [Header("Visual Effects")]
    [SerializeField] private GameObject rageEffect;
    [SerializeField] private Color rageColor = new Color(1f, 0.3f, 0f);
    [SerializeField] private float colorPulseSpeed = 2f;

    [Header("UI References")]
    [SerializeField] private Slider rageBar;
    [SerializeField] private Image rageFill;
    [SerializeField] private Text rageText;

    public float currentRage;
    private float lastActionTime;
    private bool isRageActive;
    private Material playerMaterial;
    private Color originalColor;

    private void Start()
    {
        currentRage = 0f;
        lastActionTime = Time.time;

        // Setup visual effects
        if (rageEffect != null)
            rageEffect.SetActive(false);

        // Setup material color change
        Renderer playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            playerMaterial = playerRenderer.material;
            originalColor = playerMaterial.color;
        }
    }

    private void Update()
    {
        HandleRageDecay();
        UpdateVisualEffects();
    }

    private void HandleRageDecay()
    {
        if (Time.time - lastActionTime > passiveDecayDelay && currentRage > 0)
        {
            currentRage = Mathf.Max(0f, currentRage - rageDecayRate * Time.deltaTime);
            UpdateUI();
        }
    }

    public void AddRage(float amount)
    {
        currentRage = Mathf.Min(maxRage, currentRage + amount);
        lastActionTime = Time.time;
        UpdateUI();
    }

    public void RemoveRage(float amount)
    {
        currentRage = Mathf.Max(0f, currentRage - amount);
        UpdateUI();
    }

    // Method for compatibility with EnhancedPlayerController
    public void ModifyRage(float amount)
    {
        if (amount > 0)
        {
            AddRage(amount);
        }
        else
        {
            RemoveRage(-amount);
        }
    }

    public float GetCurrentRage()
    {
        return currentRage;
    }

    public float GetMaxRage()
    {
        return maxRage;
    }

    public float GetDamageMultiplier()
    {
        return currentRage >= rageDamageThreshold ? rageDamageMultiplier : 1f;
    }

    public float GetSpeedMultiplier()
    {
        return currentRage >= rageSpeedThreshold ? rageSpeedMultiplier : 1f;
    }

    public bool IsRageActive()
    {
        return currentRage >= rageDamageThreshold;
    }

    public bool CanUseRageAbility(float cost)
    {
        return currentRage >= cost;
    }

    private void UpdateVisualEffects()
    {
        isRageActive = IsRageActive();

        if (rageEffect != null)
        {
            rageEffect.SetActive(isRageActive);
        }

        if (playerMaterial != null && isRageActive)
        {
            float pulse = Mathf.PingPong(Time.time * colorPulseSpeed, 1f);
            playerMaterial.color = Color.Lerp(originalColor, rageColor, pulse * 0.5f);
        }
        else if (playerMaterial != null)
        {
            playerMaterial.color = Color.Lerp(playerMaterial.color, originalColor, Time.deltaTime * 5f);
        }
    }

    private void UpdateUI()
    {
        if (rageBar != null)
        {
            rageBar.maxValue = maxRage;
            rageBar.value = currentRage;
        }

        if (rageFill != null)
        {
            if (isRageActive)
            {
                rageFill.color = rageColor;
            }
            else
            {
                rageFill.color = Color.Lerp(Color.white, rageColor, currentRage / maxRage);
            }
        }

        if (rageText != null)
        {
            rageText.text = $"{Mathf.Round(currentRage)} / {maxRage}";
        }
    }

    public void ResetRage()
    {
        currentRage = 0f;
        lastActionTime = Time.time;
        UpdateUI();
    }

    // Method to set player controller reference
    public void SetPlayerController(EnhancedPlayerController controller)
    {
        // Store reference if needed for future use
        // Currently not used but kept for compatibility
    }

    // Method called when player attacks
    public void OnPlayerAttack()
    {
        AddRage(ragePerAttack);
    }

    // Method called when player takes damage
    public void OnPlayerTakeDamage(float damage)
    {
        // Could add rage when taking damage if desired
        // For now, this is kept for compatibility
    }
}
