using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed = 5f;

    [Header("Offset")]
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10);
    [SerializeField] private float rotationSpeed = 2f;

    [Header("Zoom")]
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 15f;
    [SerializeField] private float zoomSpeed = 2f;

    private float currentZoom;
    private Vector3 currentOffset;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        currentZoom = offset.z;
        currentOffset = offset;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        FollowTarget();
        HandleZoom();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = target.position + currentOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Look at target
        Vector3 lookDirection = target.position - transform.position;
        lookDirection.y = 0; // Keep camera level
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            currentZoom = Mathf.Clamp(currentZoom + scroll * zoomSpeed, -maxZoom, -minZoom);
            currentOffset = new Vector3(offset.x, offset.y, currentZoom);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
