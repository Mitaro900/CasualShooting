using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 4f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItems), 0f, spawnInterval);
    }

    private void SpawnItems()
    {
        int index = Random.Range(0, spawnPoints.Length);
        GameObject go = Instantiate(enemyPrefab, spawnPoints[index].position, Quaternion.identity);
        go.GetComponent<Enemy>().InitEnemy(Random.Range(1, 10) * GameManager.Instance.difficultyLevel);
    }
}
