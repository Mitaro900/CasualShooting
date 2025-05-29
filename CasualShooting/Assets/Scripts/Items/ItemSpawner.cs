using UnityEngine;

public class ItemSpawner : Spawner
{
    [SerializeField] private int minPower = 1;
    [SerializeField] private int maxPower = 4;

    protected override void SpawnObject()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int operationIdx = GameManager.Instance.IsFirstWave ? 0 : Random.Range(0, (int)OperationType.COUNT);
            GameObject go = Instantiate(prefab, spawnPoints[i].position, Quaternion.identity);
            go.GetComponent<Item>().Init((OperationType)operationIdx, Random.Range(minPower, maxPower + 1));
        }

        if(GameManager.Instance.IsFirstWave)
        {
            GameManager.Instance.IsFirstWave = false;
        }
    }
}
