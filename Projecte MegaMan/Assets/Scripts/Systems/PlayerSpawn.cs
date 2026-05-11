using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform startSpawn;

    private const string CheckpointKey = "CheckpointPosition";

    void Start()
    {
        if (HasCheckpoint())
        {
            transform.position = LoadCheckpoint();
        }
        else
        {
            if (startSpawn != null)
            {
                transform.position = startSpawn.position;
            }
            else
            {
                Debug.LogError("StartSpawn no asignado en el Inspector");
            }
        }
    }

    private bool HasCheckpoint()
    {
        return PlayerPrefs.HasKey(CheckpointKey + "X");
    }

    private Vector3 LoadCheckpoint()
    {
        float x = PlayerPrefs.GetFloat(CheckpointKey + "X");
        float y = PlayerPrefs.GetFloat(CheckpointKey + "Y");
        float z = PlayerPrefs.GetFloat(CheckpointKey + "Z");

        return new Vector3(x, y, z);
    }
}