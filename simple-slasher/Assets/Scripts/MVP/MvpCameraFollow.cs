using UnityEngine;

public class MvpCameraFollow : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private float height = 8f;
    [SerializeField] private float distance = 12f;
    [SerializeField] private float smoothSpeed = 6f;
    [SerializeField] private bool lookAtTarget = true;

    private Transform target;
    private Vector3 offset;

    public void Initialize(Transform targetTransform)
    {
        target = targetTransform;
        offset = new Vector3(0f, height, -distance);
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        if (lookAtTarget)
        {
            transform.LookAt(target.position + Vector3.up * 1.5f);
        }
    }
}
