using System.Collections;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    [SerializeField] private float swingAngle = 90f;
    [SerializeField] private float swingDuration = 0.18f;
    [SerializeField] private AnimationCurve swingCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    private Quaternion baseRotation;
    private Coroutine swingRoutine;

    private void Awake()
    {
        baseRotation = transform.localRotation;
    }

    public void PlaySwing()
    {
        PlaySwing(1f);
    }

    public void PlaySwing(float speedMultiplier)
    {
        if (swingRoutine != null)
        {
            StopCoroutine(swingRoutine);
        }

        float multiplier = Mathf.Max(0.1f, speedMultiplier);
        float duration = swingDuration / multiplier;
        swingRoutine = StartCoroutine(SwingRoutine(duration));
    }

    public void StopSwing()
    {
        if (swingRoutine != null)
        {
            StopCoroutine(swingRoutine);
            swingRoutine = null;
        }

        transform.localRotation = baseRotation;
    }

    private IEnumerator SwingRoutine(float duration)
    {
        float halfAngle = swingAngle * 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = duration <= 0f ? 1f : Mathf.Clamp01(elapsed / duration);
            float curve = swingCurve.Evaluate(t);
            float angle = Mathf.Lerp(-halfAngle, halfAngle, curve);
            transform.localRotation = baseRotation * Quaternion.Euler(0f, angle, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = baseRotation;
        swingRoutine = null;
    }
}
