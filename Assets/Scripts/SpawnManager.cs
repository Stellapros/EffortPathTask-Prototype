using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject rewardPrefab;
    [SerializeField] private float xMin = -9f;
    [SerializeField] private float xMax = 9f;
    [SerializeField] private float zMin = -49f;
    [SerializeField] private float zMax = 49f;
    [SerializeField] private float ySpawnPosition = 0.1f;

    public void SpawnReward(int blockIndex, int trialIndex, int pressesRequired)
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(rewardPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(xMin, xMax);
        float z = Random.Range(zMin, zMax);
        return new Vector3(x, ySpawnPosition, z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = new Vector3((xMin + xMax) / 2, ySpawnPosition, (zMin + zMax) / 2);
        Vector3 size = new Vector3(xMax - xMin, 0.1f, zMax - zMin);
        Gizmos.DrawWireCube(center, size);
    }

    public void ClearReward()
    {
        foreach (GameObject reward in GameObject.FindGameObjectsWithTag("Reward"))
        {
            Destroy(reward);
        }
    }
}
