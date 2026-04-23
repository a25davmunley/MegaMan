using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform startSpawn;

    void Start()
    {
        if (PlayerPrefs.HasKey("CheckpointX"))
        {
            float x = PlayerPrefs.GetFloat("CheckpointX");
            float y = PlayerPrefs.GetFloat("CheckpointY");
            float z = PlayerPrefs.GetFloat("CheckpointZ");

            transform.position = new Vector3(x, y, z);
        }
        else
        {
            transform.position = startSpawn.position;
        }
    }
}
