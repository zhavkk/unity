using UnityEngine;
using UnityEngine.InputSystem;
using System;

/// <summary>
/// Улучшенный контроллер игрока с поддержкой обеих систем ввода.
/// Работает как с новой Input System, так и с классическим вводом.
/// </summary>
public class EnhancedPlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 10f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("Attack Settings")]
    [SerializeField] private float baseDamage = 10f;
    [SerializeField] private float baseAttackSpeed = 1f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask enemyLayer;

    [Header("References")]
    [SerializeField] private Transform attackPoint;

    [Header("Stats")]
    public float maxHealth = 100f;
    public float currentHealth;
    public float rage = 0f;
    public float maxRage = 100f;

    [Header("Rage Bonuses (Read-only)")]
    [SerializeField] private float currentDamageMultiplier = 1f;
    [SerializeField] private float currentAttackSpeedMultiplier = 1f;

    [Header("Input Mode")]
    [SerializeField] private bool useInputSystem = true;
    [SerializeField] private bool showDebugInfo = true;

    // Events
    public event Action OnPlayerAttack;
    public event Action<float> OnPlayerTakeDamage;
    public event Action OnPlayerDeath;

    // Components
    private CharacterController characterController;
    private InputSystem_Actions inputActions;
    private RageSystem rageSystem;

    // Movement state
    private Vector2 moveInput;
    private Vector3 velocity;
    private float currentSpeed;
    private bool isGrounded;
    private bool isJumping;
    private bool isSprinting;
    private bool isAttacking;
    private float lastAttackTime;

    // Camera for rotation
    private Camera mainCamera;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
        rageSystem = GetComponent<RageSystem>();
        currentHealth = maxHealth;

        if (mainCamera == null)
        {
            mainCamera = UnityEngine.Object.FindAnyObjectByType<Camera>();
        }

        // Initialize input system if available
        if (useInputSystem)
        {
            try
            {
                inputActions = new InputSystem_Actions();
            }
            catch (System.Exception e)
            {
                Debug.LogWarning($"Could not initialize Input System: {e.Message}. Falling back to legacy input.");
                useInputSystem = false;
            }
        }
    }

    private void OnEnable()
    {
        if (useInputSystem && inputActions != null)
        {
            inputActions.Player.Enable();
            inputActions.Player.Move.performed += OnMovePerformed;
            inputActions.Player.Move.canceled += OnMoveCanceled;
            inputActions.Player.Jump.performed += OnJumpPerformed;
            inputActions.Player.Sprint.performed += OnSprintPerformed;
            inputActions.Player.Sprint.canceled += OnSprintCanceled;
            inputActions.Player.Attack.performed += OnAttackPerformed;
        }
    }

    private void OnDisable()
    {
        if (useInputSystem && inputActions != null)
        {
            inputActions.Player.Move.performed -= OnMovePerformed;
            inputActions.Player.Move.canceled -= OnMoveCanceled;
            inputActions.Player.Jump.performed -= OnJumpPerformed;
            inputActions.Player.Sprint.performed -= OnSprintPerformed;
            inputActions.Player.Sprint.canceled -= OnSprintCanceled;
            inputActions.Player.Attack.performed -= OnAttackPerformed;
            inputActions.Player.Disable();
        }
    }

    private void Update()
    {
        HandleInput();
        CheckGrounded();
        HandleMovement();
        HandleJump();
        UpdateAttackCooldown();

        // Debug info disabled for Input System compatibility
    }

    private void HandleInput()
    {
        if (useInputSystem && inputActions != null)
        {
            // Input System handles input via event callbacks
            return;
        }

        // Legacy input fallback
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            OnJumpPerformed(default);
        }

        isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            OnAttackPerformed(default);
        }
    }

    #region Input System Callbacks
    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            isJumping = true;
        }
    }

    private void OnSprintPerformed(InputAction.CallbackContext context)
    {
        isSprinting = true;
    }

    private void OnSprintCanceled(InputAction.CallbackContext context)
    {
        isSprinting = false;
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        if (!isAttacking)
        {
            TryAttack();
        }
    }
    #endregion

    private void CheckGrounded()
    {
        isGrounded = characterController.isGrounded;
    }

    private void HandleMovement()
    {
        // Get camera forward direction (flattened to XZ plane)
        Vector3 cameraForward = mainCamera != null ? mainCamera.transform.forward : Vector3.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 cameraRight = mainCamera != null ? mainCamera.transform.right : Vector3.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        // Calculate move direction relative to camera
        Vector3 moveDirection = (cameraForward * moveInput.y + cameraRight * moveInput.x).normalized;

        float targetSpeed = isSprinting ? sprintSpeed : walkSpeed;

        // Apply acceleration/deceleration
        if (moveDirection != Vector3.zero)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

            // Rotate towards movement direction
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, deceleration * Time.deltaTime);
        }

        // Apply movement
        Vector3 moveVelocity = transform.forward * currentSpeed;
        moveVelocity.y = velocity.y;

        characterController.Move(moveVelocity * Time.deltaTime);
    }

    private void HandleJump()
    {
        if (isJumping && isGrounded)
        {
            velocity.y = jumpForce;
            isJumping = false;
        }

        // Apply gravity
        if (!isGrounded)
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            velocity.y = -0.5f; // Small downward force to keep grounded
        }
    }

    private void UpdateAttackCooldown()
    {
        if (isAttacking && Time.time >= lastAttackTime + 0.3f)
        {
            isAttacking = false;
        }
    }

    private void TryAttack()
    {
        if (Time.time >= lastAttackTime + (1f / GetEffectiveAttackSpeed()))
        {
            PerformAttack();
            lastAttackTime = Time.time;
            isAttacking = true;

            Debug.Log($"[PlayerController] Attack performed! Damage: {GetEffectiveDamage()}, Range: {attackRange}");
        }
    }

    private void PerformAttack()
    {
        // Trigger attack event
        OnPlayerAttack?.Invoke();

        // Calculate current damage with rage and combo bonuses
        float totalDamage = GetEffectiveDamage();

        // Apply combo multiplier
        if (ComboSystem.Instance != null)
        {
            float comboMultiplier = ComboSystem.Instance.GetDamageMultiplier();
            totalDamage *= comboMultiplier;
        }

        // Check for enemies in attack range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        Debug.Log($"[PlayerController] Attack hit {hitEnemies.Length} enemies in range");

        foreach (Collider enemy in hitEnemies)
        {
            // Apply damage to enemy
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(totalDamage);
                Debug.Log($"[PlayerController] Dealt {totalDamage} damage to {enemy.name}");
            }

            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(totalDamage);
            }
        }

        // Visual feedback with VFX
        CreateAttackEffect();

        // Play slash effect
        if (VFXManager.Instance != null)
        {
            VFXManager.Instance.PlaySlashEffect(attackPoint.position, transform.forward);
        }
    }

    private void CreateAttackEffect()
    {
        // Simple attack visual - could be enhanced with particles
        if (attackPoint != null)
        {
            // Create a temporary visual indicator
            GameObject attackIndicator = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            attackIndicator.transform.position = attackPoint.position;
            attackIndicator.transform.localScale = Vector3.one * attackRange * 2;
            attackIndicator.GetComponent<Renderer>().material.color = new Color(1, 0.5f, 0, 0.3f);

            // Destroy after short duration
            Destroy(attackIndicator, 0.2f);
        }
    }

    #region Stats and Rage System
    private float GetEffectiveDamage()
    {
        return baseDamage * currentDamageMultiplier;
    }

    private float GetEffectiveAttackSpeed()
    {
        return baseAttackSpeed * currentAttackSpeedMultiplier;
    }

    public void SetRageMultipliers(float damageMultiplier, float attackSpeedMultiplier)
    {
        currentDamageMultiplier = damageMultiplier;
        currentAttackSpeedMultiplier = attackSpeedMultiplier;

        if (showDebugInfo)
        {
            Debug.Log($"[PlayerController] Rage multipliers updated: Damage x{damageMultiplier}, Speed x{attackSpeedMultiplier}");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnPlayerTakeDamage?.Invoke(damage);

        Debug.Log($"[PlayerController] Took {damage} damage! Health: {currentHealth}/{maxHealth}");

        // Forward damage to PlayerHealth component for unified death handling
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
        else if (currentHealth <= 0)
        {
            // Fallback if no PlayerHealth component
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("[PlayerController] Player died!");
        OnPlayerDeath?.Invoke();
        enabled = false;
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log($"[PlayerController] Healed {amount}! Health: {currentHealth}/{maxHealth}");
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            // Draw attack range
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }

    public float GetCurrentHealth() => currentHealth;
    public float GetMaxHealth() => maxHealth;
    public bool IsAttacking() => isAttacking;
    public bool IsGrounded() => isGrounded;

    // Rage system integration methods
    public void AddRage(float amount)
    {
        if (rageSystem != null)
        {
            rageSystem.ModifyRage(amount);
            Debug.Log($"[PlayerController] Added {amount} rage. Current: {rageSystem.currentRage}/{rageSystem.maxRage}");
        }
        else
        {
            Debug.LogWarning("[PlayerController] RageSystem not found!");
        }
    }

    public void UseRage(float amount)
    {
        if (rageSystem != null)
        {
            rageSystem.ModifyRage(-amount);
            Debug.Log($"[PlayerController] Used {amount} rage. Current: {rageSystem.currentRage}/{rageSystem.maxRage}");
        }
    }

    public bool CanAttract()
    {
        if (rageSystem != null)
        {
            return rageSystem.CanUseRageAbility(30f); // 30 rage cost for attraction
        }
        return false;
    }

    public void AttractToEnemy(Transform enemyTransform, float speed)
    {
        if (!CanAttract()) return;

        Vector3 direction = (enemyTransform.position - transform.position).normalized;
        direction.y = 0; // Keep on ground

        characterController.Move(direction * speed * Time.deltaTime);
        UseRage(10f * Time.deltaTime); // Cost while attracting
    }
}