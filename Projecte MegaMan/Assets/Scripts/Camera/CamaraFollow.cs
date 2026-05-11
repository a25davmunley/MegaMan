using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    public Vector3 offset = new Vector3(0, 3, -6);

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void LateUpdate()
    {
        if (player == null) return;

        transform.position = player.position + offset;
    }
}