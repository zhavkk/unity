using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttract : MonoBehaviour
{
    [Header("Attraction Settings")]
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.3f;
    [SerializeField] private float attractRange = 20f;
    [SerializeField] private LayerMask enemyLayer;

    [Header("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerInput playerInput;

    private bool isDashing = false;
    private float dashTime = 0f;
    private Vector3 dashTarget;
    private InputAction rightClickAction;
    private InputAction mousePositionAction;

    private void Awake()
    {
        // Get or add required components
        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }

        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
        }

        // Setup input actions
        if (playerInput != null)
        {
            // Get the UI action map which contains RightClick and Point
            InputActionMap uiActionMap = playerInput.actions.FindActionMap("UI", true);
            if (uiActionMap != null)
            {
                rightClickAction = uiActionMap.FindAction("RightClick", true);
                mousePositionAction = uiActionMap.FindAction("Point", true);

                if (rightClickAction != null)
                {
                    rightClickAction.performed += OnRightClick;
                }
            }
            else
            {
                Debug.LogWarning("PlayerAttract: UI action map not found. Attraction feature may not work.");
            }
        }
    }

    private void OnDestroy()
    {
        if (rightClickAction != null)
        {
            rightClickAction.performed -= OnRightClick;
        }
    }

    private void Update()
    {
        if (isDashing)
        {
            DashToTarget();
        }
    }

    private void OnRightClick(InputAction.CallbackContext context)
    {
        if (isDashing) return;

        // Find enemy under mouse cursor
        Vector2 mousePosition = mousePositionAction.ReadValue<Vector2>();
        EnemyController targetEnemy = FindEnemyAtMousePosition(mousePosition);

        if (targetEnemy != null && !targetEnemy.IsDead())
        {
            StartDash(targetEnemy.transform.position);
        }
    }

    private EnemyController FindEnemyAtMousePosition(Vector2 mousePosition)
    {
        // Get camera safely
        Camera camera = Camera.main;
        if (camera == null)
        {
            camera = UnityEngine.Object.FindAnyObjectByType<Camera>();
            if (camera == null)
            {
                Debug.LogWarning("PlayerAttract: No camera found for raycasting");
                return null;
            }
        }

        Ray ray = camera.ScreenPointToRay(mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, attractRange, enemyLayer);

        foreach (RaycastHit hit in hits)
        {
            EnemyController enemy = hit.collider.GetComponent<EnemyController>();
            if (enemy != null && !enemy.IsDead())
            {
                return enemy;
            }
        }

        return null;
    }

    private void StartDash(Vector3 targetPosition)
    {
        isDashing = true;
        dashTime = dashDuration;
        dashTarget = targetPosition;

        // Show target indicator
        if (VFXManager.Instance != null)
        {
            VFXManager.Instance.ShowTargetIndicator(targetPosition, dashDuration);
        }

        // Stop character controller from interfering with dash
        // by disabling it temporarily
        if (characterController != null)
        {
            characterController.enabled = false;
        }

        Debug.Log($"Dashing to enemy at {targetPosition}");
    }

    private void DashToTarget()
    {
        dashTime -= Time.deltaTime;

        // Calculate direction to target
        Vector3 direction = (dashTarget - transform.position).normalized;
        direction.y = 0; // Keep movement on horizontal plane

        // Move toward target
        float distance = Vector3.Distance(transform.position, dashTarget);
        float moveDistance = dashSpeed * Time.deltaTime;

        if (distance <= moveDistance || dashTime <= 0)
        {
            // Reached target or time expired
            transform.position = new Vector3(dashTarget.x, transform.position.y, dashTarget.z);
            EndDash();
        }
        else
        {
            transform.position += direction * moveDistance;
        }

        // Rotate to face target
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }

    private void EndDash()
    {
        // Play dash trail effect
        if (VFXManager.Instance != null)
        {
            VFXManager.Instance.PlayDashTrail(transform.position, dashTarget);
        }

        isDashing = false;
        dashTime = 0f;

        // Re-enable character controller
        if (characterController != null)
        {
            characterController.enabled = true;
        }

        Debug.Log("Dash completed");
    }

    public bool IsDashing()
    {
        return isDashing;
    }
}
