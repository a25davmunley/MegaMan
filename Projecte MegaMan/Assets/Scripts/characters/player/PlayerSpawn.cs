using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform startSpawn;

    void Start()
    {
        transform.position = startSpawn.position;
    }
}
