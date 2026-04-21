using UnityEngine;

public class MenuCursor : MonoBehaviour
{
    public RectTransform[] options;
    public RectTransform cursor;
    int index = 0;

    void Start()
    {
        UpdateCursor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            index = (index + 1) % options.Length;
            UpdateCursor();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index = (index - 1 + options.Length) % options.Length;
            UpdateCursor();
        }
    }

    void UpdateCursor()
    {
        cursor.position = new Vector3(
            options[index].position.x - 40,
            options[index].position.y,
            0
        );
    }
}