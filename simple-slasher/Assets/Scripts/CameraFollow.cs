using UnityEngine;

/// <summary>
/// Простое следование камеры за игроком.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 8, -12);
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private bool lookAtTarget = true;

    private void LateUpdate()
    {
        if (target == null)
        {
            // Находим игрока если цель не задана
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
            else
            {
                return;
            }
        }

        // Вычисляем желаемую позицию
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Смотрим на цель
        if (lookAtTarget)
        {
            transform.LookAt(target.position + Vector3.up * 2f);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}