using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private int minPower = 1;
    [SerializeField] private int maxPower = 10;

    protected override void SpawnObject()
    {
        int index = Random.Range(0, spawnPoints.Length);
        GameObject go = Instantiate(prefab, spawnPoints[index].position, Quaternion.identity);
        go.GetComponent<Enemy>().Init(Random.Range(minPower, maxPower + 1) * (int)Mathf.Pow(GameManager.Instance.DifficultyLevel, 2f));
    }
}
