using UnityEngine;

/// <summary>
/// Controls character animations based on player input and game state.
/// Works with Unity's Animator system and Mecanim.
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    [Header("Animation Parameters")]
    [Tooltip("Movement speed parameter name")]
    public string speedParameter = "Speed";

    [Tooltip("Attack trigger parameter name")]
    public string attackTrigger = "AttackTrigger";

    [Tooltip("Jump trigger parameter name")]
    public string jumpTrigger = "JumpTrigger";

    [Tooltip("Grounded bool parameter name")]
    public string groundedParameter = "IsGrounded";

    [Tooltip("Take damage trigger parameter name")]
    public string takeDamageTrigger = "TakeDamage";

    [Tooltip("Death trigger parameter name")]
    public string deathTrigger = "Death";

    [Header("Animation Settings")]
    [Tooltip("Transition speed between animations")]
    [Range(0f, 1f)]
    public float animationBlendSpeed = 0.15f;

    [Tooltip("Attack animation duration")]
    public float attackDuration = 0.5f;

    [Tooltip("Jump animation duration")]
    public float jumpDuration = 0.8f;

    private Animator animator;
    private float currentSpeed;
    private bool isAttacking;
    private bool isJumping;
    private bool isGrounded = true;
    private float attackTimer;
    private float jumpTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAttackTimer();
        UpdateJumpTimer();
        UpdateSpeedParameter();
    }

    /// <summary>
    /// Sets movement speed for animation blending.
    /// Call this from your movement script.
    /// </summary>
    /// <param name="speed">Current movement speed (0-1 range recommended)</param>
    public void SetSpeed(float speed)
    {
        currentSpeed = Mathf.Clamp01(speed);
    }

    /// <summary>
    /// Triggers attack animation.
    /// </summary>
    public void TriggerAttack()
    {
        if (!isAttacking)
        {
            animator.SetTrigger(attackTrigger);
            isAttacking = true;
            attackTimer = attackDuration;
        }
    }

    /// <summary>
    /// Triggers jump animation.
    /// </summary>
    public void TriggerJump()
    {
        if (!isJumping && isGrounded)
        {
            animator.SetTrigger(jumpTrigger);
            isJumping = true;
            jumpTimer = jumpDuration;
            isGrounded = false;
            animator.SetBool(groundedParameter, false);
        }
    }

    /// <summary>
    /// Triggers take damage animation.
    /// </summary>
    public void TriggerTakeDamage()
    {
        animator.SetTrigger(takeDamageTrigger);
    }

    /// <summary>
    /// Triggers death animation.
    /// </summary>
    public void TriggerDeath()
    {
        animator.SetTrigger(deathTrigger);
    }

    /// <summary>
    /// Updates grounded state for animation transitions.
    /// </summary>
    /// <param name="grounded">Whether the character is on the ground</param>
    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
        animator.SetBool(groundedParameter, grounded);

        // Reset jump state when landing
        if (grounded && isJumping && jumpTimer <= 0)
        {
            isJumping = false;
        }
    }

    /// <summary>
    /// Updates the speed parameter with smooth blending.
    /// </summary>
    private void UpdateSpeedParameter()
    {
        float targetSpeed = currentSpeed;
        float currentAnimSpeed = animator.GetFloat(speedParameter);
        float blendedSpeed = Mathf.Lerp(currentAnimSpeed, targetSpeed, animationBlendSpeed);
        animator.SetFloat(speedParameter, blendedSpeed);
    }

    /// <summary>
    /// Manages attack animation timer.
    /// </summary>
    private void UpdateAttackTimer()
    {
        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                isAttacking = false;
            }
        }
    }

    /// <summary>
    /// Manages jump animation timer.
    /// </summary>
    private void UpdateJumpTimer()
    {
        if (isJumping)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0)
            {
                isJumping = false;
            }
        }
    }

    /// <summary>
    /// Checks if the character is currently attacking.
    /// </summary>
    public bool IsAttacking()
    {
        return isAttacking;
    }

    /// <summary>
    /// Checks if the character is currently jumping.
    /// </summary>
    public bool IsJumping()
    {
        return isJumping;
    }

    /// <summary>
    /// Gets the current animation state name.
    /// </summary>
    public string GetCurrentAnimationState()
    {
        if (animator != null)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.shortNameHash.ToString();
        }
        return "Unknown";
    }

    /// <summary>
    /// Resets all animation parameters to default values.
    /// </summary>
    public void ResetAnimationParameters()
    {
        animator.SetFloat(speedParameter, 0f);
        animator.SetBool(groundedParameter, true);
        isAttacking = false;
        isJumping = false;
        isGrounded = true;
        currentSpeed = 0f;
    }
}
