using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MvpEnemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float maxHealth = 30f;
    [SerializeField] private float moveSpeed = 3.1f;
    [SerializeField] private float damage = 2f;
    [SerializeField] private float attackRange = 1.4f;
    [SerializeField] private float attackInterval = 1f;

    private float currentHealth;
    private Transform player;
    private MvpPlayerHealth playerHealth;
    private CharacterController characterController;
    private float lastAttackTime;
    private bool isPulled;
    private Coroutine pullRoutine;

    public event Action<MvpEnemy> OnDied;

    public void Initialize(Transform playerTransform, MvpPlayerHealth health)
    {
        player = playerTransform;
        playerHealth = health;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        if (isPulled)
        {
            return;
        }

        Vector3 toPlayer = player.position - transform.position;
        toPlayer.y = 0f;
        float distance = toPlayer.magnitude;

        if (distance > attackRange)
        {
            Vector3 move = toPlayer.normalized * moveSpeed;
            characterController.Move(move * Time.deltaTime);

            if (move.sqrMagnitude > 0.0001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move.normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 6f * Time.deltaTime);
            }
        }

        if (distance <= attackRange && Time.time >= lastAttackTime + attackInterval)
        {
            lastAttackTime = Time.time;
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void PullTo(Transform target, float speed, float stopDistance, float maxDuration)
    {
        if (target == null)
        {
            return;
        }

        if (pullRoutine != null)
        {
            StopCoroutine(pullRoutine);
        }

        pullRoutine = StartCoroutine(PullRoutine(target, speed, stopDistance, maxDuration));
    }

    private IEnumerator PullRoutine(Transform target, float speed, float stopDistance, float maxDuration)
    {
        isPulled = true;
        float elapsed = 0f;

        while (target != null && elapsed < maxDuration)
        {
            Vector3 toTarget = target.position - transform.position;
            toTarget.y = 0f;

            if (toTarget.magnitude <= stopDistance)
            {
                break;
            }

            Vector3 move = toTarget.normalized * speed;
            characterController.Move(move * Time.deltaTime);

            if (move.sqrMagnitude > 0.0001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move.normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        isPulled = false;
        pullRoutine = null;
    }

    private void Die()
    {
        OnDied?.Invoke(this);
        Destroy(gameObject);
    }
}
