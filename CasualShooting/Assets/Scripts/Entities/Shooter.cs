using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Entity entity;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireInterval = 1f;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private Transform firePoint; // 총알이 나가는 위치

    private void Start()
    {
        entity = GetComponent<Entity>();
        InvokeRepeating(nameof(Fire), 0f, fireInterval);
    }

    private void Fire()
    {
        GameObject proj = Instantiate(
            projectilePrefab,
            firePoint != null ? firePoint.position : transform.position,
            Quaternion.identity
        );
        proj.GetComponent<Projectile>().InitProjectile(projectileSpeed, entity.Power);
    }
}
