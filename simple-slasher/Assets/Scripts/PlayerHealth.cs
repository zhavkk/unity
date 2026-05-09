using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    public event Action OnPlayerDeath;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Current health: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");

        // Disable player controls
        EnhancedPlayerController playerController = GetComponent<EnhancedPlayerController>();
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        PlayerAttract playerAttract = GetComponent<PlayerAttract>();
        if (playerAttract != null)
        {
            playerAttract.enabled = false;
        }

        OnPlayerDeath?.Invoke();
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log($"Player healed for {amount}. Current health: {currentHealth}/{maxHealth}");
    }
}
