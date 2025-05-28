using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 10f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItems), 3f, spawnInterval);
    }

    private void SpawnItems()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject go = Instantiate(itemPrefab, spawnPoints[i].position, Quaternion.identity);
            go.GetComponent<Item>().InitItem((OperationType)Random.Range(0, 4), Random.Range(1, 4));
        }
    }
}
