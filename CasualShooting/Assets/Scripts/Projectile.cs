using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 10f;
    private int damage = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f); // 5초 후에 자동으로 파괴
    }

    private void Update()
    {
        rb.linearVelocity = transform.forward * moveSpeed;
    }

    public void InitProjectile(float _moveSpeed, int _damage)
    {
        moveSpeed = _moveSpeed;
        damage = _damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
