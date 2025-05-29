using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected Transform[] spawnPoints;
    [SerializeField] protected float spawnTime = 0f;
    [SerializeField] protected float spawnInterval = 10f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), spawnTime, spawnInterval);
    }

    protected abstract void SpawnObject();
}
