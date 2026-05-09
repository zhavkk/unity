using UnityEngine;

/// <summary>
/// Helper script to set up character components automatically.
/// Attach this to your imported character model prefab.
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterSetup : MonoBehaviour
{
    [Header("Character Settings")]
    [Tooltip("Character height in Unity units")]
    public float characterHeight = 2f;

    [Tooltip("Character radius in Unity units")]
    public float characterRadius = 0.5f;

    [Tooltip("Character mass for physics calculations")]
    public float characterMass = 80f;

    [Tooltip("Center of mass offset")]
    public Vector3 centerOfMassOffset = new Vector3(0, 1f, 0);

    [Tooltip("Should this character be a player or enemy?")]
    public bool isPlayer = true;

    [Header("Animation Settings")]
    [Tooltip("Animator controller for this character")]
    public RuntimeAnimatorController animatorController;

    [Tooltip("Avatar for humanoid animations")]
    public Avatar characterAvatar;

    [Tooltip("Initial animation state")]
    public string initialState = "Idle";

    private void Awake()
    {
        SetupPhysics();
        SetupAnimation();
    }

    private void SetupPhysics()
    {
        // Configure Capsule Collider
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        if (capsuleCollider != null)
        {
            capsuleCollider.height = characterHeight;
            capsuleCollider.radius = characterRadius;
            capsuleCollider.center = centerOfMassOffset;
        }

        // Configure Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = characterMass;
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
    }

    private void SetupAnimation()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            if (characterAvatar != null)
            {
                animator.avatar = characterAvatar;
            }

            if (animatorController != null)
            {
                animator.runtimeAnimatorController = animatorController;
            }

            animator.updateMode = AnimatorUpdateMode.Normal;
            animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;

            // Play initial state
            if (!string.IsNullOrEmpty(initialState))
            {
                animator.Play(initialState, 0, 0f);
            }
        }
    }

    /// <summary>
    /// Call this method to apply all settings from the inspector.
    /// Useful for manually triggering setup after changing values.
    /// </summary>
    public void ApplySettings()
    {
        SetupPhysics();
        SetupAnimation();
    }

    /// <summary>
    /// Visual helper in scene view to show collider bounds.
    /// </summary>
    private void OnDrawGizmos()
    {
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        if (capsuleCollider != null)
        {
            Gizmos.color = isPlayer ? Color.green : Color.red;
            Gizmos.matrix = transform.localToWorldMatrix;

            // Draw capsule
            Vector3 center = capsuleCollider.center;
            float height = capsuleCollider.height;
            float radius = capsuleCollider.radius;

            // Draw top sphere
            Gizmos.DrawWireSphere(center + Vector3.up * (height / 2 - radius), radius);

            // Draw bottom sphere
            Gizmos.DrawWireSphere(center + Vector3.down * (height / 2 - radius), radius);

            // Draw connecting cylinder (simplified as lines)
            float cylinderHeight = height - radius * 2;
            Gizmos.DrawLine(center + Vector3.up * (radius), center + Vector3.down * (radius));

            // Draw top and bottom circles
            Vector3 topCenter = center + Vector3.up * (height / 2 - radius);
            Vector3 bottomCenter = center + Vector3.down * (height / 2 - radius);

            // Simple circle approximation
            for (int i = 0; i < 8; i++)
            {
                float angle1 = i * Mathf.PI / 4;
                float angle2 = ((i + 1) % 8) * Mathf.PI / 4;

                Vector3 p1 = new Vector3(Mathf.Cos(angle1) * radius, 0, Mathf.Sin(angle1) * radius);
                Vector3 p2 = new Vector3(Mathf.Cos(angle2) * radius, 0, Mathf.Sin(angle2) * radius);

                Gizmos.DrawLine(topCenter + p1, topCenter + p2);
                Gizmos.DrawLine(bottomCenter + p1, bottomCenter + p2);
            }
        }
    }
}
