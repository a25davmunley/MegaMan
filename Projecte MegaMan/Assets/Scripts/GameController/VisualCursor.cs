using UnityEngine;

public class VisualCursor : MonoBehaviour
{
    public RectTransform cursor;
    public float speed = 20f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        cursor.position = Vector2.Lerp(
            cursor.position,
            Input.mousePosition,
            Time.deltaTime * speed
        );
    }
}