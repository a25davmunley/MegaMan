using UnityEngine;

public class MegaManScreenCamera : MonoBehaviour
{
    public Transform player;

    [Header("Follow")]
    public float followSpeed = 5f;

    [Header("Screen Transition")]
    public float screenWidth = 16f;
    public float screenHeight = 9f;
    public float transitionSpeed = 3f;

    [Header("Offsets")]
    public float horizontalOffset = 2f;
    public float verticalOffset = 2f;
    public float zOffset = -10f;

    private bool inTransition = false;
    private Vector3 targetPosition;

    void LateUpdate()
    {
        if (player == null) return;

        if (inTransition)
        {
            // 🔥 Transición Mega Man
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                transitionSpeed * Time.deltaTime
            );

            // Finalizar transición
            if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
            {
                transform.position = targetPosition;
                inTransition = false;
            }
        }
        else
        {
            // 🔥 Cámara libre siguiendo jugador
            Vector3 followPosition = new Vector3(
                player.position.x + horizontalOffset,
                player.position.y + verticalOffset,
                zOffset
            );

            transform.position = Vector3.Lerp(
                transform.position,
                followPosition,
                followSpeed * Time.deltaTime
            );
        }
    }

    // 🔥 LLAMAR ESTO DESDE UN TRIGGER
    public void SnapToScreen()
    {
        Vector2 screen = new Vector2(
            Mathf.Floor(player.position.x / screenWidth),
            Mathf.Floor(player.position.y / screenHeight)
        );

        targetPosition = new Vector3(
            screen.x * screenWidth + screenWidth / 2f + horizontalOffset,
            screen.y * screenHeight + screenHeight / 2f + verticalOffset,
            zOffset
        );

        inTransition = true;
    }
}