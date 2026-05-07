using UnityEngine;

public class CameraTransitionTrigger : MonoBehaviour
{
    public MegaManScreenCamera cameraController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraController.SnapToScreen();
        }
    }
}