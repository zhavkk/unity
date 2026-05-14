using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

[RequireComponent(typeof(CharacterController))]
public class PlayerCombat : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float attackRange = 2.2f;
    [SerializeField] private float attackCooldown = 0.35f;
    [SerializeField] private float attackDamage = 10f;

    [Header("Attract Dash")]
    [SerializeField] private float dashRange = 18f;
    [SerializeField] private float dashSpeed = 14f;
    [SerializeField] private float dashStopDistance = 1.2f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private float dashMaxDuration = 0.5f;

    [Header("Attract Pull")]
    [SerializeField] private float pullRange = 14f;
    [SerializeField] private float pullSpeed = 12f;
    [SerializeField] private float pullStopDistance = 1.4f;
    [SerializeField] private float pullCooldown = 1.2f;
    [SerializeField] private float pullMaxDuration = 0.6f;
    [SerializeField] private float pullRageGain = 8f;

    [Header("References")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private SwordSwing swordSwing;

    private CharacterController characterController;
    private RageSystem rageSystem;
    private PlayerHealth playerHealth;
    private float lastAttackTime;
    private float lastDashTime;
    private float lastPullTime;
    private bool isDashing;

    public bool IsDashing => isDashing;

    public void Initialize(RageSystem rage, Transform attackPointTransform, PlayerHealth health, SwordSwing swing)
    {
        rageSystem = rage;
        attackPoint = attackPointTransform;
        playerHealth = health;
        swordSwing = swing;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (playerHealth != null && playerHealth.IsDead)
        {
            return;
        }

        if (IsAttackPressed() && Time.time >= lastAttackTime + GetAttackCooldown())
        {
            PerformAttack();
        }

        if (!isDashing && IsDashPressed() && Time.time >= lastDashTime + dashCooldown)
        {
            TryDashToEnemy();
        }

        if (!isDashing && IsPullPressed() && Time.time >= lastPullTime + pullCooldown)
        {
            TryPullEnemy();
        }
    }

    private float GetAttackCooldown()
    {
        float speedMultiplier = rageSystem != null ? rageSystem.AttackSpeedMultiplier : 1f;
        return attackCooldown / Mathf.Max(0.1f, speedMultiplier);
    }

    private void PerformAttack()
    {
        lastAttackTime = Time.time;
        float attackSpeedMultiplier = rageSystem != null ? rageSystem.AttackSpeedMultiplier : 1f;

        if (swordSwing != null)
        {
            swordSwing.PlaySwing(attackSpeedMultiplier);
        }

        float totalDamage = attackDamage;
        if (rageSystem != null)
        {
            totalDamage *= rageSystem.DamageMultiplier;
            rageSystem.AddRage(rageSystem.RagePerAttack);
        }

        Vector3 center = attackPoint != null ? attackPoint.position : transform.position + transform.forward;
        Collider[] hits = Physics.OverlapSphere(center, attackRange);
        HashSet<Enemy> damaged = new HashSet<Enemy>();

        foreach (Collider hit in hits)
        {
            if (hit == null)
            {
                continue;
            }

            Enemy enemy = hit.GetComponentInParent<Enemy>();
            if (enemy != null && damaged.Add(enemy))
            {
                enemy.TakeDamage(totalDamage);
            }
        }
    }

    private void TryDashToEnemy()
    {
        Enemy target = FindClosestEnemy(dashRange);
        if (target == null)
        {
            return;
        }

        lastDashTime = Time.time;
        if (rageSystem != null)
        {
            rageSystem.AddRage(rageSystem.RagePerDash);
        }

        StartCoroutine(DashToTarget(target.transform));
    }

    private void TryPullEnemy()
    {
        Enemy target = FindClosestEnemy(pullRange);
        if (target == null)
        {
            return;
        }

        lastPullTime = Time.time;
        if (rageSystem != null)
        {
            rageSystem.AddRage(pullRageGain);
        }

        target.PullTo(transform, pullSpeed, pullStopDistance, pullMaxDuration);
    }

    private IEnumerator DashToTarget(Transform target)
    {
        isDashing = true;
        float elapsed = 0f;

        while (target != null && elapsed < dashMaxDuration)
        {
            if (playerHealth != null && playerHealth.IsDead)
            {
                break;
            }

            Vector3 toTarget = target.position - transform.position;
            toTarget.y = 0f;

            if (toTarget.magnitude <= dashStopDistance)
            {
                break;
            }

            Vector3 move = toTarget.normalized * dashSpeed;
            characterController.Move(move * Time.deltaTime);

            if (move.sqrMagnitude > 0.0001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move.normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 12f * Time.deltaTime);
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }

    public void CancelActions()
    {
        StopAllCoroutines();
        isDashing = false;

        if (swordSwing != null)
        {
            swordSwing.StopSwing();
        }
    }

    private Enemy FindClosestEnemy(float range)
    {
        Enemy[] enemies = Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        Enemy closest = null;
        float closestDistance = range;

        foreach (Enemy enemy in enemies)
        {
            if (enemy == null)
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= closestDistance)
            {
                closestDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }

    private bool IsAttackPressed()
    {
#if ENABLE_INPUT_SYSTEM
        return Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
        return Input.GetMouseButtonDown(0);
#endif

        return false;
    }

    private bool IsDashPressed()
    {
#if ENABLE_INPUT_SYSTEM
        return Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
        return Input.GetKeyDown(KeyCode.Q);
#endif

        return false;
    }

    private bool IsPullPressed()
    {
#if ENABLE_INPUT_SYSTEM
        return Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame;
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
        return Input.GetKeyDown(KeyCode.E);
#endif

        return false;
    }
}
