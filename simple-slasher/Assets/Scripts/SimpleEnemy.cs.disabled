using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float maxHealth = 50f;
    public float moveSpeed = 3f;
    public float damage = 10f;
    public float damageCooldown = 1f;

    [Header("References")]
    public SimplePlayerController player;

    private float currentHealth;
    private float lastDamageTime;
    private Renderer[] renderers;
    private Color originalColor;
    private bool isFlashing;

    void Awake()
    {
        currentHealth = maxHealth;

        // Create simple cube model if no renderer exists
        renderers = GetComponentsInChildren<Renderer>();
        if (renderers == null || renderers.Length == 0)
        {
            EnemyModelCreator.CreateEnemyModel(gameObject, EnemyType.Normal);
            renderers = GetComponentsInChildren<Renderer>();
        }

        // Add collider for hit detection
        BoxCollider collider = GetComponent<BoxCollider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider>();
            collider.center = new Vector3(0, 1f, 0);
            collider.size = new Vector3(1f, 2f, 1f);
        }

        if (renderers != null && renderers.Length > 0)
        {
            originalColor = renderers[0].material.color;
        }

        // Find player if not assigned
        if (player == null)
        {
            player = FindAnyObjectByType<SimplePlayerController>();
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        MoveTowardsPlayer();
        CheckBounds();
    }

    void CheckBounds()
    {
        // Prevent enemy from falling too far
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
            Debug.Log("Enemy fell out of world - destroying");
        }

        // Keep enemy within reasonable bounds
        float maxDistance = 60f;
        if (Vector3.Distance(transform.position, Vector3.zero) > maxDistance)
        {
            Destroy(gameObject);
            Debug.Log("Enemy out of bounds - destroying");
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position);
        direction.y = 0; // Keep movement on horizontal plane
        direction.Normalize();

        transform.position += direction * moveSpeed * Time.deltaTime;

        // Look at player
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * 5f
            );
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Direct collision with player
            DealDamageToPlayer();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Continuous collision
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                DealDamageToPlayer();
            }
        }
    }

    void DealDamageToPlayer()
    {
        if (Time.time >= lastDamageTime + damageCooldown)
        {
            player.TakeDamage(damage);
            lastDamageTime = Time.time;
            Debug.Log("Enemy hit player for " + damage + " damage");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took damage: " + damage + ". Health: " + currentHealth);

        FlashRed();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void FlashRed()
    {
        if (renderers == null || renderers.Length == 0 || isFlashing)
        {
            return;
        }

        isFlashing = true;
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = Color.white;
        }

        Invoke(nameof(ResetColor), 0.1f);
    }

    void ResetColor()
    {
        if (renderers != null && renderers.Length > 0)
        {
            foreach (Renderer renderer in renderers)
            {
                renderer.material.color = originalColor;
            }
        }
        isFlashing = false;
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Draw damage range (same as collider size)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * 1f, 1f);
    }
}
