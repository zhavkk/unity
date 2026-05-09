using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float mouseSensitivity = 2f;

    [Header("Player Stats")]
    public float maxHealth = 100f;
    public float attackDamage = 25f;
    public float attackRange = 2f;
    public float attackCooldown = 0.5f;

    private CharacterController controller;
    private Camera playerCamera;
    private Vector3 velocity;
    private float health;
    private float lastAttackTime;
    private bool isGrounded;

    // Input references
    private Keyboard keyboard;
    private Mouse mouse;

    void Awake()
    {
        // Set player tag
        if (gameObject.tag != "Player")
        {
            gameObject.tag = "Player";
        }

        // Get input devices
        keyboard = Keyboard.current;
        mouse = Mouse.current;

        // Create or get CharacterController
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            controller = gameObject.AddComponent<CharacterController>();
            controller.height = 2f;
            controller.radius = 0.5f;
            controller.center = new Vector3(0, 1f, 0);
        }

        // Setup camera - use Main Camera or create new one
        SetupCamera();

        // Create visual representation if none exists
        if (GetComponent<Renderer>() == null && transform.childCount <= 1)
        {
            PlayerModelCreator.CreatePlayerModel(gameObject);
        }

        // Add collider for interactions
        BoxCollider collider = GetComponent<BoxCollider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider>();
            collider.center = new Vector3(0, 1f, 0);
            collider.size = new Vector3(0.8f, 2f, 0.8f);
        }

        // Initialize health
        health = maxHealth;
    }

    void SetupCamera()
    {
        // Try to find existing Main Camera first
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            playerCamera = mainCam;
            // Make camera a child of player for proper rotation
            playerCamera.transform.SetParent(transform);
            playerCamera.transform.localPosition = new Vector3(0, 1.5f, 0);
            return;
        }

        // Create new camera if none exists
        GameObject cameraObj = new GameObject("PlayerCamera");
        playerCamera = cameraObj.AddComponent<Camera>();
        cameraObj.tag = "MainCamera";
        cameraObj.AddComponent<AudioListener>();

        // Parent camera to player for proper rotation
        cameraObj.transform.SetParent(transform);
        cameraObj.transform.localPosition = new Vector3(0, 1.5f, 0);
    }

    void Update()
    {
        if (keyboard == null || mouse == null)
        {
            keyboard = Keyboard.current;
            mouse = Mouse.current;
            if (keyboard == null || mouse == null)
                return;
        }

        HandleMovement();
        HandleMouseLook();
        HandleJump();
        HandleAttack();
        ApplyGravity();
        CheckBounds();
    }

    void CheckBounds()
    {
        // Prevent player from falling too far or going too far from origin
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0f, 2f, 0f);
            velocity = Vector3.zero;
            Debug.Log("Player fell out of world - respawning");
        }

        // Keep player within reasonable bounds
        float maxDistance = 50f;
        if (Vector3.Distance(transform.position, Vector3.zero) > maxDistance)
        {
            Vector3 direction = (Vector3.zero - transform.position).normalized;
            transform.position = Vector3.zero + direction * (maxDistance - 1f);
            velocity = Vector3.zero;
            Debug.Log("Player out of bounds - returning to play area");
        }
    }

    void HandleMovement()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (keyboard.aKey.isPressed)
            horizontal = -1f;
        else if (keyboard.dKey.isPressed)
            horizontal = 1f;

        if (keyboard.wKey.isPressed)
            vertical = 1f;
        else if (keyboard.sKey.isPressed)
            vertical = -1f;

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        Vector2 mouseDelta = mouse.delta.ReadValue();
        float mouseX = mouseDelta.x * mouseSensitivity;
        float mouseY = mouseDelta.y * mouseSensitivity;

        // Rotate player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera vertically
        Vector3 cameraRotation = playerCamera.transform.localEulerAngles;
        cameraRotation.x -= mouseY;
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -80f, 80f);
        playerCamera.transform.localEulerAngles = cameraRotation;
    }

    void HandleJump()
    {
        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
        {
            velocity.y = jumpForce;
        }
    }

    void HandleAttack()
    {
        if (mouse.leftButton.wasPressedThisFrame && Time.time >= lastAttackTime + attackCooldown)
        {
            PerformAttack();
            lastAttackTime = Time.time;
        }
    }

    void PerformAttack()
    {
        // Create a hitbox in front of player
        Vector3 attackOrigin = playerCamera.transform.position + playerCamera.transform.forward * attackRange / 2;
        Collider[] hitColliders = Physics.OverlapSphere(attackOrigin, attackRange / 2);

        foreach (Collider hit in hitColliders)
        {
            if (hit.gameObject != gameObject)
            {
                SimpleEnemy enemy = hit.GetComponent<SimpleEnemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(attackDamage);
                }
            }
        }

        Debug.Log("Attack performed!");
    }

    void ApplyGravity()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player took damage: " + damage + ". Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        Debug.Log("Player healed: " + amount + ". Health: " + health);
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Add death logic here (respawn, game over, etc.)
    }

    void OnDrawGizmosSelected()
    {
        if (playerCamera != null)
        {
            // Draw attack range
            Vector3 attackOrigin = playerCamera.transform.position + playerCamera.transform.forward * attackRange / 2;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackOrigin, attackRange / 2);
        }
    }
}
