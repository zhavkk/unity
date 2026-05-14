using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    private float currentHealth;
    private RageSystem rageSystem;

    public event Action<float, float> OnHealthChanged;
    public event Action OnDied;

    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;
    public float NormalizedHealth => maxHealth <= 0f ? 0f : currentHealth / maxHealth;
    public bool IsDead => currentHealth <= 0f;

    public void Initialize(RageSystem rage)
    {
        rageSystem = rage;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        NotifyHealthChanged();
    }

    public void TakeDamage(float amount)
    {
        if (amount <= 0f || IsDead)
        {
            return;
        }

        currentHealth = Mathf.Max(0f, currentHealth - amount);
        NotifyHealthChanged();

        if (rageSystem != null)
        {
            rageSystem.ApplyDamagePenalty();
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerCombat combat = GetComponent<PlayerCombat>();
        if (combat != null)
        {
            combat.CancelActions();
            combat.enabled = false;
        }

        PlayerController controller = GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.enabled = false;
        }

        CharacterController characterController = GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = false;
        }

        OnDied?.Invoke();
        Debug.Log("Player defeated.");
    }

    private void NotifyHealthChanged()
    {
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }
}
