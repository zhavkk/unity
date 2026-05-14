using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    private CharacterController characterController;
    private Camera mainCamera;
    private RageSystem rageSystem;
    private PlayerCombat combat;
    private PlayerHealth playerHealth;

    public void Initialize(RageSystem rage, PlayerCombat combatRef, PlayerHealth health)
    {
        rageSystem = rage;
        combat = combatRef;
        playerHealth = health;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        mainCamera = Camera.main ?? Object.FindAnyObjectByType<Camera>();
    }

    private void Update()
    {
        if (playerHealth != null && playerHealth.IsDead)
        {
            return;
        }

        if (combat != null && combat.IsDashing)
        {
            return;
        }

        Vector2 input = ReadMoveInput();
        if (input.sqrMagnitude < 0.001f)
        {
            return;
        }

        Vector3 moveDirection = CalculateWorldDirection(input);
        if (moveDirection.sqrMagnitude < 0.001f)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        float speed = moveSpeed;
        if (rageSystem != null)
        {
            speed *= rageSystem.MoveSpeedMultiplier;
        }

        characterController.Move(moveDirection * speed * Time.deltaTime);
    }

    private Vector3 CalculateWorldDirection(Vector2 input)
    {
        Vector3 forward = mainCamera != null ? mainCamera.transform.forward : Vector3.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = mainCamera != null ? mainCamera.transform.right : Vector3.right;
        right.y = 0f;
        right.Normalize();

        Vector3 direction = (forward * input.y + right * input.x).normalized;
        return direction;
    }

    private Vector2 ReadMoveInput()
    {
        Vector2 input = Vector2.zero;

#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) input.y += 1f;
            if (Keyboard.current.sKey.isPressed) input.y -= 1f;
            if (Keyboard.current.dKey.isPressed) input.x += 1f;
            if (Keyboard.current.aKey.isPressed) input.x -= 1f;
        }
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
#endif

        return input.normalized;
    }
}
