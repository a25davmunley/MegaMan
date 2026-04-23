using UnityEngine;

public class CameraFollowBounds : MonoBehaviour
{
    public Transform player;
    public Transform boundsMin;
    public Transform boundsMax;

    public Vector3 offset = new Vector3(0, 0, -10);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (player == null || boundsMin == null || boundsMax == null) return;

        Vector3 targetPosition = player.position + offset;

        float clampedX = Mathf.Clamp(targetPosition.x, boundsMin.position.x, boundsMax.position.x);
        float clampedY = Mathf.Clamp(targetPosition.y, boundsMin.position.y, boundsMax.position.y);

        Vector3 finalPosition = new Vector3(clampedX, clampedY, offset.z);

        transform.position = Vector3.Lerp(transform.position, finalPosition, smoothSpeed * Time.deltaTime);
    }
}
