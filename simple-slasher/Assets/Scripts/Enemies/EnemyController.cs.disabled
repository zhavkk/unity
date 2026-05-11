using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int maxHealth = 50;
    [SerializeField] public float moveSpeed = 3f;
    [SerializeField] public float damage = 10f;
    [SerializeField] private float attackDamage = 10;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 1f;

    [Header("AI")]
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private LayerMask playerLayer;

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private Transform player;

    private int currentHealth;
    private bool isDead;
    private bool isAttacking;
    private float attackTimer;
    private bool isBeingAttracted;

    private void Start()
    {
        currentHealth = maxHealth;
        isDead = false;

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead) return;

        HandleAI();
        HandleAttack();
    }

    private void HandleAI()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Chase player if in range and not being attracted
        if (distanceToPlayer <= detectionRange && !isBeingAttracted)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0;

            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            if (animator != null)
            {
                animator.SetBool("IsMoving", true);
                animator.SetFloat("Speed", 1f);
            }
        }
        else if (!isBeingAttracted)
        {
            if (animator != null)
            {
                animator.SetBool("IsMoving", false);
                animator.SetFloat("Speed", 0f);
            }
        }
    }

    private void HandleAttack()
    {
        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                isAttacking = false;
            }
        }
        else if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange)
            {
                PerformAttack();
            }
        }
    }

    private void PerformAttack()
    {
        isAttacking = true;
        attackTimer = attackCooldown;

        if (animator != null)
            animator.SetTrigger("Attack");

        // Deal damage to player
        EnhancedPlayerController playerController = player?.GetComponent<EnhancedPlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= (int)damage;

        if (animator != null)
            animator.SetTrigger("TakeDamage");

        // Visual feedback
        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        if (animator != null)
            animator.SetTrigger("Die");

        // Disable collider
        Collider enemyCollider = GetComponent<Collider>();
        if (enemyCollider != null)
            enemyCollider.enabled = false;

        // Give score/rage to player
        EnhancedPlayerController playerController = player?.GetComponent<EnhancedPlayerController>();
        if (playerController != null)
        {
            playerController.AddRage(20f);
        }

        // Notify game manager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnEnemyKilled();
        }

        // Destroy after animation
        Destroy(gameObject, 2f);
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetBeingAttracted(bool isAttracted)
    {
        isBeingAttracted = isAttracted;
    }

    private System.Collections.IEnumerator FlashRed()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            Material originalMaterial = renderer.material;
            Color originalColor = originalMaterial.color;

            renderer.material.color = Color.red;
            yield return new WaitForSeconds(0.1f);

            if (!isDead)
            {
                renderer.material.color = originalColor;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw detection range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Draw attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
