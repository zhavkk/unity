using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleAttractSystem : MonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashCooldown = 2f;
    [SerializeField] private float dashDuration = 0.3f;
    [SerializeField] private float stopDistance = 1.5f;

    [Header("References")]
    [SerializeField] private Camera playerCamera;

    [Header("Visual Feedback")]
    [SerializeField] private Color dashColor = Color.cyan;
    [SerializeField] private Color originalColor = Color.white;

    private CharacterController characterController;
    private SimplePlayerController playerController;
    private Renderer[] playerRenderers;
    private float lastDashTime;
    private bool isDashing;
    private Vector3 dashTarget;
    private float dashStartTime;

    // Input references
    private Mouse mouse;

    void Awake()
    {
        // Get input device
        mouse = Mouse.current;

        // Get or add CharacterController
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            characterController = gameObject.AddComponent<CharacterController>();
        }

        // Get player controller reference
        playerController = GetComponent<SimplePlayerController>();

        // Get or find camera
        playerCamera = GetComponentInChildren<Camera>();
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        // Get player renderers for visual feedback
        playerRenderers = GetComponentsInChildren<Renderer>();
        if (playerRenderers != null && playerRenderers.Length > 0)
        {
            originalColor = playerRenderers[0].material.color;
        }
    }

    void Update()
    {
        // Ensure mouse is available
        if (mouse == null)
        {
            mouse = Mouse.current;
            if (mouse == null)
                return;
        }

        // Handle dash input
        if (mouse.rightButton.wasPressedThisFrame && CanDash())
        {
            TryDashToEnemy();
        }

        // Handle active dash
        if (isDashing)
        {
            UpdateDash();
        }
    }

    bool CanDash()
    {
        return Time.time >= lastDashTime + dashCooldown && !isDashing;
    }

    void TryDashToEnemy()
    {
        // Raycast from camera to find enemy under mouse cursor
        Vector2 mousePosition = mouse.position.ReadValue();
        Ray ray = playerCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Check if we hit a SimpleEnemy
            SimpleEnemy enemy = hit.collider.GetComponentInParent<SimpleEnemy>();
            if (enemy != null)
            {
                StartDashToEnemy(enemy.transform);
            }
            else
            {
                Debug.Log("No enemy found under cursor");
            }
        }
    }

    void StartDashToEnemy(Transform enemyTransform)
    {
        isDashing = true;
        dashStartTime = Time.time;
        lastDashTime = Time.time;

        // Calculate dash target position
        Vector3 direction = (enemyTransform.position - transform.position);
        direction.y = 0; // Keep on horizontal plane
        direction.Normalize();

        dashTarget = enemyTransform.position - direction * stopDistance;
        dashTarget.y = transform.position.y; // Maintain current height

        // Apply visual feedback
        ApplyDashVisuals();

        Debug.Log("Dashing to enemy!");
    }

    void UpdateDash()
    {
        float dashProgress = (Time.time - dashStartTime) / dashDuration;

        if (dashProgress >= 1f)
        {
            // Dash complete
            isDashing = false;
            ResetVisuals();
            return;
        }

        // Move towards target
        Vector3 direction = (dashTarget - transform.position);
        direction.y = 0;
        float distance = direction.magnitude;

        if (distance <= 0.1f)
        {
            // Reached target
            isDashing = false;
            ResetVisuals();
            return;
        }

        direction.Normalize();
        characterController.Move(direction * dashSpeed * Time.deltaTime);
    }

    void ApplyDashVisuals()
    {
        if (playerRenderers == null || playerRenderers.Length == 0)
        {
            return;
        }

        // Change player color to indicate dash
        foreach (Renderer renderer in playerRenderers)
        {
            if (renderer.material != null)
            {
                renderer.material.color = dashColor;
            }
        }
    }

    void ResetVisuals()
    {
        if (playerRenderers == null || playerRenderers.Length == 0)
        {
            return;
        }

        // Reset player color
        foreach (Renderer renderer in playerRenderers)
        {
            if (renderer.material != null)
            {
                renderer.material.color = originalColor;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw dash range indicator
        Gizmos.color = Color.cyan;
        if (playerCamera != null)
        {
            Gizmos.DrawWireSphere(transform.position, stopDistance);
        }
    }
}
