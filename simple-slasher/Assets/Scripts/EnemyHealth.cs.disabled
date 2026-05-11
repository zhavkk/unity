using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // VFX: Show hit effect
        try
        {
            if (VFXManager.Instance != null)
            {
                VFXManager.Instance.PlayHitEffect(transform.position);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning($"VFXManager error: {e.Message}");
        }

        // Show damage text
        try
        {
            if (FloatingTextManager.Instance != null)
            {
                FloatingTextManager.Instance.ShowDamage(damage, transform.position + Vector3.up * 2f);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning($"FloatingTextManager error: {e.Message}");
        }

        // Register hit in combo system
        try
        {
            if (ComboSystem.Instance != null)
            {
                ComboSystem.Instance.RegisterHit(false);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning($"ComboSystem error: {e.Message}");
        }

        Debug.Log($"{gameObject.name} took {damage} damage. Health: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died!");

        // VFX: Death effect
        if (VFXManager.Instance != null)
        {
            VFXManager.Instance.PlayDeathEffect(transform.position);
        }

        // Register kill in combo system
        if (ComboSystem.Instance != null)
        {
            ComboSystem.Instance.RegisterKill();
        }

        Destroy(gameObject);
    }
}
