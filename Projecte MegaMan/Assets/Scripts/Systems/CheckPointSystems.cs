using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private const string CheckpointKey = "CheckpointPosition";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        SaveCheckpoint();
    }

    private void SaveCheckpoint()
    {
        Vector3 pos = transform.position;

        PlayerPrefs.SetFloat(CheckpointKey + "X", pos.x);
        PlayerPrefs.SetFloat(CheckpointKey + "Y", pos.y);
        PlayerPrefs.SetFloat(CheckpointKey + "Z", pos.z);

        PlayerPrefs.Save();
    }
}