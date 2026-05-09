using UnityEngine;

/// <summary>
/// Базовый класс для всех типов врагов с уникальным поведением
/// </summary>
public abstract class EnemyTypeBase : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] protected float maxHealth = 30f;
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected float attackRange = 1.5f;
    [SerializeField] protected float attackCooldown = 1f;

    [Header("Visuals")]
    [SerializeField] protected Color enemyColor = Color.red;
    [SerializeField] protected float modelScale = 2f; // Увеличено для лучшей видимости

    protected float currentHealth;
    protected Transform playerTransform;
    protected float lastAttackTime;
    protected bool isDead = false;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        FindPlayer();
        SetupVisuals();
    }

    protected virtual void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    protected virtual void SetupVisuals()
    {
        // Use ModelGenerator to create detailed enemy model
        GameObject visual = ModelGenerator.CreateEnemyModel(EnemyFactory.EnemyType.Normal);
        visual.transform.SetParent(transform);
        visual.transform.localPosition = Vector3.zero;
        visual.transform.localScale = Vector3.one * (modelScale / 2f); // Adjust scale for new models

        // Remove any colliders from visual parts
        foreach (Collider collider in visual.GetComponentsInChildren<Collider>())
        {
            Destroy(collider);
        }
    }

    protected virtual void Update()
    {
        if (isDead || playerTransform == null) return;

        UpdateBehavior();
        UpdateAttack();
    }

    protected virtual void UpdateBehavior()
    {
        // Base behavior: move toward player
        MoveTowardsPlayer();
    }

    protected virtual void MoveTowardsPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    protected virtual void UpdateAttack()
    {
        if (Time.time >= lastAttackTime + attackCooldown && IsInAttackRange())
        {
            AttackPlayer();
        }
    }

    protected virtual bool IsInAttackRange()
    {
        if (playerTransform == null) return false;
        return Vector3.Distance(transform.position, playerTransform.position) <= attackRange;
    }

    protected virtual void AttackPlayer()
    {
        lastAttackTime = Time.time;

        if (playerTransform == null) return;

        EnhancedPlayerController playerController = playerTransform.GetComponent<EnhancedPlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(damage);
        }
    }

    public virtual void TakeDamage(float dmg)
    {
        if (isDead) return;

        currentHealth -= dmg;

        // VFX hit effect
        if (VFXManager.Instance != null)
        {
            VFXManager.Instance.PlayHitEffect(transform.position + Vector3.up * 0.9f);
        }

        // Show damage
        if (FloatingTextManager.Instance != null)
        {
            FloatingTextManager.Instance.ShowDamage(dmg, transform.position + Vector3.up * 2f);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        isDead = true;

        // VFX death effect
        if (VFXManager.Instance != null)
        {
            VFXManager.Instance.PlayDeathEffect(transform.position);
        }

        // Register kill
        if (ComboSystem.Instance != null)
        {
            ComboSystem.Instance.RegisterKill();
        }

        Destroy(gameObject, 0.5f);
    }
}

/// <summary>
/// Быстрый враг - мало здоровья, высокая скорость, быстро атакует
/// </summary>
public class FastEnemy : EnemyTypeBase
{
    protected override void SetupVisuals()
    {
        // Use ModelGenerator to create detailed fast enemy model
        GameObject visual = ModelGenerator.CreateEnemyModel(EnemyFactory.EnemyType.Fast);
        visual.transform.SetParent(transform);
        visual.transform.localPosition = Vector3.zero;
        visual.transform.localScale = Vector3.one * (modelScale / 2f);

        // Remove any colliders from visual parts
        foreach (Collider collider in visual.GetComponentsInChildren<Collider>())
        {
            Destroy(collider);
        }
    }

    protected override void Start()
    {
        // Fast enemy stats
        maxHealth = 20f;
        moveSpeed = 5f;
        damage = 5f;
        attackRange = 1.5f;
        attackCooldown = 0.5f;

        base.Start();
    }

    protected override void MoveTowardsPlayer()
    {
        // Fast enemy moves more erratically
        if (playerTransform == null) return;

        Vector3 direction = (playerTransform.position - transform.position).normalized;
        direction.y = 0;

        // Add some strafing movement
        float strafe = Mathf.Sin(Time.time * 5f) * 0.3f;
        direction += transform.right * strafe;

        if (direction != Vector3.zero)
        {
            direction = direction.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 15f * Time.deltaTime);
        }

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}

/// <summary>
/// Танковый враг - много здоровья, медленный, сильный урон
/// </summary>
public class TankEnemy : EnemyTypeBase
{
    [Header("Tank Special")]
    [SerializeField] private float chargeSpeed = 8f;
    [SerializeField] private float chargeDuration = 1f;
    [SerializeField] private float chargeCooldown = 5f;

    private bool isCharging = false;
    private float chargeEndTime = 0f;
    private float lastChargeTime = 0f;
    private Vector3 chargeDirection;

    protected override void SetupVisuals()
    {
        // Use ModelGenerator to create detailed tank enemy model
        GameObject visual = ModelGenerator.CreateEnemyModel(EnemyFactory.EnemyType.Tank);
        visual.transform.SetParent(transform);
        visual.transform.localPosition = Vector3.zero;
        visual.transform.localScale = Vector3.one * (modelScale / 2f);

        // Remove any colliders from visual parts
        foreach (Collider collider in visual.GetComponentsInChildren<Collider>())
        {
            Destroy(collider);
        }
    }

    protected override void Start()
    {
        // Tank enemy stats
        maxHealth = 100f;
        moveSpeed = 1f;
        damage = 25f;
        attackRange = 2f;
        attackCooldown = 2f;

        base.Start();
    }

    protected override void UpdateBehavior()
    {
        if (isCharging)
        {
            UpdateCharge();
        }
        else
        {
            MoveTowardsPlayer();

            // Check if can charge
            float distanceToPlayer = playerTransform != null ? Vector3.Distance(transform.position, playerTransform.position) : 0f;
            if (Time.time >= lastChargeTime + chargeCooldown && distanceToPlayer < 10f)
            {
                StartCharge();
            }
        }
    }

    private void StartCharge()
    {
        isCharging = true;
        lastChargeTime = Time.time;
        chargeEndTime = Time.time + chargeDuration;

        // Calculate charge direction
        if (playerTransform != null)
        {
            chargeDirection = (playerTransform.position - transform.position).normalized;
            chargeDirection.y = 0;
        }

        // VFX warning
        if (VFXManager.Instance != null)
        {
            VFXManager.Instance.ShowTargetIndicator(transform.position, 1f);
        }

        Debug.Log("TankEnemy starts charging!");
    }

    private void UpdateCharge()
    {
        // Move in charge direction
        transform.position += chargeDirection * chargeSpeed * Time.deltaTime;

        // Look in charge direction
        if (chargeDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(chargeDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        // End charge after duration
        if (Time.time >= chargeEndTime)
        {
            isCharging = false;
            Debug.Log("TankEnemy stops charging");
        }
    }

    protected override void AttackPlayer()
    {
        base.AttackPlayer();

        // Tank deals extra damage if charging
        if (isCharging)
        {
            if (playerTransform != null)
            {
                EnhancedPlayerController playerController = playerTransform.GetComponent<EnhancedPlayerController>();
                if (playerController != null)
                {
                    playerController.TakeDamage(damage * 0.5f); // Bonus damage
                }
            }
        }
    }
}

/// <summary>
/// Враг дальнего боя - атакует издалека projectile-ами
/// </summary>
public class RangedEnemy : EnemyTypeBase
{
    [Header("Ranged Special")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private new float attackRange = 15f;
    [SerializeField] private float retreatDistance = 8f;

    protected override void SetupVisuals()
    {
        // Use ModelGenerator to create detailed ranged enemy model
        GameObject visual = ModelGenerator.CreateEnemyModel(EnemyFactory.EnemyType.Ranged);
        visual.transform.SetParent(transform);
        visual.transform.localPosition = Vector3.zero;
        visual.transform.localScale = Vector3.one * (modelScale / 2f);

        // Remove any colliders from visual parts
        foreach (Collider collider in visual.GetComponentsInChildren<Collider>())
        {
            Destroy(collider);
        }
    }

    protected override void Start()
    {
        // Ranged enemy stats
        maxHealth = 30f;
        moveSpeed = 2f;
        damage = 8f;
        attackRange = 15f;
        attackCooldown = 2f;

        base.Start();

        // Create projectile prefab if not assigned
        if (projectilePrefab == null)
        {
            projectilePrefab = CreateProjectilePrefab();
        }
    }

    protected override void MoveTowardsPlayer()
    {
        if (playerTransform == null) return;

        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // Maintain optimal distance
        if (distance < retreatDistance)
        {
            // Retreat
            Vector3 direction = (transform.position - playerTransform.position).normalized;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(-direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            }

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else if (distance > attackRange)
        {
            // Move closer
            base.MoveTowardsPlayer();
        }
        else
        {
            // Strafe to avoid being hit
            Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
            Vector3 strafeDirection = Vector3.Cross(toPlayer, Vector3.up).normalized;
            float strafe = Mathf.Sin(Time.time * 2f);

            if (strafeDirection != Vector3.zero)
            {
                transform.position += strafeDirection * strafe * moveSpeed * 0.5f * Time.deltaTime;
            }

            // Face player
            Quaternion targetRotation = Quaternion.LookRotation(toPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
        }
    }

    protected override void AttackPlayer()
    {
        lastAttackTime = Time.time;

        if (playerTransform == null) return;

        // Shoot projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            rb.linearVelocity = direction * projectileSpeed;
        }

        Projectile projectileComponent = projectile.GetComponent<Projectile>();
        if (projectileComponent != null)
        {
            projectileComponent.Initialize(damage);
        }

        Debug.Log("RangedEnemy fires projectile!");
    }

    private GameObject CreateProjectilePrefab()
    {
        GameObject prefab = new GameObject("Projectile");

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.SetParent(prefab.transform);
        sphere.transform.localScale = Vector3.one * 0.6f; // Увеличено для лучшей видимости

        Renderer renderer = sphere.GetComponent<Renderer>();
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = Color.cyan;
        renderer.material = mat;

        SphereCollider collider = sphere.GetComponent<SphereCollider>();
        collider.isTrigger = true;

        Rigidbody rb = prefab.AddComponent<Rigidbody>();
        rb.useGravity = false;

        prefab.AddComponent<Projectile>();

        return prefab;
    }
}

/// <summary>
/// Снаряд для врагов дальнего боя
/// </summary>
public class Projectile : MonoBehaviour
{
    private float damage = 10f;
    private float lifetime = 5f;

    public void Initialize(float dmg)
    {
        damage = dmg;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnhancedPlayerController player = other.GetComponent<EnhancedPlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            // VFX hit
            if (VFXManager.Instance != null)
            {
                VFXManager.Instance.PlayHitEffect(transform.position);
            }

            Destroy(gameObject);
        }
    }
}

/// <summary>
/// Фабрика для создания различных типов врагов
/// </summary>
public class EnemyFactory : MonoBehaviour
{
    public enum EnemyType
    {
        Normal,
        Fast,
        Tank,
        Ranged
    }

    public static GameObject CreateEnemy(EnemyType type, Vector3 position)
    {
        GameObject enemy = new GameObject(type.ToString() + "Enemy");
        enemy.transform.position = position;

        // Add collider
        CapsuleCollider collider = enemy.AddComponent<CapsuleCollider>();
        collider.height = 3.5f; // Увеличено для больших моделей
        collider.radius = 0.8f; // Увеличено для больших моделей
        collider.center = new Vector3(0, 1.75f, 0); // Увеличено для больших моделей

        // Add rigidbody
        Rigidbody rb = enemy.AddComponent<Rigidbody>();
        rb.mass = 1f;
        rb.linearDamping = 0f;
        rb.angularDamping = 0.05f;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // Add appropriate enemy type component
        switch (type)
        {
            case EnemyType.Normal:
                enemy.AddComponent<EnemyTypeBase>();
                break;
            case EnemyType.Fast:
                enemy.AddComponent<FastEnemy>();
                break;
            case EnemyType.Tank:
                enemy.AddComponent<TankEnemy>();
                break;
            case EnemyType.Ranged:
                enemy.AddComponent<RangedEnemy>();
                break;
        }

        // Set tag and layer
        enemy.tag = "Enemy";
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        if (enemyLayer != -1)
        {
            enemy.layer = enemyLayer;
        }

        return enemy;
    }
}
