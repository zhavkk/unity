using UnityEngine;

public class MvpRageSystem : MonoBehaviour
{
    [Header("Rage Settings")]
    [SerializeField] private float maxRage = 100f;
    [SerializeField] private float decayDelay = 1.5f;
    [SerializeField] private float decayRate = 6f;

    [Header("Aggression Gains")]
    [SerializeField] private float ragePerAttack = 14f;
    [SerializeField] private float ragePerDash = 22f;

    [Header("Multipliers")]
    [SerializeField] private float maxDamageMultiplier = 1.9f;
    [SerializeField] private float maxAttackSpeedMultiplier = 2.1f;
    [SerializeField] private float maxMoveSpeedMultiplier = 1.35f;

    [Header("Loss")]
    [SerializeField] private float rageLossOnDamage = 30f;

    private float currentRage;
    private float lastActionTime;

    public float CurrentRage => currentRage;
    public float MaxRage => maxRage;
    public float NormalizedRage => maxRage <= 0f ? 0f : currentRage / maxRage;

    public float DamageMultiplier => Mathf.Lerp(1f, maxDamageMultiplier, NormalizedRage);
    public float AttackSpeedMultiplier => Mathf.Lerp(1f, maxAttackSpeedMultiplier, NormalizedRage);
    public float MoveSpeedMultiplier => Mathf.Lerp(1f, maxMoveSpeedMultiplier, NormalizedRage);

    public float RagePerAttack => ragePerAttack;
    public float RagePerDash => ragePerDash;

    private void Awake()
    {
        currentRage = 0f;
        lastActionTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - lastActionTime < decayDelay)
        {
            return;
        }

        if (currentRage <= 0f)
        {
            return;
        }

        currentRage = Mathf.Max(0f, currentRage - decayRate * Time.deltaTime);
    }

    public void AddRage(float amount)
    {
        if (amount <= 0f)
        {
            return;
        }

        currentRage = Mathf.Min(maxRage, currentRage + amount);
        lastActionTime = Time.time;
    }

    public void ReduceRage(float amount)
    {
        if (amount <= 0f)
        {
            return;
        }

        currentRage = Mathf.Max(0f, currentRage - amount);
        lastActionTime = Time.time;
    }

    public void ApplyDamagePenalty()
    {
        ReduceRage(rageLossOnDamage);
    }
}
